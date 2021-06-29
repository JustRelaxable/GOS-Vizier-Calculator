using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class CustomReader : System.IO.StreamReader
{
    public CustomReader(Stream stream) : base(stream)
    {
    }

    public CustomReader(string path) : base(path)
    {
    }

    public CustomReader(Stream stream, bool detectEncodingFromByteOrderMarks) : base(stream, detectEncodingFromByteOrderMarks)
    {
    }

    public CustomReader(Stream stream, Encoding encoding) : base(stream, encoding)
    {
    }

    public CustomReader(string path, bool detectEncodingFromByteOrderMarks) : base(path, detectEncodingFromByteOrderMarks)
    {
    }

    public CustomReader(string path, Encoding encoding) : base(path, encoding)
    {
    }

    public CustomReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks) : base(stream, encoding, detectEncodingFromByteOrderMarks)
    {
    }

    public CustomReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks) : base(path, encoding, detectEncodingFromByteOrderMarks)
    {
    }

    public CustomReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize) : base(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize)
    {
    }

    public CustomReader(string path, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize) : base(path, encoding, detectEncodingFromByteOrderMarks, bufferSize)
    {
    }

    public CustomReader(Stream stream, Encoding encoding, bool detectEncodingFromByteOrderMarks, int bufferSize, bool leaveOpen) : base(stream, encoding, detectEncodingFromByteOrderMarks, bufferSize, leaveOpen)
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
