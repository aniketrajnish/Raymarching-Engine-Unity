using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class RaymarchRenderer : MonoBehaviour
{
    [HideInInspector] public bool editorStateChange;
    public enum Shape
    {
        Shpere,
        Torus,
        CappedTorus,
        Link,
        Cone,
        InfCone,
        Plane,
        HexPrism,
        TriPrism,
        Capsule,
        InfiniteCylinder,
        Box,
        RoundBox,
        RoundedCylinder,
        CappedCone,
        BoxFrame,
        SolidAngle,
        CutSphere,
        CutHollowSphere,
        DeathStar,
        RoundCone,
        Ellipsoid,
        Rhombus,
        Octahedron,
        Pyramid,
        Triangle,
        Quad,
        Fractal,
        Tesseract
    };
    public enum Operation
    {
        Union,
        Subtract,
        Intersect
    };

    public Shape shape;
    public Operation operation;
    public Color color = Color.red;

    [Range(0, 100)]
    public float blendFactor;
    public ShapeDimensions dimensions;

#if UNITY_EDITOR
    void CheckAndCreateAsset()
    {
        if (this == null || gameObject == null || !gameObject.activeInHierarchy)
            return;

        if (dimensions == null)
            dimensions = CreateShapeDimensionsAsset();

        else if (!PrefabUtility.IsPartOfPrefabAsset(this))
        {
            var allRenderers = FindObjectsOfType<RaymarchRenderer>();
            int sharedCount = 0;
            foreach (var renderer in allRenderers)
            {
                if (renderer != this && renderer.dimensions == dimensions)
                    sharedCount++;
            }
            //print(sharedCount);
            if (sharedCount > 0)
                dimensions = CloneShapeDimensionsAsset(dimensions);
        }
    }

    ShapeDimensions CloneShapeDimensionsAsset(ShapeDimensions originalAsset)
    {
        ShapeDimensions clonedAsset = Instantiate(originalAsset);
        string folderPath = "Assets/5. ScriptableObject/GeneratedShape";

        if (!System.IO.Directory.Exists(folderPath))
        {
            AssetDatabase.CreateFolder("Assets", "ScriptableObjects");
        }

        string clonedAssetPath = AssetDatabase.GenerateUniqueAssetPath(folderPath + "/Cloned " + typeof(ShapeDimensions).ToString() + ".asset");
        AssetDatabase.CreateAsset(clonedAsset, clonedAssetPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = clonedAsset;

        return clonedAsset;
    }

    ShapeDimensions CreateShapeDimensionsAsset()
    {
        ShapeDimensions asset = ScriptableObject.CreateInstance<ShapeDimensions>();

        string folderPath = "Assets/5. ScriptableObject/GeneratedShape";

        if (!System.IO.Directory.Exists(folderPath))
        {
            AssetDatabase.CreateFolder("Assets", "ScriptableObjects");
        }
        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(folderPath + "/New " + typeof(ShapeDimensions).ToString() + ".asset");

        AssetDatabase.CreateAsset(asset, assetPathAndName);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;

        return asset;
    }
    /* private void OnDestroy()
     {
         if (!editorStateChange)
         {
             string path = AssetDatabase.GetAssetPath(dimensions);
             AssetDatabase.DeleteAsset(path);
             AssetDatabase.SaveAssets();
         }
     }*/
#endif
}
