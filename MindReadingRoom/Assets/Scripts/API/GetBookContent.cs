using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class GetBookContent
{
    public class Result
    {
        public string poem;
        public string imageUrl;

    }
    
    public static IEnumerator Send(string nickname, BookLocationData locationData, Action<BookData> callback)
    {
        var webRequest = UnityWebRequest.Get($"{Constants.Url}/api/book/detail?nickname={UnityWebRequest.EscapeURL(nickname)}&index={UnityWebRequest.EscapeURL(locationData.shelfID)}&row={locationData.row}");
        Debug.Log(webRequest.uri.ToString());
        
        webRequest.SetRequestHeader("Content-Type", "text/plain");
        
        yield return webRequest.SendWebRequest();
        
        Debug.Log(webRequest.downloadHandler.text);

        string jsonText = webRequest.downloadHandler.text;
        Result result = JsonConvert.DeserializeObject<Result>(jsonText);
        Debug.Log(result.poem);
        Debug.Log(result.imageUrl);

        BookData book = new BookData();
        book.content = result.poem;

        yield return GetImg.Send(result.imageUrl, sprite =>
            {
                book.sprite = sprite;
                callback?.Invoke(book);
            });
    }
}