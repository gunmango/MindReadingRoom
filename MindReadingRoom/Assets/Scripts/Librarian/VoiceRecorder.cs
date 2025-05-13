using UnityEngine;
using System.IO;
using UnityEngine.Networking;
using System.Collections;

public class VoiceRecorder : MonoBehaviour
{
    private AudioClip clip;
    private string initialWavName = string.Empty;

    public void StartRecording()
    {
        clip = Microphone.Start(null, false, 10, 44100);
    }

    public void StopRecordingAndSend()
    {
        Microphone.End(null);
        WavUtility.SaveWav(initialWavName, clip);
        //StartCoroutine(SendAudioFile(savePath));
    }

    IEnumerator SendAudioFile(string path)
    {
        byte[] audioData = File.ReadAllBytes(path);
        WWWForm form = new WWWForm();
        form.AddBinaryData("file", audioData, "record.wav", "audio/wav");

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost:5000/upload", form))
        {
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.Success)
                Debug.Log("전송 성공: " + www.downloadHandler.text);
            else
                Debug.LogError("전송 실패: " + www.error);
        }
    }

}
