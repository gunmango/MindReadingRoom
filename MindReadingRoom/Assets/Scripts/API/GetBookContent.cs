using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

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
    
    public static IEnumerator Send(string nickname, string index, int row)
    {
        var webRequest = UnityWebRequest.Get($"{Constants.Url}/api/book/detail?nickname={UnityWebRequest.EscapeURL(nickname)}&index={UnityWebRequest.EscapeURL(index)}&row={row}");
        Debug.Log(webRequest.uri.ToString());
        
        webRequest.SetRequestHeader("Content-Type", "text/plain");
        
        yield return webRequest.SendWebRequest();
        
        Debug.Log(webRequest.downloadHandler.text);

        string jsonText = webRequest.downloadHandler.text;
        Result getJson = JsonConvert.DeserializeObject<Result>(jsonText);
        Debug.Log($"{getJson.data.content} / {getJson.data.url}");
    }
}