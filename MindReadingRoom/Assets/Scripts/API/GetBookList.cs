using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class GetBookList
{
    public class Result
    {
        public string Index;
        public int Row;
    }
    
    public static IEnumerator Send(string nickname, Action<List<BookLocationData>> callback)
    {
        var webRequest = UnityWebRequest.Get($"{Constants.Url}/api/book/list?nickname={UnityWebRequest.EscapeURL(nickname)}");
        Debug.Log(webRequest.uri.ToString());
        
        webRequest.SetRequestHeader("Content-Type", "text/plain");
        
        yield return webRequest.SendWebRequest();
        
        Debug.Log(webRequest.downloadHandler.text);

        string jsonText = webRequest.downloadHandler.text;
        var list = JsonConvert.DeserializeObject<List<Result>>(jsonText);
        
        List<BookLocationData> locationDatas = new List<BookLocationData>();
        
        foreach (var data in list)
        {
            BookLocationData location = new BookLocationData();
            location.shelfID = data.Index;
            location.row = data.Row;
            locationDatas.Add(location);
        }
        
        callback?.Invoke(locationDatas);
    }
}