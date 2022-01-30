using System;
using UnityEngine;

public class Helpers : MonoBehaviour
{
    public static vector12 GetDimensionVectors(int i)
    {
        int len = Enum.GetNames(typeof(RaymarchRenderer.Shape)).Length;

        vector12[] dimensions = new vector12[len];

        //sphere
        dimensions[0] = new vector12(.5f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //torus
        dimensions[1] = new vector12(.25f, .5f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //capped torus
        dimensions[2] = new vector12(.5f, .1f, .25f, .25f, 0, 0, 0, 0, 0, 0, 0, 0);

        //link
        dimensions[3] = new vector12(.13f, .2f, .09f, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //cone
        dimensions[4] = new vector12(.25f, .25f, .5f, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //infinite cone
        dimensions[5] = new vector12(.25f, .25f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //plane
        dimensions[6] = new vector12(0, 1, 0, .25f, 0, 0, 0, 0, 0, 0, 0, 0);

        //hexagonal prism
        dimensions[7] = new vector12(.25f, .25f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //triangular prism
        dimensions[8] = new vector12(.25f, .25f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //capsule
        dimensions[9] = new vector12(0, 1, 0, .25f, 0, 0, 0, 0, 0, 0, 0, 0);

        //infinite cylinder
        dimensions[10] = new vector12(1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //box
        dimensions[11] = new vector12(.5f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //round box
        dimensions[12] = new vector12(.5f, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //rounded cylinder
        dimensions[13] = new vector12(.5f, .1f, .5f, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //capped cone
        dimensions[14] = new vector12(.5f, .5f, .1f, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //box frame
        dimensions[15] = new vector12(.5f, .3f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //solid angle
        dimensions[16] = new vector12(.25f, .25f, .5f, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //cut sphere
        dimensions[17] = new vector12(.5f, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //hollow sphere
        dimensions[18] = new vector12(.5f, .5f, .1f, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //death star
        dimensions[19] = new vector12(.5f, .35f, .5f, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //round cone
        dimensions[20] = new vector12(.4f, .2f, .1f, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //ellipsoid
        dimensions[21] = new vector12(.18f, .3f, .02f, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //rhombus
        dimensions[22] = new vector12(.6f, .2f, .02f, .02f, 0, 0, 0, 0, 0, 0, 0, 0);

        //octahedron
        dimensions[23] = new vector12(.5f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //pyramid
        dimensions[24] = new vector12(.5f, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);

        //triangle
        dimensions[25] = new vector12(.1f, .1f, .1f, .2f, .2f, .2f, .3f, .3f, .3f, 0, 0, 0);

        //quad
        dimensions[26] = new vector12(.1f, .1f, .1f, .2f, .2f, .2f, .3f, .3f, .3f, .4f, .4f, .4f);

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
        dimensions[13] = new float[] { .5f, .1f, .5f};

        //capped cone
        dimensions[14] = new float[] { .5f, .5f, .1f};

        //box frame
        dimensions[15] = new float[] { .5f, .3f};

        //solid angle
        dimensions[16] = new float[] { .25f, .25f, .5f};

        //cut sphere
        dimensions[17] = new float[] { .5f, .1f};

        //hollow sphere
        dimensions[18] = new float[] { .5f, .5f, .1f};

        //death star
        dimensions[19] = new float[] { .5f, .35f, .5f };

        //round cone
        dimensions[20] = new float[] { .4f, .2f, .1f };

        //ellipsoid
        dimensions[21] = new float[] { .18f, .3f, .02f };

        //rhombus
        dimensions[22] = new float[] { .6f, .2f, .02f, .02f};

        //octahedron
        dimensions[23] = new float[] { .5f};

        //pyramid
        dimensions[24] = new float[] { .5f};

        //triangle
        dimensions[25] = new float[] { .1f, .1f, .1f, .2f, .2f, .2f, .3f, .3f, .3f};

        //quad
        dimensions[26] = new float[] { .1f, .1f, .1f, .2f, .2f, .2f, .3f, .3f, .3f, .4f, .4f, .4f};
 
        return dimensions[i];
    }
}
