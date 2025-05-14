using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class GetBookList
{
    public class Result
    {
        public class Data
        {
            public List<int> bookIdList;
        }
    
        public Data data;
        public string error;
        public string message;
        public bool status;
    }
    
    public static IEnumerator Send(string nickname)
    {
        var webRequest = UnityWebRequest.Get($"{Constants.Url}/api/book/list?nickname={UnityWebRequest.EscapeURL(nickname)}");
        Debug.Log(webRequest.uri.ToString());
        
        webRequest.SetRequestHeader("Content-Type", "text/plain");
        
        yield return webRequest.SendWebRequest();
        
        Debug.Log(webRequest.downloadHandler.text);

        string jsonText = webRequest.downloadHandler.text;
        Result getJson = JsonConvert.DeserializeObject<Result>(jsonText);
        Debug.Log($"{getJson.data.bookIdList}");
    }
}