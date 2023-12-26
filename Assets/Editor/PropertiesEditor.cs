#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(RaymarchRenderer))]
[CanEditMultipleObjects]
public class PropertiesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        RaymarchRenderer renderer = (RaymarchRenderer)target;

        /*if (renderer.dimensions == null)
            return;*/
        if (GUILayout.Button("Create New Dimensions"))
            renderer.dimensions = CreateShapeDimensionsAsset();

        if (renderer.dimensions == null)
            return;

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Shape Dimensions", EditorStyles.boldLabel);

        switch (renderer.shape)
        {
            case RaymarchRenderer.Shape.Shpere:
                renderer.dimensions.sphereRadius = EditorGUILayout.FloatField("Radius", renderer.dimensions.sphereRadius);
                break;
            case RaymarchRenderer.Shape.Torus:
                renderer.dimensions.torusThickness = EditorGUILayout.Vector2Field("Thickness", renderer.dimensions.torusThickness);
                break;
            case RaymarchRenderer.Shape.CappedTorus:
                renderer.dimensions.cappedTorusRo = EditorGUILayout.FloatField("Ro", renderer.dimensions.cappedTorusRo);
                renderer.dimensions.cappedTorusRi = EditorGUILayout.FloatField("Ri", renderer.dimensions.cappedTorusRi);
                renderer.dimensions.cappedTorusThickness = EditorGUILayout.Vector2Field("Thickness", renderer.dimensions.cappedTorusThickness);
                break;
            case RaymarchRenderer.Shape.Link:
                renderer.dimensions.linkSeparation = EditorGUILayout.FloatField("Separation", renderer.dimensions.linkSeparation);
                renderer.dimensions.linkRadius = EditorGUILayout.FloatField("Radius", renderer.dimensions.linkRadius);
                renderer.dimensions.linkThickness = EditorGUILayout.FloatField("Thickness", renderer.dimensions.linkThickness);
                break;
            case RaymarchRenderer.Shape.Cone:
                renderer.dimensions.coneTan = EditorGUILayout.Vector2Field("Tan", renderer.dimensions.coneTan);
                renderer.dimensions.coneHeight = EditorGUILayout.FloatField("Height", renderer.dimensions.coneHeight);
                break;
            case RaymarchRenderer.Shape.InfCone:
                renderer.dimensions.infConeTan = EditorGUILayout.Vector2Field("Tan", renderer.dimensions.infConeTan);
                break;
            case RaymarchRenderer.Shape.Plane:
                renderer.dimensions.planeNormal = EditorGUILayout.Vector3Field("Normal", renderer.dimensions.planeNormal);
                renderer.dimensions.planeDistance = EditorGUILayout.FloatField("Distance", renderer.dimensions.planeDistance);
                break;
            case RaymarchRenderer.Shape.HexPrism:
                renderer.dimensions.hexPrismH = EditorGUILayout.Vector2Field("H", renderer.dimensions.hexPrismH);
                break;
            case RaymarchRenderer.Shape.TriPrism:
                renderer.dimensions.triPrismH = EditorGUILayout.Vector2Field("H", renderer.dimensions.triPrismH);
                break;
            case RaymarchRenderer.Shape.Capsule:
                renderer.dimensions.capsuleA = EditorGUILayout.Vector3Field("A", renderer.dimensions.capsuleA);
                renderer.dimensions.capsuleB = EditorGUILayout.Vector3Field("B", renderer.dimensions.capsuleB);
                renderer.dimensions.capsuleR = EditorGUILayout.FloatField("R", renderer.dimensions.capsuleR);
                break;
            case RaymarchRenderer.Shape.InfiniteCylinder:
                renderer.dimensions.infCylC = EditorGUILayout.Vector3Field("C", renderer.dimensions.infCylC);
                break;
            case RaymarchRenderer.Shape.Box:
                renderer.dimensions.boxSize = EditorGUILayout.FloatField("Size", renderer.dimensions.boxSize);
                break;
            case RaymarchRenderer.Shape.RoundBox:
                renderer.dimensions.roundBoxSize = EditorGUILayout.FloatField("Size", renderer.dimensions.roundBoxSize);
                renderer.dimensions.roundBoxRoundFactor = EditorGUILayout.FloatField("Round Factor", renderer.dimensions.roundBoxRoundFactor);
                break;
            case RaymarchRenderer.Shape.RoundedCylinder:
                renderer.dimensions.roundCylRa = EditorGUILayout.FloatField("Ra", renderer.dimensions.roundCylRa);
                renderer.dimensions.roundCylRb = EditorGUILayout.FloatField("Ra", renderer.dimensions.roundCylRb);
                renderer.dimensions.roundCylH = EditorGUILayout.FloatField("Ra", renderer.dimensions.roundCylH);
                break;
            case RaymarchRenderer.Shape.CappedCone:
                renderer.dimensions.capConeH = EditorGUILayout.FloatField("H", renderer.dimensions.capConeH);
                renderer.dimensions.capConeR1 = EditorGUILayout.FloatField("R1", renderer.dimensions.capConeR1);
                renderer.dimensions.capConeR1 = EditorGUILayout.FloatField("R2", renderer.dimensions.capConeR2);
                break;
            case RaymarchRenderer.Shape.BoxFrame:
                renderer.dimensions.boxFrameSize = EditorGUILayout.Vector3Field("Size", renderer.dimensions.boxFrameSize);
                renderer.dimensions.boxFrameCavity = EditorGUILayout.FloatField("Cavity", renderer.dimensions.boxFrameCavity);
                break;
            case RaymarchRenderer.Shape.SolidAngle:
                renderer.dimensions.solidAngleC = EditorGUILayout.Vector2Field("C", renderer.dimensions.solidAngleC);
                renderer.dimensions.solidAngleRa = EditorGUILayout.FloatField("Ra", renderer.dimensions.solidAngleRa);
                break;
            case RaymarchRenderer.Shape.CutSphere:
                renderer.dimensions.cutSphereR = EditorGUILayout.FloatField("R", renderer.dimensions.cutSphereR);
                renderer.dimensions.cutSphereH = EditorGUILayout.FloatField("H", renderer.dimensions.cutSphereH);
                break;
            case RaymarchRenderer.Shape.CutHollowSphere:
                renderer.dimensions.cutSphereR = EditorGUILayout.FloatField("R", renderer.dimensions.cutSphereR);
                renderer.dimensions.cutSphereH = EditorGUILayout.FloatField("H", renderer.dimensions.cutSphereH);
                break;
            case RaymarchRenderer.Shape.DeathStar:
                renderer.dimensions.deathStarRa = EditorGUILayout.FloatField("Ra", renderer.dimensions.deathStarRa);
                renderer.dimensions.deathStarRb = EditorGUILayout.FloatField("Rb", renderer.dimensions.deathStarRb);
                renderer.dimensions.deathStarD = EditorGUILayout.FloatField("D", renderer.dimensions.deathStarD);
                break;
            case RaymarchRenderer.Shape.RoundCone:
                renderer.dimensions.roundConeR1 = EditorGUILayout.FloatField("R1", renderer.dimensions.roundConeR1);
                renderer.dimensions.roundConeR2 = EditorGUILayout.FloatField("R2", renderer.dimensions.roundConeR2);
                renderer.dimensions.roundConeH = EditorGUILayout.FloatField("H", renderer.dimensions.roundConeH);
                break;
            case RaymarchRenderer.Shape.Ellipsoid:
                renderer.dimensions.ellipsoidRadius = EditorGUILayout.Vector3Field("Radius", renderer.dimensions.ellipsoidRadius);
                break;
            case RaymarchRenderer.Shape.Rhombus:
                renderer.dimensions.rhombusLa = EditorGUILayout.FloatField("La", renderer.dimensions.rhombusLa);
                renderer.dimensions.rhombusLb = EditorGUILayout.FloatField("Lb", renderer.dimensions.rhombusLb);
                renderer.dimensions.rhombusH = EditorGUILayout.FloatField("H", renderer.dimensions.rhombusH);
                renderer.dimensions.rhombusRa = EditorGUILayout.FloatField("Ra", renderer.dimensions.rhombusRa);
                break;
            case RaymarchRenderer.Shape.Octahedron:
                renderer.dimensions.octahedronSize = EditorGUILayout.FloatField("Size", renderer.dimensions.octahedronSize);
                break;
            case RaymarchRenderer.Shape.Pyramid:
                renderer.dimensions.pyramidSize = EditorGUILayout.FloatField("Size", renderer.dimensions.pyramidSize);
                break;
            case RaymarchRenderer.Shape.Triangle:
                renderer.dimensions.triangleSideA = EditorGUILayout.Vector3Field("Side A", renderer.dimensions.triangleSideA);
                renderer.dimensions.triangleSideB = EditorGUILayout.Vector3Field("Side B", renderer.dimensions.triangleSideB);
                renderer.dimensions.triangleSideC = EditorGUILayout.Vector3Field("Side C", renderer.dimensions.triangleSideC);
                break;
            case RaymarchRenderer.Shape.Quad:
                renderer.dimensions.quadSideA = EditorGUILayout.Vector3Field("Side A", renderer.dimensions.quadSideA);
                renderer.dimensions.quadSideB = EditorGUILayout.Vector3Field("Side B", renderer.dimensions.quadSideB);
                renderer.dimensions.quadSideC = EditorGUILayout.Vector3Field("Side C", renderer.dimensions.quadSideC);
                renderer.dimensions.quadSideD = EditorGUILayout.Vector3Field("Side D", renderer.dimensions.quadSideD);
                break;
            case RaymarchRenderer.Shape.Fractal:
                renderer.dimensions.fractalI = EditorGUILayout.FloatField("I", renderer.dimensions.fractalI);
                renderer.dimensions.fractalS = EditorGUILayout.FloatField("S", renderer.dimensions.fractalS);
                renderer.dimensions.fractalO = EditorGUILayout.FloatField("O", renderer.dimensions.fractalO);
                break;
            case RaymarchRenderer.Shape.Tesseract:
                renderer.dimensions.tesseractSize = EditorGUILayout.Vector4Field("Size", renderer.dimensions.tesseractSize);
                break;
            default:
                EditorGUILayout.HelpBox("Select a shape to see properties", MessageType.Info);
                break;
        }

        if (!PrefabUtility.IsPartOfPrefabAsset(renderer))
        {
            EditorUtility.SetDirty(renderer);
            EditorUtility.SetDirty(renderer.dimensions);
        }
    }

    void OnEnable()
    {
        EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        EditorApplication.quitting += OnQuitting;
    }

    void OnDisable()
    {
        EditorApplication.playModeStateChanged -= OnPlayModeStateChanged;
        EditorApplication.quitting -= OnQuitting;
    }

    private void OnPlayModeStateChanged(PlayModeStateChange state)
    {
        if (state == PlayModeStateChange.ExitingEditMode || state == PlayModeStateChange.ExitingPlayMode)
            ((RaymarchRenderer)target).editorStateChange = true;
    }

    private void OnQuitting()
    {
        ((RaymarchRenderer)target).editorStateChange = true;
    }

    ShapeDimensions CreateShapeDimensionsAsset()
    {
        ShapeDimensions asset = ScriptableObject.CreateInstance<ShapeDimensions>();

        string folderPath = "Assets/ScriptableObjects";

        if (!System.IO.Directory.Exists(folderPath))
        {
            AssetDatabase.CreateFolder("Assets", "ScriptableObjects");
        }
        Debug.Log(folderPath);
        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(folderPath + "/New " + typeof(ShapeDimensions).ToString() + ".asset");

        AssetDatabase.CreateAsset(asset, assetPathAndName);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;

        return asset;
    }
}
#endif