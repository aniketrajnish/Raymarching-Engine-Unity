using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Raymarcher : MonoBehaviour
{
    List<ComputeBuffer> disposable = new List<ComputeBuffer>();
    List<RaymarchRenderer> renderers;
    ComputeBuffer shapeBuffer;
   
    

    [SerializeField] Material raymarchMaterial;

    private void Update()
    {
        RaymarchRender();
    }
    private void OnDisable()
    {
        foreach (var buffer in disposable)
        {
            buffer.Dispose();
        }
    }
    void RaymarchRender()
    {
        renderers = new List<RaymarchRenderer>(FindObjectsOfType<RaymarchRenderer>());
       
        //int len = Enum.GetNames(typeof(RaymarchRenderer.Shape)).Length;
        Properties[] properties = new Properties[renderers.Count];

        for (int i = 0; i < renderers.Count; i++)
        {
            //yaha pe index nikal rha
            var s = renderers[i];
            //print((int)s.shape);
            Vector3 color = new Vector3(s.color.r, s.color.g, s.color.b);
            Properties p = new Properties()
            {
                col = color,
                shapeIndex = (int)s.shape,
                dimensions = Helpers.GetDimensionVectors((int)s.shape)
            };
            
            properties[i] = p;
        }
        
        shapeBuffer = new ComputeBuffer(renderers.Count, 64);
        shapeBuffer.SetData(properties);
        
        raymarchMaterial.SetBuffer("shapes", shapeBuffer);
        disposable.Add(shapeBuffer);
    }
    
    
}
public struct Properties
{
    public Vector3 col;
    public int shapeIndex;
    public vector12 dimensions;
}
public struct vector12
{
    float a;
    float b;
    float c;
    float d;
    float e;
    float f;
    float g;
    float h;
    float i;
    float j;
    float k;
    float l;

    public vector12(float _a, float _b, float _c, float _d, float _e, float _f, float _g, float _h, float _i, float _j, float _k, float _l)
    {
        this.a = _a;
        this.b = _b;
        this.c = _c;
        this.d = _d;
        this.e = _e;
        this.f = _f;
        this.g = _g;
        this.h = _h;
        this.i = _i;
        this.j = _j;
        this.k = _k;
        this.l = _l;
    }
}

