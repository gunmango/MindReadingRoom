using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using System;

public class GetBookList
{
    public class Result
    {
        public class Data
        {
            public List<BookLocationData> bookLocations;
        }
    
        public Data data;
        public string error;
        public string message;
        public bool status;
    }
    
    public static IEnumerator Send(string nickname, Action<List<BookLocationData>> callback)
    {
        var webRequest = UnityWebRequest.Get($"{Constants.Url}/api/book/list?nickname={UnityWebRequest.EscapeURL(nickname)}");
        Debug.Log(webRequest.uri.ToString());
        
        webRequest.SetRequestHeader("Content-Type", "text/plain");
        
        yield return webRequest.SendWebRequest();
        
        Debug.Log(webRequest.downloadHandler.text);

        string jsonText = webRequest.downloadHandler.text;
        var result = JsonConvert.DeserializeObject<List<BookLocationData>>(jsonText);
        callback.Invoke(result);
    }
}