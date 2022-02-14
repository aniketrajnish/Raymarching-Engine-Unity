# Raymarching-Engine
 Writing a raymarching engine for Unity.<br><br>


https://user-images.githubusercontent.com/58925008/152696897-970a5a67-9007-4f17-96b2-a4c48f312d6b.mp4

## Rendering a shape

* Append the distance functions in `DFs.cginc` like
```
float sdShape(float3 p, // dimension parameters)	
{
    // distance function here
}
```   
* Appednd the distance function created above in `GetDist()` in `Raymarcher.shader` 
```
float GetDist(Shape shape, float3 p) {
    switch (shape.shapeIndex) {
    case n:
        return sdShape(float3 p, // dimension parameters);
    }
}
```
* Add the shape in Shape enum and create a struct for its default dimension parameters in `RaymarchRenderer.cs` 
```
public enum Shape {
    // shape name
};

public struct shapeDimensions
{
   // default shape dimensions;
};
```
* Make the dimension array in `Helpers.cs` to be sent as a compute buffer to the Raymarching shader.
```
public static vector12 GetDimensionVectors(int i)
{
    //dimension array
}
```
* Finally make a custom editor for your shape in the `PropertiesEdior.cs`
```
public override void OnInspectorGUI()
{
    base.OnInspectorGUI();
    EditorGUILayout.Space();
    EditorGUILayout.LabelField("Dimensions", EditorStyles.boldLabel);
    RaymarchRenderer rr = (RaymarchRenderer)target;
    switch ((int)rr.shape)
    {
        //property editor here
    }
}
```
* Attach `RaymarchRenderer.cs` and `Raymarcher.cs` to a gameobject having a mesh renderer and set the properties and type of shape to render in the inspector.




