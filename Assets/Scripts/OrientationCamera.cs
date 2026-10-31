using UnityEngine;

/// <summary>Keeps orthographic world units per screen pixel stable when aspect ratio changes.</summary>
[RequireComponent(typeof(Camera))]
public sealed class OrientationCamera : MonoBehaviour
{
    [SerializeField, Min(0.01f)] private float referenceOrthographicSize = 7f;
    [SerializeField, Min(1)] private int referencePixelHeight = 1080;
    private Camera targetCamera;
    private int lastHeight;

    private void Awake()
    {
        targetCamera = GetComponent<Camera>();
        targetCamera.orthographic = true;
    }

    private void LateUpdate()
    {
        int height = targetCamera.pixelHeight;
        if (height <= 0 || height == lastHeight) return;
        lastHeight = height;
        // Orthographic visible vertical span is 2 * orthographicSize.
        // Scaling by pixel height preserves apparent object height in pixels.
        targetCamera.orthographicSize = referenceOrthographicSize * height / referencePixelHeight;
    }
}
