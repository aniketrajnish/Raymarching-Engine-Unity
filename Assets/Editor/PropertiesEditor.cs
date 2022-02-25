#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(RaymarchRenderer))]

public class PropertiesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Dimensions", EditorStyles.boldLabel);
        RaymarchRenderer rr = (RaymarchRenderer)target;

        switch ((int)rr.shape)
        {
            case 0:
                SphereDimensions.radius = EditorGUILayout.FloatField("Radius", SphereDimensions.radius);
                EditorPrefs.SetFloat("SphereRadius", SphereDimensions.radius);
                break;
            case 1:
                TorusDimensions.thickness = EditorGUILayout.Vector2Field("Thickness", TorusDimensions.thickness);
                EditorPrefs.SetFloat("TorusThicknessX", TorusDimensions.thickness.x);
                EditorPrefs.SetFloat("TorusThicknessY", TorusDimensions.thickness.y);
                break;
            case 2:
                CappedTorusDimensions.ro = EditorGUILayout.FloatField("Ro", CappedTorusDimensions.ro);
                CappedTorusDimensions.ri = EditorGUILayout.FloatField("Ri", CappedTorusDimensions.ri);
                CappedTorusDimensions.thickness = EditorGUILayout.Vector2Field("Thickness", CappedTorusDimensions.thickness);
                EditorPrefs.SetFloat("CTRi", CappedTorusDimensions.ri);
                EditorPrefs.SetFloat("CTRo", CappedTorusDimensions.ro);
                EditorPrefs.SetFloat("CTTx", CappedTorusDimensions.thickness.x);
                EditorPrefs.SetFloat("CTTy", CappedTorusDimensions.thickness.y);
                break;
            case 3:
                LinkDimensions.separation = EditorGUILayout.FloatField("Separation", LinkDimensions.separation);
                LinkDimensions.radius = EditorGUILayout.FloatField("Radius", LinkDimensions.radius);
                LinkDimensions.thickness = EditorGUILayout.FloatField("Thickness", LinkDimensions.thickness);
                EditorPrefs.SetFloat("LinkSeparation", LinkDimensions.separation);
                EditorPrefs.SetFloat("LinkRadius", LinkDimensions.radius);
                EditorPrefs.SetFloat("LinkThickness", LinkDimensions.thickness);
                break;
            case 4:
                ConeDimensions.tan = EditorGUILayout.Vector2Field("Tan", ConeDimensions.tan);
                ConeDimensions.height = EditorGUILayout.FloatField("Height", ConeDimensions.height);
                EditorPrefs.SetFloat("ConeTanX", ConeDimensions.tan.x);
                EditorPrefs.SetFloat("ConeTanY", ConeDimensions.tan.y);
                EditorPrefs.SetFloat("ConeHeight", ConeDimensions.height);
                break;
            case 5:
                InfiniteConeDimensions.tan = EditorGUILayout.Vector2Field("Tan", InfiniteConeDimensions.tan);
                EditorPrefs.SetFloat("ICTanX", InfiniteConeDimensions.tan.x);
                EditorPrefs.SetFloat("ICTanY", InfiniteConeDimensions.tan.y);
                break;
            case 6:
                PlaneDimensions.normal = EditorGUILayout.Vector3Field("Normal", PlaneDimensions.normal);
                PlaneDimensions.distance = EditorGUILayout.FloatField("Distance", PlaneDimensions.distance);
                EditorPrefs.SetFloat("PlaneDistance", PlaneDimensions.distance);
                EditorPrefs.SetFloat("PlaneNormalX", PlaneDimensions.normal.x);
                EditorPrefs.SetFloat("PlaneNormalY", PlaneDimensions.normal.y);
                EditorPrefs.SetFloat("PlaneNormalZ", PlaneDimensions.normal.z);
                break;
            case 7:
                HexagonalPrismDimensions.h = EditorGUILayout.Vector2Field("H", HexagonalPrismDimensions.h);
                EditorPrefs.SetFloat("HPHX", HexagonalPrismDimensions.h.x);
                EditorPrefs.SetFloat("HPHY", HexagonalPrismDimensions.h.y);
                break;
            case 8:
                TriangularPrismDimensions.h = EditorGUILayout.Vector2Field("H", TriangularPrismDimensions.h);
                EditorPrefs.SetFloat("TPHX", TriangularPrismDimensions.h.x);
                EditorPrefs.SetFloat("TPHY", TriangularPrismDimensions.h.y);
                break;
            case 9:
                CapsuleDimensions.a = EditorGUILayout.Vector3Field("A", CapsuleDimensions.a);
                CapsuleDimensions.b = EditorGUILayout.Vector3Field("B", CapsuleDimensions.b);
                CapsuleDimensions.r = EditorGUILayout.FloatField("R", CapsuleDimensions.r);
                EditorPrefs.SetFloat("CapsuleR", CapsuleDimensions.r);
                EditorPrefs.SetFloat("CapsuleAX", CapsuleDimensions.a.x);
                EditorPrefs.SetFloat("CapsuleAY", CapsuleDimensions.a.y);
                EditorPrefs.SetFloat("CapsuleAZ", CapsuleDimensions.a.z);
                EditorPrefs.SetFloat("CapsuleBX", CapsuleDimensions.b.x);
                EditorPrefs.SetFloat("CapsuleBY", CapsuleDimensions.b.y);
                EditorPrefs.SetFloat("CapsuleBZ", CapsuleDimensions.b.z);
                break;
            case 10:
                InfiniteCylinderDimensions.c = EditorGUILayout.Vector3Field("C", InfiniteCylinderDimensions.c);
                EditorPrefs.SetFloat("ICCX", InfiniteCylinderDimensions.c.x);
                EditorPrefs.SetFloat("ICCY", InfiniteCylinderDimensions.c.y);
                EditorPrefs.SetFloat("ICCZ", InfiniteCylinderDimensions.c.z);
                break;
            case 11:
                BoxDimensions.size = EditorGUILayout.FloatField("Size", BoxDimensions.size);
                EditorPrefs.SetFloat("BoxSize", BoxDimensions.size);
                break;
            case 12:
                RoundBoxDimensions.size = EditorGUILayout.FloatField("Size", RoundBoxDimensions.size);
                RoundBoxDimensions.roundFactor = EditorGUILayout.FloatField("Round Factor", RoundBoxDimensions.roundFactor);
                EditorPrefs.SetFloat("RoundBoxSize", RoundBoxDimensions.size);
                EditorPrefs.SetFloat("RoundBoxFactor", RoundBoxDimensions.roundFactor);

                break;
            case 13:
                RoundedCylinderDimensions.ra = EditorGUILayout.FloatField("Radius", RoundedCylinderDimensions.ra);
                RoundedCylinderDimensions.rb = EditorGUILayout.FloatField("Round Factor", RoundedCylinderDimensions.rb);
                RoundedCylinderDimensions.h = EditorGUILayout.FloatField("Height", RoundedCylinderDimensions.h);
                EditorPrefs.SetFloat("RCra", RoundedCylinderDimensions.ra);
                EditorPrefs.SetFloat("RCrb", RoundedCylinderDimensions.rb);
                EditorPrefs.SetFloat("RCh", RoundedCylinderDimensions.h);
                break;
            case 14:
                CappedConeDimensions.h = EditorGUILayout.FloatField("Height", CappedConeDimensions.h);
                CappedConeDimensions.r1 = EditorGUILayout.FloatField("Bottom Radius", CappedConeDimensions.r1);
                CappedConeDimensions.r2 = EditorGUILayout.FloatField("Top Radius", CappedConeDimensions.r2);
                EditorPrefs.SetFloat("CCh", CappedConeDimensions.h);
                EditorPrefs.SetFloat("CCr1", CappedConeDimensions.r1);
                EditorPrefs.SetFloat("CCr2", CappedConeDimensions.r2);
                break;
            case 15:
                BoxFrameDimensions.size = EditorGUILayout.Vector3Field("Size", BoxFrameDimensions.size);
                BoxFrameDimensions.cavity = EditorGUILayout.FloatField("Thickness", BoxFrameDimensions.cavity);
                EditorPrefs.SetFloat("BFSizeX", BoxFrameDimensions.size.x);
                EditorPrefs.SetFloat("BFSizeY", BoxFrameDimensions.size.y);
                EditorPrefs.SetFloat("BFSizeZ", BoxFrameDimensions.size.z);
                EditorPrefs.SetFloat("BFc", BoxFrameDimensions.cavity);
                break;
            case 16:
                SolidAngleDimensions.c = EditorGUILayout.Vector2Field("Angle", SolidAngleDimensions.c);
                SolidAngleDimensions.ra = EditorGUILayout.FloatField("Radius", SolidAngleDimensions.ra);
                EditorPrefs.SetFloat("SAcX", SolidAngleDimensions.c.x);
                EditorPrefs.SetFloat("SAcY", SolidAngleDimensions.c.y);
                EditorPrefs.SetFloat("SAcra", SolidAngleDimensions.ra);
                break;
            case 17:
                CutSphereDimensions.r = EditorGUILayout.FloatField("Radius", CutSphereDimensions.r);
                CutSphereDimensions.h = EditorGUILayout.FloatField("Fill Amount", CutSphereDimensions.h);
                EditorPrefs.SetFloat("CSr", CutSphereDimensions.r);
                EditorPrefs.SetFloat("CSh", CutSphereDimensions.h);
                break;
            case 18:
                HollowSphereDimensions.r = EditorGUILayout.FloatField("Radius", HollowSphereDimensions.r);
                HollowSphereDimensions.h = EditorGUILayout.FloatField("Fill Amount", HollowSphereDimensions.h);
                HollowSphereDimensions.t = EditorGUILayout.FloatField("Thickness", HollowSphereDimensions.t);
                EditorPrefs.SetFloat("HSr", HollowSphereDimensions.r);
                EditorPrefs.SetFloat("HSh", HollowSphereDimensions.h);
                EditorPrefs.SetFloat("HSt", HollowSphereDimensions.t);
                break;
            case 19:
                DeathStarDimensions.ra = EditorGUILayout.FloatField("Ra", DeathStarDimensions.ra);
                DeathStarDimensions.rb = EditorGUILayout.FloatField("Rb", DeathStarDimensions.rb);
                DeathStarDimensions.d = EditorGUILayout.FloatField("D", DeathStarDimensions.d);
                EditorPrefs.SetFloat("DSra", DeathStarDimensions.ra);
                EditorPrefs.SetFloat("DSrb", DeathStarDimensions.rb);
                EditorPrefs.SetFloat("DSd", DeathStarDimensions.d);
                break;
            case 20:
                RoundConeDimensions.r1 = EditorGUILayout.FloatField("R1", RoundConeDimensions.r1);
                RoundConeDimensions.r2 = EditorGUILayout.FloatField("R2", RoundConeDimensions.r2);
                RoundConeDimensions.h = EditorGUILayout.FloatField("H", RoundConeDimensions.h);
                EditorPrefs.GetFloat("RCr1", RoundConeDimensions.r1);
                EditorPrefs.GetFloat("RCr2", RoundConeDimensions.r2);
                EditorPrefs.GetFloat("RCh", RoundConeDimensions.h);
                break;
            case 21:
                EllipsoidDimensions.Radius = EditorGUILayout.Vector3Field("Radius", EllipsoidDimensions.Radius);
                EditorPrefs.SetFloat("EDrX", EllipsoidDimensions.Radius.x);
                EditorPrefs.SetFloat("EDrY", EllipsoidDimensions.Radius.y);
                EditorPrefs.SetFloat("EDrZ", EllipsoidDimensions.Radius.z);
                break;
            case 22:
                RhombusDimensions.la = EditorGUILayout.FloatField("La", RhombusDimensions.la);
                RhombusDimensions.lb = EditorGUILayout.FloatField("Lb", RhombusDimensions.lb);
                RhombusDimensions.h = EditorGUILayout.FloatField("Height", RhombusDimensions.h);
                RhombusDimensions.ra = EditorGUILayout.FloatField("Round Factor", RhombusDimensions.ra);
                EditorPrefs.SetFloat("RDla", RhombusDimensions.la);
                EditorPrefs.SetFloat("RDlb", RhombusDimensions.lb);
                EditorPrefs.SetFloat("RDh", RhombusDimensions.h);
                EditorPrefs.SetFloat("RDra", RhombusDimensions.ra);
                break;
            case 23:
                OctahedronDimensions.size = EditorGUILayout.FloatField("Size", OctahedronDimensions.size);
                EditorPrefs.SetFloat("OctaSize", OctahedronDimensions.size);
                break;
            case 24:
                PyramidDimensions.size = EditorGUILayout.FloatField("Size", PyramidDimensions.size);
                EditorPrefs.SetFloat("PryamidSize", PyramidDimensions.size);
                break;
            case 25:
                TriangleDimensions.sideA = EditorGUILayout.Vector3Field("Side A", TriangleDimensions.sideA);
                TriangleDimensions.sideB = EditorGUILayout.Vector3Field("Side B", TriangleDimensions.sideB);
                TriangleDimensions.sideC = EditorGUILayout.Vector3Field("Side C", TriangleDimensions.sideC);
                EditorPrefs.SetFloat("TAX", TriangleDimensions.sideA.x);
                EditorPrefs.SetFloat("TAY", TriangleDimensions.sideA.y);
                EditorPrefs.SetFloat("TAZ", TriangleDimensions.sideA.z);
                EditorPrefs.SetFloat("TBX", TriangleDimensions.sideA.x);
                EditorPrefs.SetFloat("TBY", TriangleDimensions.sideA.y);
                EditorPrefs.SetFloat("TBZ", TriangleDimensions.sideA.z);
                EditorPrefs.SetFloat("TCX", TriangleDimensions.sideA.x);
                EditorPrefs.SetFloat("TCY", TriangleDimensions.sideA.y);
                EditorPrefs.SetFloat("TCZ", TriangleDimensions.sideA.z);
                break;
            case 26:
                QuadDimensions.sideA = EditorGUILayout.Vector3Field("Side A", QuadDimensions.sideA);
                QuadDimensions.sideB = EditorGUILayout.Vector3Field("Side B", QuadDimensions.sideB);
                QuadDimensions.sideC = EditorGUILayout.Vector3Field("Side C", QuadDimensions.sideC);
                QuadDimensions.sideD = EditorGUILayout.Vector3Field("Side D", QuadDimensions.sideD);
                EditorPrefs.SetFloat("QAX", QuadDimensions.sideA.x);
                EditorPrefs.SetFloat("QAY", QuadDimensions.sideA.y);
                EditorPrefs.SetFloat("QAZ", QuadDimensions.sideA.z);
                EditorPrefs.SetFloat("QBX", QuadDimensions.sideB.x);
                EditorPrefs.SetFloat("QBY", QuadDimensions.sideB.y);
                EditorPrefs.SetFloat("QBZ", QuadDimensions.sideB.z);
                EditorPrefs.SetFloat("QCX", QuadDimensions.sideC.x);
                EditorPrefs.SetFloat("QCY", QuadDimensions.sideC.y);
                EditorPrefs.SetFloat("QCZ", QuadDimensions.sideC.z);
                EditorPrefs.SetFloat("QDX", QuadDimensions.sideD.x);
                EditorPrefs.SetFloat("QDY", QuadDimensions.sideD.y);
                EditorPrefs.SetFloat("QDZ", QuadDimensions.sideD.z);
                break;
            case 27:
                FractalDimenisons.i = EditorGUILayout.FloatField("Iterations", FractalDimenisons.i);
                FractalDimenisons.s = EditorGUILayout.FloatField("Size", FractalDimenisons.s);
                FractalDimenisons.o = EditorGUILayout.FloatField("Offset", FractalDimenisons.o);
                EditorPrefs.SetFloat("Fraci", FractalDimenisons.i);
                EditorPrefs.SetFloat("Fracs", FractalDimenisons.s);
                EditorPrefs.SetFloat("Fraco", FractalDimenisons.o);
                break;
            case 28:
                TesseractDimensions.size = EditorGUILayout.Vector4Field("Size", TesseractDimensions.size);                
                EditorPrefs.SetFloat("TessX", TesseractDimensions.size.x);
                EditorPrefs.SetFloat("TessY", TesseractDimensions.size.y);
                EditorPrefs.SetFloat("TessZ", TesseractDimensions.size.z);
                EditorPrefs.SetFloat("TessW", TesseractDimensions.size.w);
                break;
        }

        EditorUtility.SetDirty(rr);
    }
}
#endif