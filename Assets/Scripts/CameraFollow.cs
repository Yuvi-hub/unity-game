using UnityEngine;

/// <summary>Follows the player while preserving the configured camera offset.</summary>
public sealed class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0f, 12f, -10f);
    private void LateUpdate()
    {
        if (target != null) transform.position = target.position + offset;
    }
    public void Configure(Transform followTarget, Vector3 followOffset)
    {
        target = followTarget;
        offset = followOffset;
    }
}
