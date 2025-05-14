using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using System;

public class GetBookContent
{
    public class Result
    {
        public class Data
        {
            public string content;
            public string url;
        }
    
        public Data data;
        public string error;
        public string message;
        public bool status;
    }
    
    public static IEnumerator Send(string nickname, BookLocationData locationData, Action<BookData> callback)
    {
        var webRequest = UnityWebRequest.Get($"{Constants.Url}/api/book/detail?nickname={UnityWebRequest.EscapeURL(nickname)}&index={UnityWebRequest.EscapeURL(locationData.shelfID)}&row={locationData.row}");
        Debug.Log(webRequest.uri.ToString());
        
        webRequest.SetRequestHeader("Content-Type", "text/plain");
        
        yield return webRequest.SendWebRequest();
        
        Debug.Log(webRequest.downloadHandler.text);

        string jsonText = webRequest.downloadHandler.text;
        Result getJson = JsonConvert.DeserializeObject<Result>(jsonText);
        
        BookData book = new BookData();
        book.content = getJson.data.content;
        //book.sprite = getJson.data.url;
        
        callback?.Invoke(book);
    }
}