using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

namespace HTTP
{
    public class PostContent : ApiBase
    {
        private static string Uri => $"{Common.Domain}/api/book/save";

        public static UnityWebRequest CreateWebRequest(string content, string index, int row, string nickname)
        {
            // content, index, row, nickname
            var requestData = new Request
            {
                content = content,
                index = index,
                row = row,
                nickname = nickname,
            };
            var body = JsonConvert.SerializeObject(requestData);
            var webRequest = UnityWebRequest.Post(Uri, body, UnityWebRequest.kHttpVerbPOST);
            webRequest.SetRequestHeader("Content-Type", "application/json");
            return webRequest;
        }
        
        public class Request : RequestBase
        {
            public string content;
            public string index;
            public int row;
            public string nickname;
        }

        public class Result : ResultBase
        {
            private int _statusCode;
            public int statusCode
            {
                get => _statusCode;
                set => _statusCode = value;
            }
            public bool IsSuccess => statusCode == 200;
        }
    }
}