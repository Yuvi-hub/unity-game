using UnityEngine;

/// <summary>Positions the top-down mini-map camera over the player.</summary>
public sealed class MiniMapFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField, Min(1f)] private float height = 28f;
    private void LateUpdate()
    {
        if (target != null) transform.position = target.position + Vector3.up * height;
    }
    public void Configure(Transform followTarget) => target = followTarget;
}
