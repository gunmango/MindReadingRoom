using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace HTTP
{
    public class GetImg : ApiBase
    {
        private static string Uri => $"{Common.Domain}/get-img";

        public static UnityWebRequest CreateTextureWebRequest(string filename)
        {
            var webRequest = UnityWebRequestTexture.GetTexture($"{Uri}/{filename}");
            webRequest.SetRequestHeader("Content-Type", "text/plain");
            return webRequest;
        }
            
        public static Sprite GetSprite(UnityWebRequest webRequest)
        {
            // 응답 데이터를 Texture2D로 복원
            var texture = DownloadHandlerTexture.GetContent(webRequest);
            var sprite = Sprite.Create(texture,
                new Rect(0, 0, texture.width, texture.height),
                new Vector2(0.5f, 0.5f));
            sprite.name = Path.GetFileName(webRequest.url);
            return sprite;
        }

    }
}