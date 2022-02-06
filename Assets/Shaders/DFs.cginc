float ndot(float2 a, float2 b) {
				return a.x * b.x - a.y * b.y;
			}

			float dot2(float3 f) {
				return dot(f, f);
			}

			float dot2(float2 f) {
				return dot(f, f);
			}

			//sphere
			float sdSphere(float3 p, float r) {
				return length(p) - r;
			}

			//torus
			float sdTorus(float3 p, float2 s) {
				float2 w = float2(length(p.xz) - s.x, p.y);
				return length(w) - s.y;
			}

			//capped torus
			float sdCappedTorus(float3 p, float ro, float ri, float2 t) {
				p.x = abs(p.x);
				float x = (t.y * p.x > t.x * p.y) ? dot(p.xy, t) : length(p.xy);
				return sqrt(dot(p, p) + ro * ro - 2 * ro * x) - ri;
			}

			//link
			float sdLink(float3 p, float s, float ro, float ri) {
				float3 q = float3(p.x, max(abs(p.y) - s, 0), p.z);
				return length(float2(length(q.xy) - ro, q.z)) - ri;
			}

			//cone
			float sdCone(float3 p, float2 c, float h)
			{
				float2 q = h * float2(c.x / c.y, -1.0);

				float2 w = float2(length(p.xz), p.y);
				float2 a = w - q * clamp(dot(w, q) / dot(q, q), 0.0, 1.0);
				float2 b = w - q * float2(clamp(w.x / q.x, 0.0, 1.0), 1.0);
				float k = sign(q.y);
				float d = min(dot(a, a), dot(b, b));
				float s = max(k * (w.x * q.y - w.y * q.x), k * (w.y - q.y));
				return sqrt(d) * sign(s);
			}

			//infinite cone
			float sdInfCone(float3 p, float2 c) {
				float2 q = float2(length(p.xz), -p.y);
				float d = length(q - c * max(dot(q, c), 0));
				return d * ((q.x * c.y - q.y * c.x < 0) ? -1 : 1);
			}

			//plane
			float sdPlane(float3 p, float3 n, float h) {
				return dot(p, n) + h;
			}

			//hexagonal prism
			float sdHexPrism(float3 p, float2 h)
			{
				const float3 k = float3(-0.8660254, 0.5, 0.57735);
				p = abs(p);
				p.xy -= 2.0 * min(dot(k.xy, p.xy), 0.0) * k.xy;
				float2 d = float2(
					length(p.xy - float2(clamp(p.x, -k.z * h.x, k.z * h.x), h.x)) * sign(p.y - h.x),
					p.z - h.y);
				return min(max(d.x, d.y), 0.0) + length(max(d, 0.0));
			}

			//triangular prism
			float sdTriPrism(float3 p, float2 h)
			{
				float3 q = abs(p);
				return max(q.z - h.y, max(q.x * 0.866025 + p.y * 0.5, -p.y) - h.x * 0.5);
			}

			//capsule
			float sdCapsule(float3 p, float3 a, float3 b, float r)
			{
				float3 pa = p - a, ba = b - a;
				float h = clamp(dot(pa, ba) / dot(ba, ba), 0.0, 1.0);
				return length(pa - ba * h) - r;
			}

			//infinite cylinder
			float sdInfiniteCylinder(float3 p, float3 c) {
				return length(p.xz - c.xy) - c.z;
			}


			//box
			float sdBox(float3 p, float s) {
				float3 q = abs(p) - s;
				return length(max(q, 0)) + min(max(q.x, max(q.y, q.z)), 0);
			}

			//round box 
			float sdRoundBox(float3 p, float s, float t) {
				float3 q = abs(p) - s;
				return length(max(q, 0.0)) + min(max(q.x, max(q.y, q.z)), 0.0) - t;
			}


			//rounded cylinder
			float sdRoundedCylinder(float3 p, float ra, float rb, float h)
			{
				float2 d = float2(length(p.xz) - 2.0 * ra + rb, abs(p.y) - h);
				return min(max(d.x, d.y), 0.0) + length(max(d, 0.0)) - rb;
			}

			//capped cone
			float sdCappedCone(float3 p, float h, float r1, float r2)
			{
				float2 q = float2(length(p.xz), p.y);
				float2 k1 = float2(r2, h);
				float2 k2 = float2(r2 - r1, 2.0 * h);
				float2 ca = float2(q.x - min(q.x, (q.y < 0.0) ? r1 : r2), abs(q.y) - h);
				float2 cb = q - k1 + k2 * clamp(dot(k1 - q, k2) / dot2(k2), 0.0, 1.0);
				float s = (cb.x < 0.0 && ca.y < 0.0) ? -1.0 : 1.0;
				return s * sqrt(min(dot2(ca), dot2(cb)));
			}

			//box frame
			float sdBoxFrame(float3 p, float3 s, float t) {
				p = abs(p) - s;
				float3 q = abs(p + t) - t;
				return min(min(
					length(max(float3(p.x, q.y, q.z), 0.0)) + min(max(p.x, max(q.y, q.z)), 0.0),
					length(max(float3(q.x, p.y, q.z), 0.0)) + min(max(q.x, max(p.y, q.z)), 0.0)),
					length(max(float3(q.x, q.y, p.z), 0.0)) + min(max(q.x, max(q.y, p.z)), 0.0));
			}

			//solid angle
			float sdSolidAngle(float3 p, float2 c, float ra)
			{
				float2 q = float2(length(p.xz), p.y);
				float l = length(q) - ra;
				float m = length(q - c * clamp(dot(q, c), 0.0, ra));
				return max(l, m * sign(c.y * q.x - c.x * q.y));
			}

			//cut sphere
			float sdCutSphere(float3 p, float r, float h)
			{
				float w = sqrt(r * r - h * h);

				float2 q = float2(length(p.xz), p.y);
				float s = max((h - r) * q.x * q.x + w * w * (h + r - 2.0 * q.y), h * q.x - w * q.y);
				return (s < 0.0) ? length(q) - r :
					(q.x < w) ? h - q.y :
					length(q - float2(w, h));
			}

			//cut hollow sphere
			float sdCutHollowSphere(float3 p, float r, float h, float t)
			{
				float w = sqrt(r * r - h * h);
				float2 q = float2(length(p.xz), p.y);
				return ((h * q.x < w* q.y) ? length(q - float2(w, h)) :
					abs(length(q) - r)) - t;
			}

			//death star
			float sdDeathStar(float3 p, float ra, float rb, float d)
			{
				float a = (ra * ra - rb * rb + d * d) / (2.0 * d);
				float b = sqrt(max(ra * ra - a * a, 0.0));

				float2 p2 = float2(p.x, length(p.yz));
				if (p2.x * b - p2.y * a > d * max(b - p2.y, 0.0))
					return length(p2 - float2(a, b));
				else
					return max((length(p2) - ra),
						-(length(p2 - float2(d, 0)) - rb));
			}

			//round cone
			float sdRoundCone(float3 p, float r1, float r2, float h)
			{
				float b = (r1 - r2) / h;
				float a = sqrt(1.0 - b * b);
				float2 q = float2(length(p.xz), p.y);
				float k = dot(q, float2(-b, a));
				if (k < 0.0) return length(q) - r1;
				if (k > a * h) return length(q - float2(0.0, h)) - r2;
				return dot(q, float2(a, b)) - r1;
			}

			//ellipsoid
			float sdEllipsoid(float3 p, float3 r)
			{
				float k0 = length(p / r);
				float k1 = length(p / (r * r));
				return k0 * (k0 - 1.0) / k1;
			}

			//rhombus
			float sdRhombus(float3 p, float la, float lb, float h, float ra)
			{
				p = abs(p);
				float2 b = float2(la, lb);
				float f = clamp((ndot(b, b - 2.0 * p.xz)) / dot(b, b), -1.0, 1.0);
				float2 q = float2(length(p.xz - 0.5 * b * float2(1.0 - f, 1.0 + f)) * sign(p.x * b.y + p.z * b.x - b.x * b.y) - ra, p.y - h);
				return min(max(q.x, q.y), 0.0) + length(max(q, 0.0));
			}

			//octahedron
			float sdOctahedron(float3 p, float s)
			{
				p = abs(p);
				float m = p.x + p.y + p.z - s;
				float3 q;
				if (3.0 * p.x < m) q = p.xyz;
				else if (3.0 * p.y < m) q = p.yzx;
				else if (3.0 * p.z < m) q = p.zxy;
				else return m * 0.57735027;

				float k = clamp(0.5 * (q.z - q.y + s), 0.0, s);
				return length(float3(q.x, q.y - s + k, q.z - k));
			}

			//pyramid
			float sdPyramid(float3 p, float h)
			{
				float m2 = h * h + 0.25;

				p.xz = abs(p.xz);
				p.xz = (p.z > p.x) ? p.zx : p.xz;
				p.xz -= 0.5;

				float3 q = float3(p.z, h * p.y - 0.5 * p.x, h * p.x + 0.5 * p.y);

				float s = max(-q.x, 0.0);
				float t = clamp((q.y - 0.5 * p.z) / (m2 + 0.25), 0.0, 1.0);

				float a = m2 * (q.x + s) * (q.x + s) + q.y * q.y;
				float b = m2 * (q.x + 0.5 * t) * (q.x + 0.5 * t) + (q.y - m2 * t) * (q.y - m2 * t);

				float d2 = min(q.y, -q.x * m2 - q.y * 0.5) > 0.0 ? 0.0 : min(a, b);

				return sqrt((d2 + q.z * q.z) / m2) * sign(max(q.z, -p.y));
			}

			//triangle
			float udTriangle(float3 p, float3 a, float3 b, float3 c)
			{
				float3 ba = b - a; float3 pa = p - a;
				float3 cb = c - b; float3 pb = p - b;
				float3 ac = a - c; float3 pc = p - c;
				float3 nor = cross(ba, ac);

				return sqrt(
					(sign(dot(cross(ba, nor), pa)) +
						sign(dot(cross(cb, nor), pb)) +
						sign(dot(cross(ac, nor), pc)) < 2.0)
					?
					min(min(
						dot2(ba * clamp(dot(ba, pa) / dot2(ba), 0.0, 1.0) - pa),
						dot2(cb * clamp(dot(cb, pb) / dot2(cb), 0.0, 1.0) - pb)),
						dot2(ac * clamp(dot(ac, pc) / dot2(ac), 0.0, 1.0) - pc))
					:
					dot(nor, pa) * dot(nor, pa) / dot2(nor));
			}

			//quad
			float udQuad(float3 p, float3 a, float3 b, float3 c, float3 d)
			{
				float3 ba = b - a; float3 pa = p - a;
				float3 cb = c - b; float3 pb = p - b;
				float3 dc = d - c; float3 pc = p - c;
				float3 ad = a - d; float3 pd = p - d;
				float3 nor = cross(ba, ad);

				return sqrt(
					(sign(dot(cross(ba, nor), pa)) +
						sign(dot(cross(cb, nor), pb)) +
						sign(dot(cross(dc, nor), pc)) +
						sign(dot(cross(ad, nor), pd)) < 3.0)
					?
					min(min(min(
						dot2(ba * clamp(dot(ba, pa) / dot2(ba), 0.0, 1.0) - pa),
						dot2(cb * clamp(dot(cb, pb) / dot2(cb), 0.0, 1.0) - pb)),
						dot2(dc * clamp(dot(dc, pc) / dot2(dc), 0.0, 1.0) - pc)),
						dot2(ad * clamp(dot(ad, pd) / dot2(ad), 0.0, 1.0) - pd))
					:
					dot(nor, pa) * dot(nor, pa) / dot2(nor));
			}

			//fractal
			float sdFractal(float3 z, float i, float s, float o)	
			{
				int n = 0;
				while (n < i) {
				   if(z.x+z.y<0) z.xy = -z.yx; // fold 1
				   if(z.x+z.z<0) z.xz = -z.zx; // fold 2
				   if(z.y+z.z<0) z.zy = -z.yz; // fold 3	
				   z = z*s - o*(s-1.0);
				   n++;
				}
				return (length(z) ) * pow(s, -float(n));
			}