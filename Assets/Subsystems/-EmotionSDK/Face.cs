using System.Collections.Generic;

public class Face
{
    public CGRect faceRect;
    public bool isMaxFace;
    public CGPoint leftEyesPos;
    public CGPoint rightEyesPos;
    public CGPoint nosePos;
    public CGPoint leftMouthCornerPos;
    public CGPoint rightMouthCornerPos;
    public List<float> emotion;
    public List<float> direction;
}

public struct CGPoint
{
    public float x;
    public float y;
}

public struct CGSize
{
    float width;
    float height;
}

public struct CGRect
{
    public CGPoint origin;
    public CGSize size;
}