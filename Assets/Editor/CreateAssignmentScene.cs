using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

/// <summary>Generates the complete sample scene without external assets.</summary>
public static class CreateAssignmentScene
{
    [MenuItem("Assignment/Create Complete Demo Scene")]
    public static void Create()
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
        var floor = GameObject.CreatePrimitive(PrimitiveType.Cube);
        floor.name = "Ground";
        floor.transform.position = new Vector3(0f, -0.5f, 0f);
        floor.transform.localScale = new Vector3(44f, 1f, 44f);
        SetColor(floor, new Color(0.16f, 0.24f, 0.27f));

        var player = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        player.name = "Player";
        player.transform.position = new Vector3(0f, 1.05f, 0f);
        Object.DestroyImmediate(player.GetComponent<CapsuleCollider>());
        var controller = player.AddComponent<CharacterController>();
        controller.height = 2f;
        controller.radius = 0.5f;
        player.AddComponent<PlayerMovement>();
        SetColor(player, new Color(0.2f, 0.9f, 0.8f));

        for (int i = 0; i < 18; i++)
        {
            float x = ((i * 7) % 35) - 17f;
            float z = ((i * 11) % 35) - 17f;
            if (Mathf.Abs(x) < 3f && Mathf.Abs(z) < 3f) continue;
            var obstacle = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obstacle.name = "Obstacle_" + i;
            float size = 1.5f + (i % 3);
            obstacle.transform.position = new Vector3(x, size / 2f, z);
            obstacle.transform.localScale = new Vector3(size, size, size);
            SetColor(obstacle, Color.HSVToRGB((i * 0.13f) % 1f, 0.55f, 0.85f));
        }

        var sun = new GameObject("Directional Light");
        var light = sun.AddComponent<Light>();
        light.type = LightType.Directional;
        light.intensity = 1.3f;
        sun.transform.rotation = Quaternion.Euler(50f, -35f, 0f);

        var mainObject = new GameObject("Main Camera");
        mainObject.tag = "MainCamera";
        var mainCamera = mainObject.AddComponent<Camera>();
        mainCamera.orthographic = true;
        mainCamera.orthographicSize = 7f;
        mainCamera.depth = 0f;
        mainCamera.clearFlags = CameraClearFlags.Skybox;
        mainObject.transform.rotation = Quaternion.Euler(48f, 0f, 0f);
        mainObject.transform.position = player.transform.position + new Vector3(0f, 12f, -10f);
        mainObject.AddComponent<CameraFollow>().Configure(player.transform, new Vector3(0f, 12f, -10f));
        mainObject.AddComponent<OrientationCamera>();

        var mapObject = new GameObject("Mini-map Camera");
        var mapCamera = mapObject.AddComponent<Camera>();
        mapCamera.orthographic = true;
        mapCamera.orthographicSize = 16f;
        mapCamera.depth = 1f;
        mapCamera.clearFlags = CameraClearFlags.SolidColor;
        mapCamera.backgroundColor = new Color(0.05f, 0.08f, 0.1f);
        mapCamera.rect = new Rect(0.77f, 0.74f, 0.21f, 0.23f);
        mapObject.transform.position = player.transform.position + Vector3.up * 28f;
        mapObject.transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        mapObject.AddComponent<MiniMapFollow>().Configure(player.transform);

        System.IO.Directory.CreateDirectory("Assets/Scenes");
        EditorSceneManager.SaveScene(scene, "Assets/Scenes/MiniMapDemo.unity");
        EditorBuildSettings.scenes = new[] { new EditorBuildSettingsScene("Assets/Scenes/MiniMapDemo.unity", true) };
        Debug.Log("Demo scene created. Press Play and use WASD or arrow keys.");
    }

    private static void SetColor(GameObject obj, Color color)
    {
        var material = new Material(Shader.Find("Universal Render Pipeline/Lit") ?? Shader.Find("Standard"));
        material.color = color;
        obj.GetComponent<Renderer>().sharedMaterial = material;
    }
}
