using System.IO;
using UnityEditor;
using UnityEngine;

public class CarCreatorWindow : EditorWindow
{
    private string name;
    private GameObject model;
    private Texture textureBody;
    private int topSpeed;
    private int grip;
    private int acceleration;
    private int cost;
    
    [MenuItem("Tools/Car Creator")]
    public static void ShowWindow()
    {
        GetWindow<CarCreatorWindow>("Car Creator");
        
    }
    
    
    void OnGUI()
    {
        name = EditorGUILayout.TextField("Name:",name);
        topSpeed = EditorGUILayout.IntField("Base Top speed:", topSpeed);
        grip = EditorGUILayout.IntField("Base Grip:", grip);
        acceleration = EditorGUILayout.IntField("Base Acceleration:", acceleration);
        cost = EditorGUILayout.IntField("Cost:", cost);
        model = EditorGUILayout.ObjectField("Model",model, typeof(GameObject), true) as GameObject;
        textureBody = EditorGUILayout.ObjectField("Texture Body", textureBody, typeof(Texture), true) as Texture;
        if (GUILayout.Button("Create Car"))
        {
            var car = new GameObject(name);
            if (!Directory.Exists("Assets/PlayableCars"))
                AssetDatabase.CreateFolder("Assets", "PlayableCars");
            string localPath = "Assets/PlayableCars/" + name + ".prefab";
            localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);
            var scriptInstance = car.AddComponent<DemocarScript>();
            scriptInstance.acceleration = acceleration;
            scriptInstance.topSpeed = topSpeed;
            scriptInstance.grip = grip;
            scriptInstance.cost = cost;  
            Instantiate(model, car.transform);
            PrefabUtility.SaveAsPrefabAsset(car, localPath);
            DestroyImmediate(car);
        }
    }
    
    
}
