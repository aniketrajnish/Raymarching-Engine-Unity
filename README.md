# Raymarching-Engine-Unity
A raymarching engine for Unity.<br>

https://user-images.githubusercontent.com/58925008/155891674-fdb4e1e8-3e80-447b-9439-aec03d8f34eb.mp4

## Rendering a shape

* Append the distance functions in `DFs.cginc` like
```
float sdShape(float3 p, // dimension parameters)	
{
    // distance function here
}
```   
* Append the distance function created above in `GetDist()` in `Raymarcher.shader` (if using the unlit shader) or in the `ImageEffectRaymarcher.shader` (if using the Image Effect shader).
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
## Implementation for Image Effect Shader
* Attach `Raymarcher.cs` to the Main Camera and `RaymarchRenderer.cs` to an empty gameobject and set the properties and type of shape to render in the inspector.
* Drag the `ImageEffectRaymarcher.shader` in Shader field of `Raymarcher.cs` in inspector and direction light to the Sun's transform field.

## Implementation for Unlit Shader
* Append the following lines in `Raymarcher` class of `Raymarcher.cs`
```
 private void Awake()
 {
     GetComponent<MeshRenderer>().material = _raymarchMaterial;
 }
 private void OnEnable()
 {
     EditorApplication.update += OnUpdate;
 }   
 private void OnUpdate()
 {
     RaymarchRender();
     EditorApplication.QueuePlayerLoopUpdate();
 } 
 private void Update()
 {
     RaymarchRender();
 }
 private void OnDisable()
 {
     EditorApplication.update -= OnUpdate;
     foreach (var buffer in disposable)
     {
         buffer.Dispose();
     }
 }
 
 // Append this in RaymarchRender function
 void RaymarchRender()
 {  
     for (int i = 0; i < renderers.Count; i++)
     {
         if (renderers[i] == GetComponent<RaymarchRenderer>())            
             _raymarchMaterial.SetInt("rank", i);
     }
 }
```
* Attach `RaymarchRenderer.cs` and `Raymarcher.cs` to a gameobject having a mesh renderer and set the properties and type of shape to render in the inspector.
* Drag the `Raymarcher.shader` in Shader field of `Raymarcher.cs` in inspector and direction light to the Sun's transform field. 




