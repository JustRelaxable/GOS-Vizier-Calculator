using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CustomStream : System.IO.Stream
{
    AndroidJavaObject innerInputStream;

    public CustomStream(AndroidJavaObject inputStream)
    {
        innerInputStream = inputStream;
    }

    public override bool CanRead => true;

    public override bool CanSeek => false;

    public override bool CanWrite => false;

    public override long Length => innerInputStream.Call<int>("available");

    public override long Position { get => pos; set => pos += value; }

    private long pos = 0;

    public override void Flush()
    {
        Debug.Log("IDK WHat is going on");
    }

    public override int Read(byte[] buffer, int offset, int count)
    {
        AndroidJavaObject inputData = innerInputStream.Call<AndroidJavaObject>("byteRead",buffer, offset, count);
        int intToReturn = inputData.Call<int>("getNumberOfReadBytesBytes");
        int[] unsignedBytes = inputData.Call<int[]>("getBytes");

        for (int i = 0; i < unsignedBytes.Length; i++)
        {
            buffer[i] = (byte)unsignedBytes[i];
        }

        return intToReturn;
    }

    public override long Seek(long offset, SeekOrigin origin)
    {
        return 1;
    }

    public override void SetLength(long value)
    {
        Debug.Log("IDK");
    }

    public override void Write(byte[] buffer, int offset, int count)
    {
        Debug.Log("idk");
    }
}
