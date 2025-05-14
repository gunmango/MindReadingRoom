using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class GetImg
{
    public static IEnumerator Send(string url, Action<Sprite> OnCompleted)
    {
        var webRequest = UnityWebRequestTexture.GetTexture($"{url}");
        Debug.Log(webRequest.uri.ToString());
        
        webRequest.SetRequestHeader("Content-Type", "text/plain");
        
        yield return webRequest.SendWebRequest();

        Sprite sprite = GetSprite(webRequest);
        Debug.Log("GetImg 완료");
        OnCompleted.Invoke(sprite);
    }
    
    private static Sprite GetSprite(UnityWebRequest webRequest)
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
