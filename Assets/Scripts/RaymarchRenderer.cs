using System;
using System.Collections.Generic;
using UnityEngine;
public class RaymarchRenderer : MonoBehaviour
{
    [HideInInspector] public float wPos;
    [HideInInspector] public Vector3 wRot;
    public enum Shape { 
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
    public static float radius = .5f;
};
public struct TorusDimensions
{
    public static Vector2 thickness = new Vector2(.4f, .1f);
};
public struct CappedTorusDimensions
{
    public static float ro = .25f;
    public static float ri = .1f;
    public static Vector2 thickness = new Vector2(.1f, .1f);
};
public struct LinkDimensions
{
    public static float separation = .13f;
    public static float radius = .2f;
    public static float thickness = .09f;
};
public struct ConeDimensions
{
    public static Vector2 tan = new Vector2(1, .5f);
    public static float height = 1;    
};
public struct InfiniteConeDimensions
{
    public static Vector2 tan = new Vector2(.1f, .1f);
};
public struct PlaneDimensions
{
    public static Vector3 normal = new Vector3(0, .5f, .5f);
    public static float distance = 1;
};
public struct HexagonalPrismDimensions
{
    public static Vector2 h = new Vector2(.25f, .25f);
};
public struct TriangularPrism
{
    public static Vector2 h = new Vector2(.25f, .25f);
};
public struct CapsuleDimensions
{
    public static Vector3 a = new Vector3(.25f, .1f, .25f);
    public static Vector3 b = new Vector3(.1f, .25f, .25f);
    public static float r = .25f;
};
public struct InfiniteCylinderDimensions
{
    public static Vector3 c = new Vector3(0, .25f, .25f);
};
public struct BoxDimensions
{
    public static float size = .5f;
};
public struct RoundBoxDimensions
{
    public static float size = .3f;
    public static float roundFactor = .1f;
};
public struct RoundedCylinderDimensions
{
    public static float ra = .25f;
    public static float rb = .1f;
    public static float h = .25f;
};
public struct CappedConeDimensions
{
    public static float h = .5f;
    public static float r1 = .5f;
    public static float r2 = .2f;
};
public struct BoxFrameDimensions
{
    public static Vector3 size = new Vector3(.5f, .3f, .2f);
    public static float cavity = .1f;
};
public struct SolidAngleDimensions
{
    public static Vector2 c = new Vector2(.25f, .25f);
    public static float ra = .5f;
};
public struct CutSphereDimensions
{
    public static float r = .25f;
    public static float h = .1f;
};
public struct HollowSphereDimensions
{
    public static float r = .35f;
    public static float h = .05f;
    public static float t = .05f;
};
public struct DeathStarDimensions
{
    public static float ra = .5f;
    public static float rb = .35f;
    public static float d = .5f;
};
public struct RoundConeDimensions
{
    public static float r1 = .1f;
    public static float r2 = .25f;
    public static float h = .4f;
};
public struct EllipsoidDimensions
{
    public static Vector3 Radius = new Vector3(.18f, .3f, .1f);
};
public struct RhombusDimensions
{
    public static float la = .6f;
    public static float lb = .2f;
    public static float h = .02f;
    public static float ra = .02f;
};
public struct OctahedronDimensions
{
    public static float size = .5f;
};
public struct PyramidDimensions
{
    public static float size = .5f;
};
public struct TriangleDimensions
{
    public static Vector3 sideA = new Vector3(.3f, .5f, .15f);
    public static Vector3 sideB = new Vector3(.8f, .2f, .1f);
    public static Vector3 sideC = new Vector3(.7f, .3f, .5f);
};
public struct QuadDimensions
{
    public static Vector3 sideA = new Vector3(.3f, .5f, .15f);
    public static Vector3 sideB = new Vector3(.8f, .2f, 0);
    public static Vector3 sideC = new Vector3(.9f, .3f, .5f);
    public static Vector3 sideD = new Vector3(.1f, .2f, .5f);
};

public struct FractalDimenisons
{
    public static float i = 10;
    public static float s = 1.25f;
    public static float o = 2;
};
public struct TesseractDimensions
{
    public static Vector4 size = new Vector4(.25f, .25f, .25f, .25f);
};


