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
    }
}
