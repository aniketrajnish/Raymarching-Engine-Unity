Shader "Raymarching/Raymarcher"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
	}
		SubShader
	{
		Tags { "RenderType" = "Opaque"  }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag   
			
			#include "UnityCG.cginc"
            #include"DFs.cginc"

            #define max_steps 100
            #define max_dist 100
            #define surf_dist 1e-3
            #define anti_aliasing 3
            
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

			struct vector12 {
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
			};

			struct Shape 
			{	
				float3 col;
				int shapeIndex;
				vector12 dimensions;
			};			

			StructuredBuffer<Shape> shapes;			

			sampler2D _MainTex;
			float4 _MainTex_ST;

			//for vertices
			v2f vert(appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.ro = mul(unity_WorldToObject, float4(_WorldSpaceCameraPos, 1)); //world space
				o.hitPos = mul(unity_ObjectToWorld, v.vertex);
				//o.hitPos = v.vertex;
				return o;
			}						

			float GetDist(Shape shape, float3 p) {				

				switch (shape.shapeIndex) {
				case 0:
					return sdSphere(p, shape.dimensions.a);
				case 1:
					return sdTorus(p, float2(shape.dimensions.a, shape.dimensions.b));
				case 2:
					return sdCappedTorus(p, shape.dimensions.a, shape.dimensions.b, shape.dimensions.c);
				case 3:
					return sdLink(p, shape.dimensions.a, shape.dimensions.b, shape.dimensions.c);
				case 4:
					return sdCone(p, shape.dimensions.a, shape.dimensions.b);
				case 5:
					return sdInfCone(p, shape.dimensions.a);
				case 6:
					return sdPlane(p, shape.dimensions.a, shape.dimensions.b);
				case 7:
					return sdHexPrism(p, float2(shape.dimensions.a, shape.dimensions.b));
				case 8:
					return sdTriPrism(p, float2(shape.dimensions.a, shape.dimensions.b));
				case 9:
					return sdCapsule(p, float3(shape.dimensions.a, shape.dimensions.b, shape.dimensions.c),
						float3(shape.dimensions.d, shape.dimensions.e, shape.dimensions.f),
						shape.dimensions.g);
				case 10:
					return sdInfiniteCylinder(p, float3(shape.dimensions.a, shape.dimensions.b, shape.dimensions.c));						
				case 11:
					return sdBox(p, shape.dimensions.a);
				case 12:
					return sdRoundBox(p, shape.dimensions.a, shape.dimensions.b);
				case 13:
					return sdRoundedCylinder(p, shape.dimensions.a, shape.dimensions.b, shape.dimensions.c);
				case 14:
					return sdCappedCone(p, shape.dimensions.a, shape.dimensions.b, shape.dimensions.c);
				case 15:
					return sdBoxFrame(p, float3(shape.dimensions.a, shape.dimensions.b, shape.dimensions.c), shape.dimensions.d);
				case 16:
					return sdSolidAngle(p, float2(shape.dimensions.a, shape.dimensions.b), shape.dimensions.c);
				case 17:
					return sdCutSphere(p, shape.dimensions.a, shape.dimensions.b);
				case 18:
					return sdCutHollowSphere(p, shape.dimensions.a, shape.dimensions.b, shape.dimensions.c);
				case 19:
					return sdDeathStar(p, shape.dimensions.a, shape.dimensions.b, shape.dimensions.c);
				case 20:
					return sdRoundCone(p, shape.dimensions.a, shape.dimensions.b, shape.dimensions.c);
				case 21:
					return sdEllipsoid(p, float3(shape.dimensions.a, shape.dimensions.b, shape.dimensions.c));
				case 22:
					return sdRhombus(p, shape.dimensions.a, shape.dimensions.b, shape.dimensions.c, shape.dimensions.d);
				case 23:
					return sdOctahedron(p, shape.dimensions.a);
				case 24:
					return sdPyramid(p, shape.dimensions.a);
				case 25:
					return udTriangle(p, float3(shape.dimensions.a, shape.dimensions.b, shape.dimensions.c),
						float3(shape.dimensions.d, shape.dimensions.e, shape.dimensions.f),
						float3(shape.dimensions.g, shape.dimensions.h, shape.dimensions.i));
				case 26:
					return udQuad(p, float3(shape.dimensions.a, shape.dimensions.b, shape.dimensions.c),
						float3(shape.dimensions.d, shape.dimensions.e, shape.dimensions.f),
						float3(shape.dimensions.g, shape.dimensions.h, shape.dimensions.i),
						float3(shape.dimensions.j, shape.dimensions.k, shape.dimensions.l));
				}
				
				float d;
				d = 0;
				return d;
			
			}			

			float Raymarch(float3 ro, float3 rd) {
				float d_origin = 0;
				float d_scene = 0;
				Shape _shape = shapes[0];

				for (int i = 0; i < max_steps; i++) {
					float3 p = ro + d_origin * rd;
					d_scene = GetDist(_shape, p);
					d_origin += d_scene;

					if (d_scene < surf_dist || d_origin > max_dist) break;
				}

				return d_origin;
			}

			float3 GetNormal(float3 p) {
				Shape _shape = shapes[0];
				float2 e = float2(1e-2, 0);
				float3 n = GetDist(_shape, p) - float3(GetDist(_shape, p - e.xyy), GetDist(_shape, p - e.yxy), GetDist(_shape, p - e.yyx));
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

				else
					discard;

;
				return col;
			}
			ENDCG
		}
	}

}
