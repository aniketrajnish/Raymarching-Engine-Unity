Shader "Raymarching/Raymarcher"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag            

            #include "UnityCG.cginc"

#define max_steps 100
#define max_dist 100
#define surf_dist 1e-3

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float3 ro : TEXCOORD1;
                float3 hitPos : TEXCOORD2;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            //for vertices
            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                o.ro = mul(unity_WorldToObject, float4(_WorldSpaceCameraPos, 1)); //world space
                o.hitPos = mul(unity_ObjectToWorld, v.vertex);
                //o.hitPos = v.vertex;
                return o;
            }

            float ndot(float2 a, float2 b) {
                return a.x * b.x - a.y * b.y;
            }

            float dot2(float3 f) {
                return dot(f, f);
            }
            
            float GetDist(float3 p) {
                float d;
                //sphere
                d = length(p) - .5f;              

                //box
                float3 q = abs(p) - .25f;
                d = length(max(q, 0)) + min(max(q.x, max(q.y, q.z)), 0);               

                //round box
                q = abs(p) - .25f;
                d = length(max(q, 0)) + min(max(q.x, max(q.y, q.z)), 0) - .1f;

                //box frame
                float3 s = float3(.4f, .4f, .5f);
                p = abs(p) - s;
                q = abs(p + .05f) - .05f;
                d = min(min(
                    length(max(float3(p.x, q.y, q.z), 0)) + min(max(p.x, max(q.y, q.z)), 0),
                    length(max(float3(q.x, p.y, q.z), 0)) + min(max(q.x, max(p.y, q.z)), 0)),
                    length(max(float3(q.x, q.y, p.z), 0)) + min(max(q.x, max(q.y, p.z)), 0));

                //torus
                float2 t = float2(.3f, .25f);
                float2 w = float2(length(p.xz) - t.x, p.y);
                d = length(w) - t.y;

                //capped torus
                p.x = abs(p.x);
                float ro = .5f;
                float ri = .1f;
                float2 ct = float2(.25f, .25f);
                float x = (ct.y * p.x > ct.x * p.y) ? dot(p.xy, ct) : length(p.xy);
                d = sqrt(dot(p, p) + ro * ro - 2 * ro * x) - ri;

                //link
                float ls = .125f;
                q = float3(p.x, max(abs(p.y) - ls, 0), p.z);
                d = length(float2(length(q.xy) - ro, q.z)) - ri;

                //infinite cylinder
                float3 c = float3(.025f, .025f, .025f);
                d = length(p.xz - c.xy) - c.z;

                //cone
                float ch = .25f;
                float2 cc = float2(.25f, .25f);
                float2 cq = ch * float2(cc.x / cc.y, -1);
                
                float2 cw = float2(length(p.xz), p.y);
                float2 ca = cw - cq * clamp(dot(cw, cq) / dot(cq, cq), 0, 1);
                float2 cb = cw - cq * float2(clamp(cw.x / cq.x, 0, 1), 1);
                float ck = sign(cq.y);
                float cd = min(dot(ca, ca), dot(cb, cb));
                float cs = max(ck * (cw.x * cq.y - cw.y * cq.x), ck * (cw.y - cq.y));
                d = sqrt(cd) * sign(cs);

                //bound cone
                float cbq = length(p.xz);
                float cbh = .5f;
                float2 cbc = float2(.25f, .25f);
                d = max(dot(cbc.xy, float2(cbq, p.y)), -cbh - p.y);

                //infinite cone
                float2 icc = float2(.25f, .25f);
                float2 icq = float2(length(p.xz), -p.y);
                float icd = length(icq - icc * max(dot(icq, icc), 0));
                d = icd * ((icq.x * icc.y - icq.y * icc.x < 0) ? -1 : 1);

                //plane
                float h = .25f;
                float3 pn = float3(0, 1, 0);
                d = dot(p, pn) + h;

                //hexagonal prism
                const float3 hpk = float3(-0.8660254, 0.5, 0.57735);
                float2 hph = float2(.25f, .25f);
                p = abs(p);
                p.xy -= 2 * min(dot(hpk.xy, p.xy), 0) * hpk.xy;
                float2 hpd = float2(length(p.xy - float2(clamp(p.x, -hpk.z * hph.x, hpk.z * hph.x), hph.x)) * sign(p.y - hph.x), p.z - hph.y);
                d = min(max(hpd.x, hpd.y), 0) + length(max(d, 0));

                //triangular prism
                float3 tpq = abs(p);
                float2 tph = float2(.5f, .5f);
                d = max(tpq.z - tph.y, max(tpq.x * 0.866025 + p.y * 0.5, -p.y) -tph.x * 0.5);

                //capsule
                float3 cro = float3(.5f, .5f, .5f);
                float3 cri = float3(.1f, .1f, .1f);
                float r = .25f;

                float3 pa = p - cro;
                float3 ba = cro - cri;

                h = clamp(dot(pa, ba) / dot(ba, ba), 0, 1);
                d = length(pa - ba * h) - r;

                //line capsule
                r = .1f;
                p.y -= clamp(p.y, 0, h);
                d = length(p) - r;

                //capped cylinder
                h = .25f;                
                float2 ccd = abs(float2(length(p.xz), p.y)) - float2(h, r);
                d = min(max(ccd.x, ccd.y), 0) + length(max(ccd, 0));

                //rounded cylinder
                float rcro = .25f;
                float rcrt = .1f;
                float rch = .5f;

                float2 rcd = float2(length(p.xz) - 2 * rcro + rcrt, abs(p.y) - rch);
                d = min(max(rcd.x, rcd.y), 0) + length(max(d, 0)) - rcrt;

                //capped cone
                float ccoh = .5f;
                float ccor1 = .5f;
                float ccor2 = .25f;
                float2 ccoq = float2(length(p.xz), p.z);
                float2 ccok1 = float2(ccor2, ccoh);
                float2 ccok2 = float2(ccor2 - ccor1, 2 * ccoh);
                float2 ccoca = float2(ccoq.x - min(ccoq.x, (ccoq.y < 0) ? ccor1 : ccor2), abs(ccoq.y) - ccoh);
                float2 ccocb = ccoq - ccok1 + ccok2 * clamp(dot(ccok1 - ccoq, ccok2) / dot(ccok2, ccok2), 0, 1);
                float ccos = (ccocb.x < 0 && ccoca.y < 0) ? -1 : 1;
                d = ccos * sqrt(min(dot(ccoca, ccoca), dot(ccocb, ccocb)));

                //solid cone
                float2 scc = float2(.25f, .25f);
                float2 scra = float2(.5f, .5f);
                float2 scq = float2(length(p.xz), p.y);
                float scl = length(scq) - scra;
                float scm = length(scq - scc * clamp(dot(scq, scc), 0, scra));
                d = max(scl, scm * (scc.y * scq.x - scc.x * scq.y));
                
                //cut sphere
                float csr = .5f;
                float csh = .5f;

                float csw = sqrt(csr * csr - csh * csh);
                float2 csq = float2(length(p.xz), p.y);
                float css = max((csh - csr) * csq.x * csq.x + csw * csw * (csh + csr - 2 * csq.y), csh * csq.x - csw * csq.y);
                d = (css < 0) ? length(q) - r : (q.x < w) ? h - q.y : length(q - float2(csw, csh));

                //round cone
                float rcor1 = .1f;
                float rcor2 = .3f;
                float rcoh = .5f;
                float2 rcoq = float2(length(p.xz), p.y);
                float rcob = (rcor1 - rcor2) / rcoh;
                float rcoa = sqrt(1 - rcob * rcob);
                float rcok = dot(rcoq, float2(-rcob, 0));

                if (rcok < 0) d = length(rcoq) - rcor1;
                if (rcok > rcoa * rcoh) d = length(rcoq - float2(0, rcoh)) - rcor2;

                //bound ellipsoid
                float3 ber = float3(.25f, .35f, .45f);
                float bek0 = length(p / ber);
                float bek1 = length(p / (ber * ber));
                d = bek0 * (bek0 - 1) / bek1;

                //rhombus 
                float rla = .25f;
                float rlb = .45f;
                float rh = .5f;
                float rra = .6f;
                p = abs(p);
                float2 rb = float2(rla, rlb);
                float rf = clamp((ndot(rlb, rb - 2 * p.xz)) / dot(rb, rb), -1, 1);
                float2 rq = float2(length(p.xz - .5f * rb * float2(1 - rf, 1 + rf)) * sign(p.x * rb.y + p.z * rb.x - rb.x * rb.y) - rra, p.y - rh);
                d = min(max(rq.x, rq.y), 0) + length(max(rq, 0));

                //octahedron
                float os = .5f;
                p = abs(p);
                float om = p.x + p.y + p.z - os;
                float3 oq;
                if (3 * p.x < om) oq = p.xyz;
                else if (3 * p.y < om) oq = p.yxz;
                else if (3 * p.z < om) oq = p.zxy;
                else return om * 0.57735027;
                float ok = clamp(0.5 * (oq.z - oq.y + os), 0, s);
                d = length(float3(oq.x, oq.y - os + ok, oq.z - ok));

                //bound octahedron
                p = abs(p);
                d = (p.x + p.y + p.z - s) * 0.57735027;

                //pyramid
                float ph = .5f;
                float pm = ph * ph + .25f;

                p.xz = abs(p.xz);
                p.xz = (p.z > p.x) ? p.zx : p.xz;
                p.xz -= .5f;
                
                float3 pq = float3(p.z, ph * p.y - .5f * p.x, ph * p.x + .5f * p.y);
                float ps = max(-pq.x, 0);
                float pt = clamp((pq.y - .5f * p.z) / (pm + .25f), 0, 1);
                float pya = pm * (pq.x + ps) * (pq.x + ps) + pq.y * pq.y;
                float pb = pm * (pq.x + .5f * pt) * (pq.x + .5f * pt) + (pq.y - pm * t) * (pq.y - pm * t);

                float pd = min(pq.y, -pq.x * pm - pq.y * .5f) > 0 ? 0 : min(pya, pb);
                d = sqrt((pd + pq.z * pq.z) / pm) * sign(max(pq.z, -p.y));

                //triangle
                float3 ta = float3(.25f, .25f, .25f);
                float3 tb = float3(.25f, -.25f, -.25f);
                float3 tc = float3(-.25f, .25f, .25f);

                float3 tba = tb - ta;
                float3 tpa = p - ta;
                float3 tcb = tc - tb;
                float3 tpb = p - tb;
                float3 tac = ta - tc;
                float3 tpc = p - tc;
                float3 nor = cross(tba, tac);

                d = sqrt((sign(dot(cross(tba, nor), tpa)) + sign(dot(cross(tcb, nor), tpb)) + sign(dot(cross(tac, nor), tpc)) < 2) ?
                    min(min(
                        dot2(tba * clamp(dot(tba, tpa) / dot2(tba), 0, 1) - tpa),
                        dot2(tcb * clamp(dot(tcb, tpb) / dot2(tcb), 0, 1) - tpb)),
                        dot2(tac * clamp(dot(tac, tpc) / dot2(tac), 0, 1) - tpc))
                    :
                    dot(nor, tpa) * dot(nor, tpa) / dot2(nor));

                //quad
                float3 qua = float3(.35f, .45f, .65f);
                float3 qub = float3(-.35f, .45f, .65f);
                float3 quc = float3(.35f, -.45f, .65f);
                float3 qud = float3(.35f, .45f, -.65f);

                float3 quba = qub - qua;
                float3 qupa = p - qua;
                float3 qucb = quc - qub;
                float3 qupb = p - qub;
                float3 qudc = qud - quc;
                float3 qupc = p - quc;
                float3 quad = qua - qud;
                float3 qupd = p - qud;
                nor = cross(quba, quad);

                d = sqrt(
                    sign(dot(cross(quba, nor), qupa)) +
                    sign(dot(cross(qucb, nor), qupb)) +
                    sign(dot(cross(qudc, nor), qupc)) +
                    sign(dot(cross(quad, nor), qupd)) < 3)
                    ?
                    min(min(min(
                        dot2(quba * clamp(dot(quba, qupa) / dot2(quba), 0, 1) - qupa),
                        dot2(qucb * clamp(dot(qucb, qupb) / dot2(qucb), 0, 1) - qupb)),
                        dot2(qudc * clamp(dot(qudc, qupc) / dot2(qudc), 0, 1) - qupc)),
                        dot2(quad * clamp(dot(quad, qupd) / dot2(quad), 0, 1) - qupd))
                    :
                    dot(nor, qupa) * dot(nor, qupa) / dot2(nor);

                return d;
            }


            float Raymarch(float3 ro, float3 rd) {
                float d_origin = 0;
                float d_scene = 0;

                for (int i = 0; i < max_steps; i++) {
                    float3 p = ro + d_origin * rd;
                    d_scene = GetDist(p);
                    d_origin += d_scene;

                    if (d_scene < surf_dist || d_origin > max_dist) break;
                }

                return d_origin;
            }

            float3 GetNormal(float3 p) {
                float2 e = float2(1e-2, 0);
                float3 n = GetDist(p) - float3(GetDist(p - e.xyy), GetDist(p - e.yxy), GetDist(p - e.yyx));
                return normalize(n);
            }

            //for pixels
            fixed4 frag(v2f i) : SV_Target
            {
                // sample the texture
                float2 uv = i.uv - .5f;
                float3 ro = i.ro;
                float3 rd = i.hitPos - ro;
                rd = normalize(rd);

                //fixed4 tex = tex2D(_MainTex, i.uv);
                fixed4 col = 0;
                //col.rgb = ray_direction;

                float d = Raymarch(ro, rd);

                float mask = dot(uv, uv);

                if (d < max_dist) {
                    //col.r = 1;
                    float3 p = ro + rd * d;
                    float3 n = GetNormal(p);
                    col.rgb = n;
                }
 
;
                return col;
            }
            ENDCG
        }
    }
}
