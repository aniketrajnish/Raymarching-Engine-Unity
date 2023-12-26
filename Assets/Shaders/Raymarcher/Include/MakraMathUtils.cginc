float ndot(float2 a, float2 b)
{
    return a.x * b.x - a.y * b.y;
}

float dot2(float3 f)
{
    return dot(f, f);
}
			
float dot2(float2 f)
{
    return dot(f, f);
}

float sdUnion(float d1, float d2)
{
    return min(d1, d2);
}

float sdIntersection(float d1, float d2)
{
    return max(d1, d2);
}

float sdSubtraction(float d1, float d2)
{
    return max(-d1, d2);
}

float sdFMod(inout float p, float s)
{
    float h = s * .5f;
    float c = floor((p + h) / s);
    p = fmod(p + h, s) - h;
    p = fmod(-p + h, s) - h;
    return c;
}

float3 normalizeF3(float3 f)
{
    return (f * 0.5) + 0.5;
}