using UnityEngine.Networking;

namespace HTTP
{
    public class GetBookContent : ApiBase
    {
        private static string Uri => $"{Common.Domain}/get-book-content";

        public static UnityWebRequest CreateWebRequest(int bookId)
        {
            var webRequest = UnityWebRequest.Get(Uri);
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