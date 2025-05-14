using UnityEngine.Networking;
using System.Collections.Generic;

namespace HTTP
{
    public class GetBookList : ApiBase
    {
        private static string Uri => $"{Common.Domain}/get-book-list";

        public static UnityWebRequest CreateWebRequest()
        {
            var webRequest = UnityWebRequest.Get(Uri);
            webRequest.SetRequestHeader("Content-Type", "text/plain");
            return webRequest;
        }

        public class Result : ResultBase
        {
            public class Data
            {
                public List<int> bookIdList;
            }

            public Data data;
        }
    }
}