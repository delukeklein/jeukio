using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour, PlayerInputActions.IPlayerActions
{
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float verticalSpeed;
    [SerializeField] private float jumpVelocity;

    [SerializeField] private float horizontalSensitivity;
    [SerializeField] private float verticalSensitivity;

    private bool jumped;

    private Vector2 movement;
    private Vector2 mouse;

    [SerializeField] private Transform head;

    private Rigidbody rigidbody;

    private PlayerInputActions playerInputActions;

    public void OnJump(InputAction.CallbackContext context) => jumped = context.started && !jumped;

    public void OnMove(InputAction.CallbackContext context) => movement = context.ReadValue<Vector2>();

    public void OnRotate(InputAction.CallbackContext context) => mouse = context.ReadValue<Vector2>();

    private void OnEnable() => playerInputActions.Player.Enable();

    private void OnDisable() => playerInputActions.Player.Disable();

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();

        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.SetCallbacks(this);
    }

    private void Update()
    {
        transform.Rotate((Vector2.up * mouse.x) * verticalSensitivity * Time.deltaTime);

        head.Rotate((-Vector2.right * mouse.y) * horizontalSensitivity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        rigidbody.AddRelativeForce(horizontalSpeed * movement.x, jumped ? jumpVelocity : 0, verticalSpeed * movement.y);
    }
}