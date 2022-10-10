using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    PlayerInputActions playerInputActions;

    Vector2 axes => playerInputActions.GamePlay.Axes.ReadValue<Vector2>();

    public bool Jump => playerInputActions.GamePlay.Jump.WasPressedThisFrame();
    public bool StopJump => playerInputActions.GamePlay.Jump.WasReleasedThisFrame();

    public bool Move => AxisX != 0;

    public float AxisX => axes.x;


    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }


    public void EnableGamePlayInputs()
    {
        playerInputActions.GamePlay.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }





}
