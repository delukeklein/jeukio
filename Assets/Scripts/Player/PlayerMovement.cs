using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour, PlayerInputActions.IPlayerActions
{
    private PlayerInputActions playerInputActions;

    private void Start()
    {
        playerInputActions = new PlayerInputActions();

        playerInputActions.Player.SetCallbacks(this);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log("LOL");
    }

    public void OnMove(InputAction.CallbackContext context)
    {

    }
}