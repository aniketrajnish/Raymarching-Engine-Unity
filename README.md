# Raymarching-Engine-Unity
A fast GPU-accelerated raymarching engine for Unity with support for over 28 primitives (including fractals, n-dimensional objects, volumetric clouds) and set operations (Union, Subtract, Intersect). Includes a custom interface for manipulating shader parameters through the editor.<br>

https://user-images.githubusercontent.com/58925008/155891674-fdb4e1e8-3e80-447b-9439-aec03d8f34eb.mp4

## Updates
#### v002
* The engine now stores the dimensions of the shapes as scriptable objects, to keep multiple instances of same shape persistant across sessions.
* Added support for Ambient Occlussion, Hard/Soft Shadows and various render setting exposed for the users to play around with.
* Download the `.unitypackage` [here](https://github.com/aniketrajnish/Raymarching-Engine-Unity/releases/tag/v002).

## Rendering the shapes provided
* Attach `Raymarcher.cs` to the Main Camera and `RaymarchRenderer.cs` to an empty gameobject.
* Drag the `ImageEffectRaymarcher.shader` in Shader field of `Raymarcher.cs` in inspector and direction light to the Sun's transform field.
* Click on `Create New Dimensions` in the `RaymarchRenderer.cs` to create a scriptable object to hold the dimesnion data of the shapes.
* You can control the following settings for the raymarching using the `Raymarcher` componenet-
  | Category             | Variable         | Description                                                                  |
  |----------------------|------------------|------------------------------------------------------------------------------|
  | **General Settings** | Shader           | Shader used for raymarching.                                                 |
  |                      | Sun              | Directional light in the scene.                                              |
  |                      | Loop             | Repetition of structures in the raymarching shader.                          |  
  | **Light Settings**   | Is Lit           | Toggle lighting calculations on/off.                                         |
  |                      | Is Shadow Hard   | Toggle between hard and soft shadows.                                        |
  |                      | Is AO            | Enable or disable Ambient Occlusion.                                         |
  |                      | Light Col        | Color of the light.                                                          |
  |                      | Light Intensity  | Intensity of the light.                                                      |
  |                      | Shadow Intensity | Intensity of shadows.                                                        |
  |                      | Shadow Min       | Minimum shadow distance.                                                     |
  |                      | Shadow Max       | Maximum shadow distance.                                                     |
  |                      | Shadow Smooth    | Smoothness of shadow edges.                                                  |
  |                      | AO Step          | Step size for AO calculation.                                                |
  |                      | AO Intensity     | Intensity of AO.                                                             |
  |                      | AO Iteration     | Number of iterations for AO calculation.                                     |
  | **Render Settings**  | Max Steps        | Maximum number of steps for raymarching.                                     |
  |                      | Max Dist         | Maximum distance to raymarch before considering a hit.                       |
  |                      | Surf Dist        | Threshold for considering a hit in raymarching.                              |
* You can control the following properties of the individual shapes using the `RaymarchRenderer` componnent-
  | Category              | Variable         | Description                                                               |
  |-----------------------|------------------|---------------------------------------------------------------------------|
  | **Default Inspector** | Shape            | 4D shape to be rendered.                                                  |
  |                       | Operation        | Operation to be performed (union, subtraction, intersection).             |
  |                       | Color            | Color of the shape.                                                       |
  |                       | Create New Dimensions | Button to create new dimenion scriptable object for the shape |
  |                       | Dimensions       | Scriptable Object holding the shape's dimension data.                     |
  | **Shape Dimensions**  | Dimension Props  | The dimension properties based on the chosen 4D shape.                    |

## Rendering a custom shape
* Append the distance function of the shape in `DFs.cginc` like
    ```
    float sdShape(float3 p, // dimension parameters)	
    {
        // distance function here
    }
    ```   
* Append the distance function created above in `GetDist()` in the `ImageEffectRaymarcher.shader`.
    ```
    float GetDist(Shape shape, float3 p) {
        switch (shape.shapeIndex) {
        case n:
            return sdShape(float3 p, // dimension parameters);
        }
    }
    ```
* Add the shape data in the scriptable object `ShapeDimensions.cs`
  ```
  public float shapeDimension = default dimenison
  ```
* Add the shape in Shape enum in `RaymarchRenderer.cs` 
    ```
    public enum Shape {
        // shape name
    };  
    ```
* Make the dimension array in `Helpers.cs` to be sent as a compute buffer to the Raymarching shader.
    ```
    public static vector12 GetDimensionVectors(int i)
    {
        //dimension vector12 object
    }
    ```
* Finally make a custom editor for your shape in the `PropertiesEditor.cs`
    ```
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        RaymarchRenderer renderer = (RaymarchRenderer)target;        
         
        if (GUILayout.Button("Create New Dimensions"))
           renderer.dimensions = CreateShapeDimensionsAsset();
         
        if (renderer.dimensions == null)
           return;
    
        switch (renderer.shape)
        {
            //property editor here
        }
    }
