using UnityEngine.Networking;

namespace HTTP
{
    public class GetBookContent : ApiBase
    {
        private static string Uri => $"{Common.Domain}/api/book/detail";

        public static UnityWebRequest CreateWebRequest(string nickname, string index, int row)
        {
            string urlWithParams = $"{Uri}?nickname={UnityWebRequest.EscapeURL(nickname)}&index={UnityWebRequest.EscapeURL(index)}&row={row}";
            var webRequest = UnityWebRequest.Get(urlWithParams);
            webRequest.SetRequestHeader("Content-Type", "text/plain");
            return webRequest;
        }

        public class Result : ResultBase
        {
            public class Data
            {
                public int bookId;
                public string content;
                public string url;
            }

            public Data data;
        }
    }
}