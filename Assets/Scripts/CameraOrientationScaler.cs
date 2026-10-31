
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraOrientationScaler : MonoBehaviour
{
    [SerializeField]
    private float landscapeOrthographicSize = 5f;

    [SerializeField]
    private float referenceAspectRatio = 16f / 9f;

    private Camera targetCamera;

    private void Awake()
    {
        targetCamera = GetComponent<Camera>();
        targetCamera.orthographic = true;
    }

    private void Start()
    {
        UpdateCameraSize();
    }

    private void Update()
    {
        UpdateCameraSize();
    }

    private void UpdateCameraSize()
    {
        float currentAspectRatio =
            (float)Screen.width / Screen.height;

        float newSize = landscapeOrthographicSize *
            referenceAspectRatio / currentAspectRatio;

        targetCamera.orthographicSize = newSize;
    }
}
