
using SevenZip.Compression.LZMA;
using System.IO;
using System;

	public class SevenZipHelper
	{
	public static SevenZipHelper Instance = new SevenZipHelper();
	public  void CompressFileLZMA(string inFile, string outFile)
	{
		SevenZip.Compression.LZMA.Encoder coder = new SevenZip.Compression.LZMA.Encoder();
		FileStream input = new FileStream(inFile, FileMode.Open);
		FileStream output = new FileStream(outFile, FileMode.Create);

		// Write the encoder properties
		coder.WriteCoderProperties(output);

		// Write the decompressed file size.
		output.Write(BitConverter.GetBytes(input.Length), 0, 8);

		// Encode the file.
		coder.Code(input, output, input.Length, -1, null);
		output.Flush();
		output.Close();
		input.Close();
	}



	public  void DecompressFileLZMA(string inFile, string outFile)
	{
		SevenZip.Compression.LZMA.Decoder coder = new SevenZip.Compression.LZMA.Decoder();
		FileStream input = new FileStream(inFile, FileMode.Open);
		FileStream output = new FileStream(outFile, FileMode.Create);

		// Read the decoder properties
		byte[] properties = new byte[5];
		input.Read(properties, 0, 5);

		// Read in the decompress file size.
		byte [] fileLengthBytes = new byte[8];
		input.Read(fileLengthBytes, 0, 8);
		long fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

		// Decompress the file.
		coder.SetDecoderProperties(properties);
		coder.Code(input, output, input.Length, fileLength, null);
		output.Flush();
		output.Close();
		input.Close();
	}
	public byte[] StreamToBytes(Stream stream)
	{
		byte[] bytes = new byte[stream.Length];
		stream.Read(bytes, 0, bytes.Length);
		// 设置当前流的位置为流的开始
		stream.Seek(0, SeekOrigin.Begin);
		return bytes;
	}

	/// 将 byte[] 转成 Stream

	public Stream BytesToStream(byte[] bytes)
	{
		Stream stream = new MemoryStream(bytes);
		return stream;
	}
	public void DecompressFileLZMA(byte[] inFile, string outFile)
	{
		SevenZip.Compression.LZMA.Decoder coder = new SevenZip.Compression.LZMA.Decoder();
		Stream input = BytesToStream(inFile);
		FileStream output = new FileStream(outFile, FileMode.Create);

		// Read the decoder properties
		byte[] properties = new byte[5];
		input.Read(properties, 0, 5);

		// Read in the decompress file size.
		byte [] fileLengthBytes = new byte[8];
		input.Read(fileLengthBytes, 0, 8);
		long fileLength = BitConverter.ToInt64(fileLengthBytes, 0);

		// Decompress the file.
		coder.SetDecoderProperties(properties);
		coder.Code(input, output, input.Length, fileLength,null);
		output.Flush();
		output.Close();
		input.Close();
	}

//	private static void CompressFileLZMA(byte[] inFile,byte[] outFile)
//	{
//		SevenZip.Compression.LZMA.Encoder coder = new SevenZip.Compression.LZMA.Encoder();
//
//		FileStream input = new FileStream();//ew FileStream(inFile, FileMode.Open);
//		input.re
//		FileStream output = new FileStream(outFile, FileMode.Create);
//	
//		// Write the encoder properties
//		coder.WriteCoderProperties(output);
//
//		// Write the decompressed file size.
//		output.Write(BitConverter.GetBytes(input.Length), 0, 8);
//		coder.Code(input, output, input.Length, -1, null);
//		output.Flush();
//		output.Close();
//		input.Close();
//	}

}

