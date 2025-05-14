using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class PostContent
{
    public class Request
    {
        public string content;
        public string index;
        public int row;
        public string nickname;
    }
    
    public class Result
    {
        public class Data
        {
            private int _statusCode;
            public int statusCode
            {
                get => _statusCode;
                set => _statusCode = value;
            }
            public bool IsSuccess => statusCode == 200;
        }
    
        public Data data;
        public string error;
        public string message;
        public bool status;
    }
    
    public static IEnumerator Send(string content, string index, int row, string nickname)
    {
        Request req = new Request()
        {
            content = content,
            index = index,
            row = row,
            nickname = nickname,
        };
        string body = JsonConvert.SerializeObject(req);
        
        var webRequest = UnityWebRequest.Post($"{Constants.Url}/api/book/save", body, UnityWebRequest.kHttpVerbPOST);
        Debug.Log(webRequest.uri.ToString());
        
        webRequest.SetRequestHeader("Content-Type", "application/json");
        
        yield return webRequest.SendWebRequest();
        
        Debug.Log(webRequest.downloadHandler.text);

        string jsonText = webRequest.downloadHandler.text;
        Result result = JsonConvert.DeserializeObject<Result>(jsonText);
        Debug.Log($"{result.data.statusCode}");
    }
}

