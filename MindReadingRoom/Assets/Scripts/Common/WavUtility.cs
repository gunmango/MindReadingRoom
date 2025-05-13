using System.IO;
using UnityEngine;

public static class WavUtility
{
    public static void SaveWav(string filenameWithoutExtension, AudioClip clip)
    {
        string filepath = Path.Combine(Application.persistentDataPath, filenameWithoutExtension + ".wav");
        Directory.CreateDirectory(Path.GetDirectoryName(filepath));
        
        using (FileStream fileStream = new FileStream(filepath, FileMode.Create))
        {
            WriteWavFileHeader(fileStream, clip);
            WriteWavData(fileStream, clip);
        }

        Debug.Log("WAV saved to: " + filepath);
    }

    private static void WriteWavFileHeader(FileStream stream, AudioClip clip)
    {
        int sampleCount = clip.samples * clip.channels;
        int frequency = clip.frequency;
        int channels = clip.channels;
        int byteRate = frequency * channels * 2;

        // 초기 헤더 공간 확보 (나중에 덮어씀)
        byte[] emptyBytes = new byte[44];
        stream.Write(emptyBytes, 0, 44);
    }

    private static void WriteWavData(FileStream stream, AudioClip clip)
    {
        float[] samples = new float[clip.samples * clip.channels];
        clip.GetData(samples, 0);

        byte[] bytesData = new byte[samples.Length * 2]; // 16bit PCM

        int offset = 0;
        foreach (float sample in samples)
        {
            short intData = (short)(Mathf.Clamp(sample, -1f, 1f) * short.MaxValue);
            byte[] byteArr = System.BitConverter.GetBytes(intData);
            byteArr.CopyTo(bytesData, offset);
            offset += 2;
        }

        stream.Write(bytesData, 0, bytesData.Length);
        UpdateWavHeader(stream, clip, bytesData.Length);
    }

    private static void UpdateWavHeader(FileStream stream, AudioClip clip, int dataLength)
    {
        stream.Seek(0, SeekOrigin.Begin);

        int fileSize = 36 + dataLength;
        int frequency = clip.frequency;
        int channels = clip.channels;
        int byteRate = frequency * channels * 2;

        using (BinaryWriter writer = new BinaryWriter(stream))
        {
            writer.Write(System.Text.Encoding.UTF8.GetBytes("RIFF"));
            writer.Write(fileSize);
            writer.Write(System.Text.Encoding.UTF8.GetBytes("WAVE"));

            writer.Write(System.Text.Encoding.UTF8.GetBytes("fmt "));
            writer.Write(16); // Subchunk1Size
            writer.Write((short)1); // AudioFormat PCM
            writer.Write((short)channels);
            writer.Write(frequency);
            writer.Write(byteRate);
            writer.Write((short)(channels * 2)); // BlockAlign
            writer.Write((short)16); // BitsPerSample

            writer.Write(System.Text.Encoding.UTF8.GetBytes("data"));
            writer.Write(dataLength);
        }
    }
}