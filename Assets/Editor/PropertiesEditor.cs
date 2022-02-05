#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(RaymarchRenderer))]

public class PropertiesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Dimensions");
        RaymarchRenderer rr = (RaymarchRenderer)target;

        switch ((int)rr.shape)
        {
            case 0:
                SphereDimensions.radius = EditorGUILayout.FloatField("Radius", SphereDimensions.radius);                
                break;
            case 1:
                TorusDimensions.thickness = EditorGUILayout.Vector2Field("Thickness", TorusDimensions.thickness);
                break;
            case 2:
                CappedTorusDimensions.ro = EditorGUILayout.FloatField("Ro", CappedTorusDimensions.ro);
                CappedTorusDimensions.ri = EditorGUILayout.FloatField("Ri", CappedTorusDimensions.ri);
                CappedTorusDimensions.thickness = EditorGUILayout.Vector2Field("Thickness", CappedTorusDimensions.thickness);
                break;
            case 3:
                LinkDimensions.separation = EditorGUILayout.FloatField("Separation", LinkDimensions.separation);
                LinkDimensions.radius = EditorGUILayout.FloatField("Radius", LinkDimensions.radius);
                LinkDimensions.thickness = EditorGUILayout.FloatField("Thickness", LinkDimensions.thickness);
                break;
            case 4:
                ConeDimensions.tan = EditorGUILayout.Vector2Field("Tan", ConeDimensions.tan);
                ConeDimensions.height = EditorGUILayout.FloatField("Height", ConeDimensions.height);
                break;
            case 5:
                InfiniteConeDimensions.tan = EditorGUILayout.Vector2Field("Tan", InfiniteConeDimensions.tan);
                break;
            case 6:
                PlaneDimensions.normal = EditorGUILayout.Vector3Field("Normal", PlaneDimensions.normal);
                PlaneDimensions.distance = EditorGUILayout.FloatField("Distance", PlaneDimensions.distance);
                break;
            case 7:
                HexagonalPrismDimensions.h = EditorGUILayout.Vector2Field("H", HexagonalPrismDimensions.h);
                break;
            case 8:
                TriangularPrism.h = EditorGUILayout.Vector2Field("H", TriangularPrism.h);
                break;
            case 9:
                CapsuleDimensions.a = EditorGUILayout.Vector3Field("A", CapsuleDimensions.a);
                CapsuleDimensions.b = EditorGUILayout.Vector3Field("B", CapsuleDimensions.b);
                CapsuleDimensions.r = EditorGUILayout.FloatField("R", CapsuleDimensions.r);
                break;
            case 10:
                InfiniteCylinderDimensions.c = EditorGUILayout.Vector3Field("C", InfiniteCylinderDimensions.c);
                break;
            case 11:
                BoxDimensions.size = EditorGUILayout.FloatField("Size", BoxDimensions.size);
                break;
            case 12:
                RoundBoxDimensions.size = EditorGUILayout.FloatField("Size", RoundBoxDimensions.size);
                RoundBoxDimensions.roundFactor = EditorGUILayout.FloatField("Round Factor", RoundBoxDimensions.roundFactor);
                break;
            case 13:
                RoundedCylinderDimensions.ra = EditorGUILayout.FloatField("Radius", RoundedCylinderDimensions.ra);
                RoundedCylinderDimensions.rb = EditorGUILayout.FloatField("Round Factor", RoundedCylinderDimensions.rb);
                RoundedCylinderDimensions.h = EditorGUILayout.FloatField("Height", RoundedCylinderDimensions.h);
                break;
            case 14:
                CappedConeDimensions.h = EditorGUILayout.FloatField("Height", CappedConeDimensions.h);
                CappedConeDimensions.r1 = EditorGUILayout.FloatField("Bottom Radius", CappedConeDimensions.r1);
                CappedConeDimensions.r2 = EditorGUILayout.FloatField("Top Radius", CappedConeDimensions.r2);
                break;
            case 15:
                BoxFrameDimensions.size = EditorGUILayout.Vector3Field("Size", BoxFrameDimensions.size);
                BoxFrameDimensions.cavity = EditorGUILayout.FloatField("Thickness", BoxFrameDimensions.cavity);
                break;
            case 16:
                SolidAngleDimensions.c = EditorGUILayout.Vector2Field("Angle", SolidAngleDimensions.c);
                SolidAngleDimensions.ra = EditorGUILayout.FloatField("Radius", SolidAngleDimensions.ra);
                break;
            case 17:
                CutSphereDimensions.r = EditorGUILayout.FloatField("Radius", CutSphereDimensions.r);
                CutSphereDimensions.h = EditorGUILayout.FloatField("Fill Amount", CutSphereDimensions.h);
                break;
            case 18:
                HollowSphereDimensions.r = EditorGUILayout.FloatField("Radius", HollowSphereDimensions.r);
                HollowSphereDimensions.h = EditorGUILayout.FloatField("Fill Amount", HollowSphereDimensions.h);
                HollowSphereDimensions.t = EditorGUILayout.FloatField("Thickness", HollowSphereDimensions.t);
                break;
            case 19:
                DeathStarDimensions.ra = EditorGUILayout.FloatField("Ra", DeathStarDimensions.ra);
                DeathStarDimensions.rb = EditorGUILayout.FloatField("Rb", DeathStarDimensions.rb);
                DeathStarDimensions.d = EditorGUILayout.FloatField("D", DeathStarDimensions.d);
                break;
            case 20:
                RoundConeDimensions.r1 = EditorGUILayout.FloatField("R1", RoundConeDimensions.r1);
                RoundConeDimensions.r2 = EditorGUILayout.FloatField("R2", RoundConeDimensions.r2);
                RoundConeDimensions.h = EditorGUILayout.FloatField("H", RoundConeDimensions.h);
                break;
            case 21:
                EllipsoidDimensions.Radius = EditorGUILayout.Vector3Field("Radius", EllipsoidDimensions.Radius);
                break;
            case 22:
                RhombusDimensions.la = EditorGUILayout.FloatField("La", RhombusDimensions.la);
                RhombusDimensions.lb = EditorGUILayout.FloatField("Lb", RhombusDimensions.lb);
                RhombusDimensions.h = EditorGUILayout.FloatField("Height", RhombusDimensions.h);
                RhombusDimensions.ra = EditorGUILayout.FloatField("Round Factor", RhombusDimensions.ra);
                break;
            case 23:
                OctahedronDimensions.size = EditorGUILayout.FloatField("Size", OctahedronDimensions.size);
                break;
            case 24:
                PyramidDimensions.size = EditorGUILayout.FloatField("Size", PyramidDimensions.size);
                break;
            case 25:
                TriangleDimensions.sideA = EditorGUILayout.Vector3Field("Side A", TriangleDimensions.sideA);
                TriangleDimensions.sideB = EditorGUILayout.Vector3Field("Side B", TriangleDimensions.sideB);
                TriangleDimensions.sideC = EditorGUILayout.Vector3Field("Side C", TriangleDimensions.sideC);
                break;
            case 26:
                QuadDimensions.sideA = EditorGUILayout.Vector3Field("Side A", QuadDimensions.sideA);
                QuadDimensions.sideB = EditorGUILayout.Vector3Field("Side B", QuadDimensions.sideB);
                QuadDimensions.sideC = EditorGUILayout.Vector3Field("Side C", QuadDimensions.sideC);
                QuadDimensions.sideD = EditorGUILayout.Vector3Field("Side D", QuadDimensions.sideD);
                break;
        }       
    }  
}
#endif
