using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>Moves a player on the XZ plane using the new Input System.</summary>
[RequireComponent(typeof(CharacterController))]
public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField, Min(0.1f)] private float moveSpeed = 5f;
    private CharacterController controller;
    private InputAction moveAction;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
        moveAction = new InputAction("Move", InputActionType.Value);
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w").With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/s").With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/a").With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/d").With("Right", "<Keyboard>/rightArrow");
    }

    private void OnEnable() => moveAction.Enable();
    private void OnDisable() => moveAction.Disable();
    private void OnDestroy() => moveAction.Dispose();

    private void Update()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();
        Vector3 direction = new Vector3(input.x, 0f, input.y);
        controller.Move(direction * (moveSpeed * Time.deltaTime));
    }
}
