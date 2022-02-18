using System;
using UnityEngine;
public class Helpers : MonoBehaviour
{
    public static vector12 GetDimensionVectors(int i)
    {
        int len = Enum.GetNames(typeof(RaymarchRenderer.Shape)).Length;

        vector12[] dimensions = new vector12[len];

        //sphere
        dimensions[0] = new vector12(SphereDimensions.radius, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //torus
        dimensions[1] = new vector12(TorusDimensions.thickness.x, TorusDimensions.thickness.y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //capped torus
        dimensions[2] = new vector12(CappedTorusDimensions.ro, CappedTorusDimensions.ri, CappedTorusDimensions.thickness.x, CappedTorusDimensions.thickness.y, 0, 0, 0, 0, 0, 0, 0, 0);

        //link
        dimensions[3] = new vector12(LinkDimensions.separation, LinkDimensions.radius, LinkDimensions.thickness, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //cone
        dimensions[4] = new vector12(ConeDimensions.tan.x, ConeDimensions.tan.y, ConeDimensions.height, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //infinite cone
        dimensions[5] = new vector12(InfiniteConeDimensions.tan.x, InfiniteConeDimensions.tan.y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //plane
        dimensions[6] = new vector12(PlaneDimensions.normal.x, PlaneDimensions.normal.y, PlaneDimensions.normal.z, PlaneDimensions.distance, 0, 0, 0, 0, 0, 0, 0, 0);

        //hexagonal prism
        dimensions[7] = new vector12(HexagonalPrismDimensions.h.x, HexagonalPrismDimensions.h.y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //triangular prism
        dimensions[8] = new vector12(TriangularPrismDimensions.h.x, TriangularPrismDimensions.h.y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //capsule
        dimensions[9] = new vector12(CapsuleDimensions.a.x, CapsuleDimensions.a.y, CapsuleDimensions.a.z, CapsuleDimensions.b.x, CapsuleDimensions.b.y, CapsuleDimensions.b.z, CapsuleDimensions.r, 0, 0, 0, 0, 0);

        //infinite cylinder
        dimensions[10] = new vector12(InfiniteCylinderDimensions.c.x, InfiniteCylinderDimensions.c.y, InfiniteCylinderDimensions.c.z, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //box
        dimensions[11] = new vector12(BoxDimensions.size, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //round box
        dimensions[12] = new vector12(RoundBoxDimensions.size, RoundBoxDimensions.roundFactor, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //rounded cylinder
        dimensions[13] = new vector12(RoundedCylinderDimensions.ra, RoundedCylinderDimensions.rb, RoundedCylinderDimensions.h, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //capped cone
        dimensions[14] = new vector12(CappedConeDimensions.h, CappedConeDimensions.r1, CappedConeDimensions.r2, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //box frame
        dimensions[15] = new vector12(BoxFrameDimensions.size.x, BoxFrameDimensions.size.y, BoxFrameDimensions.size.z, BoxFrameDimensions.cavity, 0, 0, 0, 0, 0, 0, 0, 0);

        //solid angle
        dimensions[16] = new vector12(SolidAngleDimensions.c.x, SolidAngleDimensions.c.y, SolidAngleDimensions.ra, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //cut sphere
        dimensions[17] = new vector12(CutSphereDimensions.r, CutSphereDimensions.h, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //hollow sphere
        dimensions[18] = new vector12(HollowSphereDimensions.r, HollowSphereDimensions.h, HollowSphereDimensions.t, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //death star
        dimensions[19] = new vector12(DeathStarDimensions.ra, DeathStarDimensions.rb, DeathStarDimensions.d, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //round cone
        dimensions[20] = new vector12(RoundConeDimensions.r1, RoundConeDimensions.r2, RoundConeDimensions.h, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //ellipsoid
        dimensions[21] = new vector12(EllipsoidDimensions.Radius.x, EllipsoidDimensions.Radius.y, EllipsoidDimensions.Radius.z, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //rhombus
        dimensions[22] = new vector12(RhombusDimensions.la, RhombusDimensions.lb, RhombusDimensions.h, RhombusDimensions.ra, 0, 0, 0, 0, 0, 0, 0, 0);

        //octahedron
        dimensions[23] = new vector12(OctahedronDimensions.size, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //pyramid
        dimensions[24] = new vector12(PyramidDimensions.size, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //triangle
        dimensions[25] = new vector12(TriangleDimensions.sideA.x, TriangleDimensions.sideA.y, TriangleDimensions.sideA.z, TriangleDimensions.sideB.x, TriangleDimensions.sideB.y, TriangleDimensions.sideB.z, TriangleDimensions.sideC.x, TriangleDimensions.sideC.y, TriangleDimensions.sideC.z, 0, 0, 0);

        //quad
        dimensions[26] = new vector12(QuadDimensions.sideA.x, QuadDimensions.sideA.y, QuadDimensions.sideA.z, QuadDimensions.sideB.x, QuadDimensions.sideB.y, QuadDimensions.sideB.z, QuadDimensions.sideC.x, QuadDimensions.sideC.y, QuadDimensions.sideC.z, QuadDimensions.sideD.x, QuadDimensions.sideD.y, QuadDimensions.sideD.z);

        //fractals
        dimensions[27] = new vector12(FractalDimenisons.i, FractalDimenisons.s, FractalDimenisons.o, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //tesseract
        dimensions[28] = new vector12(TesseractDimensions.size.x, TesseractDimensions.size.y, TesseractDimensions.size.z, TesseractDimensions.size.w, 0, 0, 0, 0, 0, 0, 0, 0);

        return dimensions[i];
    }
    public static float[] GetDimensionArray(int i)
    {
        int len = Enum.GetNames(typeof(RaymarchRenderer.Shape)).Length;

        float[][] dimensions = new float[len][];

        //sphere
        dimensions[0] = new float[] { .5f };

        //torus
        dimensions[1] = new float[] { .25f, .5f };

        //capped torus
        dimensions[2] = new float[] { .5f, .1f, .25f, .25f };

        //link
        dimensions[3] = new float[] { .13f, .2f, .09f };

        //cone
        dimensions[4] = new float[] { .25f, .25f, .5f };

        //infinte cone
        dimensions[5] = new float[] { .25f, .25f };

        //plane
        dimensions[6] = new float[] { 0, 1, 0, .25f };

        //hexagonal prism
        dimensions[7] = new float[] { .25f, .25f };

        //triangular prism
        dimensions[8] = new float[] { .25f, .25f };

        //capsule
        dimensions[9] = new float[] { .25f, .25f, .25f, .3f, .3f, .3f, .2f };

        //infinite cylinder
        dimensions[10] = new float[] { 1, 1, 1 };

        //box
        dimensions[11] = new float[] { .5f };

        //round box
        dimensions[12] = new float[] { .5f, .1f };

        //rounded cylinder
        dimensions[13] = new float[] { .5f, .1f, .5f };

        //capped cone
        dimensions[14] = new float[] { .5f, .5f, .1f };

        //box frame
        dimensions[15] = new float[] { .5f, .3f };

        //solid angle
        dimensions[16] = new float[] { .25f, .25f, .5f };

        //cut sphere
        dimensions[17] = new float[] { .5f, .1f };

        //hollow sphere
        dimensions[18] = new float[] { .5f, .5f, .1f };

        //death star
        dimensions[19] = new float[] { .5f, .35f, .5f };

        //round cone
        dimensions[20] = new float[] { .4f, .2f, .1f };

        //ellipsoid
        dimensions[21] = new float[] { .18f, .3f, .02f };

        //rhombus
        dimensions[22] = new float[] { .6f, .2f, .02f, .02f };

        //octahedron
        dimensions[23] = new float[] { .5f };

        //pyramid
        dimensions[24] = new float[] { .5f };

        //triangle
        dimensions[25] = new float[] { .1f, .1f, .1f, .2f, .2f, .2f, .3f, .3f, .3f };

        //quad
        dimensions[26] = new float[] { .1f, .1f, .1f, .2f, .2f, .2f, .3f, .3f, .3f, .4f, .4f, .4f };

        return dimensions[i];
    }
}
