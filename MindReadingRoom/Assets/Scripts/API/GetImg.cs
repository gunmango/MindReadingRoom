using System.IO;
using UnityEngine;
using UnityEngine.Networking;

namespace HTTP
{
    public class GetImg : ApiBase
    {
        public static UnityWebRequest CreateTextureWebRequest(string imageUrl)
        {
            // 직접 이미지 URL로 요청
            var webRequest = UnityWebRequestTexture.GetTexture(imageUrl);
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