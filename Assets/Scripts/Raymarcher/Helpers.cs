using System;
using UnityEngine;
public class Helpers : MonoBehaviour
{
    public static vector12 GetDimensionVectors(int i, ShapeDimensions shapeDimensions)
    {
        int len = Enum.GetNames(typeof(RaymarchRenderer.Shape)).Length;

        vector12[] dimensions = new vector12[len];

        if (shapeDimensions == null)
            return new vector12(0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0); ;

        //sphere
        dimensions[0] = new vector12(shapeDimensions.sphereRadius, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //torus
        dimensions[1] = new vector12(shapeDimensions.torusThickness.x, shapeDimensions.torusThickness.y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //capped torus
        dimensions[2] = new vector12(shapeDimensions.cappedTorusRo, shapeDimensions.cappedTorusRi, shapeDimensions.cappedTorusThickness.x, shapeDimensions.cappedTorusThickness.y, 0, 0, 0, 0, 0, 0, 0, 0);

        //link
        dimensions[3] = new vector12(shapeDimensions.linkSeparation, shapeDimensions.linkRadius, shapeDimensions.linkThickness, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //cone
        dimensions[4] = new vector12(shapeDimensions.coneTan.x, shapeDimensions.coneTan.y, shapeDimensions.coneHeight, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //infinite cone
        dimensions[5] = new vector12(shapeDimensions.infConeTan.x, shapeDimensions.infConeTan.y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //plane
        dimensions[6] = new vector12(shapeDimensions.planeNormal.x, shapeDimensions.planeNormal.y, shapeDimensions.planeNormal.z, shapeDimensions.planeDistance, 0, 0, 0, 0, 0, 0, 0, 0);

        //hexagonal prism
        dimensions[7] = new vector12(shapeDimensions.hexPrismH.x, shapeDimensions.hexPrismH.y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //triangular prism
        dimensions[8] = new vector12(shapeDimensions.triPrismH.x, shapeDimensions.triPrismH.y, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //capsule
        dimensions[9] = new vector12(shapeDimensions.capsuleA.x, shapeDimensions.capsuleA.y, shapeDimensions.capsuleA.z, shapeDimensions.capsuleB.x, shapeDimensions.capsuleB.y, shapeDimensions.capsuleB.z, shapeDimensions.capsuleR, 0, 0, 0, 0, 0);

        //infinite cylinder
        dimensions[10] = new vector12(shapeDimensions.infCylC.x, shapeDimensions.infCylC.y, shapeDimensions.infCylC.z, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //box
        dimensions[11] = new vector12(shapeDimensions.boxSize, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //round box
        dimensions[12] = new vector12(shapeDimensions.roundBoxSize, shapeDimensions.roundBoxRoundFactor, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //rounded cylinder
        dimensions[13] = new vector12(shapeDimensions.roundCylRa, shapeDimensions.roundCylRb, shapeDimensions.roundCylH, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //capped cone
        dimensions[14] = new vector12(shapeDimensions.capConeH, shapeDimensions.capConeR1, shapeDimensions.capConeR2, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //box frame
        dimensions[15] = new vector12(shapeDimensions.boxFrameSize.x, shapeDimensions.boxFrameSize.y, shapeDimensions.boxFrameSize.z, shapeDimensions.boxFrameCavity, 0, 0, 0, 0, 0, 0, 0, 0);

        //solid angle
        dimensions[16] = new vector12(shapeDimensions.solidAngleC.x, shapeDimensions.solidAngleC.y, shapeDimensions.solidAngleRa, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //cut sphere
        dimensions[17] = new vector12(shapeDimensions.cutSphereR, shapeDimensions.cutSphereH, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //hollow sphere
        dimensions[18] = new vector12(shapeDimensions.hollowSphereR, shapeDimensions.hollowSphereH, shapeDimensions.hollowSphereT, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //death star
        dimensions[19] = new vector12(shapeDimensions.deathStarRa, shapeDimensions.deathStarRb, shapeDimensions.deathStarD, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //round cone
        dimensions[20] = new vector12(shapeDimensions.roundConeR1, shapeDimensions.roundConeR2, shapeDimensions.roundConeH, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //ellipsoid
        dimensions[21] = new vector12(shapeDimensions.ellipsoidRadius.x, shapeDimensions.ellipsoidRadius.y, shapeDimensions.ellipsoidRadius.z, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //rhombus
        dimensions[22] = new vector12(shapeDimensions.rhombusLa, shapeDimensions.rhombusLb, shapeDimensions.rhombusH, shapeDimensions.rhombusRa, 0, 0, 0, 0, 0, 0, 0, 0);

        //octahedron
        dimensions[23] = new vector12(shapeDimensions.octahedronSize, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //pyramid
        dimensions[24] = new vector12(shapeDimensions.pyramidSize, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //triangle
        dimensions[25] = new vector12(shapeDimensions.triangleSideA.x, shapeDimensions.triangleSideA.y, shapeDimensions.triangleSideA.z, shapeDimensions.triangleSideB.x, shapeDimensions.triangleSideB.y, shapeDimensions.triangleSideB.z, shapeDimensions.triangleSideC.x, shapeDimensions.triangleSideC.y, shapeDimensions.triangleSideC.z, 0, 0, 0);

        //quad
        dimensions[26] = new vector12(shapeDimensions.quadSideA.x, shapeDimensions.quadSideA.y, shapeDimensions.quadSideA.z, shapeDimensions.quadSideB.x, shapeDimensions.quadSideB.y, shapeDimensions.quadSideB.z, shapeDimensions.quadSideC.x, shapeDimensions.quadSideC.y, shapeDimensions.quadSideC.z, shapeDimensions.quadSideD.x, shapeDimensions.quadSideD.y, shapeDimensions.quadSideD.z);

        //fractals
        dimensions[27] = new vector12(shapeDimensions.fractalI, shapeDimensions.fractalS, shapeDimensions.fractalO, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //tesseract
        dimensions[28] = new vector12(shapeDimensions.tesseractSize.x, shapeDimensions.tesseractSize.y, shapeDimensions.tesseractSize.z, shapeDimensions.tesseractSize.w, 0, 0, 0, 0, 0, 0, 0, 0);

        return dimensions[i];
    }
    /*public static float[] GetDimensionArray(int i)
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
    }*/
}