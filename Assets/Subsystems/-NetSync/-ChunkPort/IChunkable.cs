using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public interface IChunkable 
{
    void Write(BinaryWriter writer);

    void Read(BinaryReader reader);

}
