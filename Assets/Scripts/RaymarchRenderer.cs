using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class RaymarchRenderer : MonoBehaviour
{
    [HideInInspector] public static float wPos;
    [HideInInspector] public static Vector3 wRot;
    private void Awake()
    {
        wPos = EditorPrefs.GetFloat("WPos", 0);
        wRot = new Vector3(EditorPrefs.GetFloat("WRotX", 0), EditorPrefs.GetFloat("WRotY", 0), EditorPrefs.GetFloat("WRotZ", 0));
    }
    public enum Shape
    {
        Shpere,
        Torus,
        CappedTorus,
        Link,
        Cone,
        InfCone,
        Plane,
        HexPrism,
        TriPrism,
        Capsule,
        InfiniteCylinder,
        Box,
        RoundBox,
        RoundedCylinder,
        CappedCone,
        BoxFrame,
        SolidAngle,
        CutSphere,
        CutHollowSphere,
        DeathStar,
        RoundCone,
        Ellipsoid,
        Rhombus,
        Octahedron,
        Pyramid,
        Triangle,
        Quad,
        Fractal,
        Tesseract
    };

    public Shape shape;
    public Color color;
}
public struct SphereDimensions
{
    public static float radius = EditorPrefs.GetFloat("SphereRadius", .5f);
};
public struct TorusDimensions
{
    public static Vector2 thickness = new Vector2(EditorPrefs.GetFloat("TorusThicknessX", .4f), EditorPrefs.GetFloat("TorusThicknessY", .1f));
};
public struct CappedTorusDimensions
{
    public static float ro = EditorPrefs.GetFloat("CTRo", .25f);
    public static float ri = EditorPrefs.GetFloat("CTRi", .1f);
    public static Vector2 thickness = new Vector2(EditorPrefs.GetFloat("CTTx", .1f), EditorPrefs.GetFloat("CTTy", .1f));
};
public struct LinkDimensions
{
    public static float separation = EditorPrefs.GetFloat("LinkSeparation", .13f);
    public static float radius = EditorPrefs.GetFloat("LinkRadius", .2f);
    public static float thickness = EditorPrefs.GetFloat("LinkThickness", .09f);
};
public struct ConeDimensions
{
    public static Vector2 tan = new Vector2(EditorPrefs.GetFloat("ConeTanX", 1), EditorPrefs.GetFloat("ConeTanY", 2));
    public static float height = EditorPrefs.GetFloat("ConeHeight", 1);
};
public struct InfiniteConeDimensions
{
    public static Vector2 tan = new Vector2(EditorPrefs.GetFloat("ICTanX", .1f), EditorPrefs.GetFloat("ICTanY", .1f));
};
public struct PlaneDimensions
{
    public static Vector3 normal = new Vector3(EditorPrefs.GetFloat("PlaneNormalX", 0), EditorPrefs.GetFloat("PlaneNormalX", .5f), EditorPrefs.GetFloat("PlaneNormalX", .5f));
    public static float distance = EditorPrefs.GetFloat("PlaneDistance", 1);
};
public struct HexagonalPrismDimensions
{
    public static Vector2 h = new Vector2(EditorPrefs.GetFloat("HPHX", .25f), EditorPrefs.GetFloat("HPHY", .25f));
};
public struct TriangularPrismDimensions
{
    public static Vector2 h = new Vector2(EditorPrefs.GetFloat("TPHX", .25f), EditorPrefs.GetFloat("TPHY", .25f));
};
public struct CapsuleDimensions
{
    public static Vector3 a = new Vector3(EditorPrefs.GetFloat("CapsuleAX", .25f), EditorPrefs.GetFloat("CapsuleAY", .1f), EditorPrefs.GetFloat("CapsuleAZ", .25f));
    public static Vector3 b = new Vector3(EditorPrefs.GetFloat("CapsuleBX", .1f), EditorPrefs.GetFloat("CapsuleBY", .25f), EditorPrefs.GetFloat("CapsuleBZ", .25f));
    public static float r = EditorPrefs.GetFloat("CapsuleR", .25f);
};
public struct InfiniteCylinderDimensions
{
    public static Vector3 c = new Vector3(EditorPrefs.GetFloat("ICCX", 0), EditorPrefs.GetFloat("ICCY", .25f), EditorPrefs.GetFloat("ICCZ", .25f));
};
public struct BoxDimensions
{
    public static float size = EditorPrefs.GetFloat("BoxSize", .25f);
};
public struct RoundBoxDimensions
{
    public static float size = EditorPrefs.GetFloat("RoundBoxSize", .3f);
    public static float roundFactor = EditorPrefs.GetFloat("RoundBoxFactor", .1f);
};
public struct RoundedCylinderDimensions
{
    public static float ra = EditorPrefs.GetFloat("RCra", .25f);
    public static float rb = EditorPrefs.GetFloat("RCrb", .1f);
    public static float h = EditorPrefs.GetFloat("RCh", .25f);
};
public struct CappedConeDimensions
{
    public static float h = EditorPrefs.GetFloat("CCh", .5f);
    public static float r1 = EditorPrefs.GetFloat("CCr1", .5f);
    public static float r2 = EditorPrefs.GetFloat("CCr2", .2f);
};
public struct BoxFrameDimensions
{
    public static Vector3 size = new Vector3(EditorPrefs.GetFloat("BFSizeX", .5f), EditorPrefs.GetFloat("BFSizeY", .3f), EditorPrefs.GetFloat("BFSizeZ", .2f));
    public static float cavity = EditorPrefs.GetFloat("BFc", .1f);
};
public struct SolidAngleDimensions
{
    public static Vector2 c = new Vector2(EditorPrefs.GetFloat("SAcX", .25f), EditorPrefs.GetFloat("SAcY", .25f));
    public static float ra = EditorPrefs.GetFloat("SAcra", .5f);
};
public struct CutSphereDimensions
{
    public static float r = EditorPrefs.GetFloat("CSr", .25f);
    public static float h = EditorPrefs.GetFloat("CSh", .1f);
};
public struct HollowSphereDimensions
{
    public static float r = EditorPrefs.GetFloat("HSr", .35f);
    public static float h = EditorPrefs.GetFloat("HSh", .05f);
    public static float t = EditorPrefs.GetFloat("HSt", .05f);
};
public struct DeathStarDimensions
{
    public static float ra = EditorPrefs.GetFloat("DSra", .5f);
    public static float rb = EditorPrefs.GetFloat("DSrb", .35f);
    public static float d = EditorPrefs.GetFloat("DSd", .5f);
};
public struct RoundConeDimensions
{
    public static float r1 = EditorPrefs.GetFloat("RCr1", .1f);
    public static float r2 = EditorPrefs.GetFloat("RCr2", .25f);
    public static float h = EditorPrefs.GetFloat("RCh", .4f);
};
public struct EllipsoidDimensions
{
    public static Vector3 Radius = new Vector3(EditorPrefs.GetFloat("EDrX", .18f), EditorPrefs.GetFloat("EDrY", .3f), EditorPrefs.GetFloat("EDrZ", .1f));
};
public struct RhombusDimensions
{
    public static float la = EditorPrefs.GetFloat("RDla", .6f);
    public static float lb = EditorPrefs.GetFloat("RDlb", .2f);
    public static float h = EditorPrefs.GetFloat("RDh", .02f);
    public static float ra = EditorPrefs.GetFloat("RDra", .02f);
};
public struct OctahedronDimensions
{
    public static float size = EditorPrefs.GetFloat("OctaSize", .5f);
};
public struct PyramidDimensions
{
    public static float size = EditorPrefs.GetFloat("PryramidSize", .5f);
};
public struct TriangleDimensions
{
    public static Vector3 sideA = new Vector3(EditorPrefs.GetFloat("TAX", .3f), EditorPrefs.GetFloat("TAY", .5f), EditorPrefs.GetFloat("TAZ", .15f));
    public static Vector3 sideB = new Vector3(EditorPrefs.GetFloat("TBX", .8f), EditorPrefs.GetFloat("TBY", .2f), EditorPrefs.GetFloat("TBZ", .1f));
    public static Vector3 sideC = new Vector3(EditorPrefs.GetFloat("TCX", .7f), EditorPrefs.GetFloat("TCY", .3f), EditorPrefs.GetFloat("TCZ", .5f));
};
public struct QuadDimensions
{
    public static Vector3 sideA = new Vector3(EditorPrefs.GetFloat("QAX", .3f), EditorPrefs.GetFloat("QAY", .5f), EditorPrefs.GetFloat("QAZ", .15f));
    public static Vector3 sideB = new Vector3(EditorPrefs.GetFloat("QBX", .8f), EditorPrefs.GetFloat("QBY", .2f), EditorPrefs.GetFloat("QBZ", 0));
    public static Vector3 sideC = new Vector3(EditorPrefs.GetFloat("QCX", .9f), EditorPrefs.GetFloat("QCY", .3f), EditorPrefs.GetFloat("QCZ", .5f));
    public static Vector3 sideD = new Vector3(EditorPrefs.GetFloat("QDX", .1f), EditorPrefs.GetFloat("QDY", .2f), EditorPrefs.GetFloat("QDZ", .5f));
};

public struct FractalDimenisons
{
    public static float i = EditorPrefs.GetFloat("Fraci", 10);
    public static float s = EditorPrefs.GetFloat("Fracs", 1.25f);
    public static float o = EditorPrefs.GetFloat("Fraco", 2);
};
public struct TesseractDimensions
{
    public static Vector4 size = new Vector4(EditorPrefs.GetFloat("TessX", .25f), EditorPrefs.GetFloat("TessY", .25f), EditorPrefs.GetFloat("TessZ", .25f), EditorPrefs.GetFloat("TessW", .25f));
};
