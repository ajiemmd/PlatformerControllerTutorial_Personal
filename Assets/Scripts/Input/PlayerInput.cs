using System;
using System.Collections;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField]float jumpInputBufferTime = 0.5f;

    WaitForSeconds waitJumpInputBufferTime;

    PlayerInputActions playerInputActions;

    Vector2 axes => playerInputActions.GamePlay.Axes.ReadValue<Vector2>();

    public bool HasJumpInputBuffer { get; set; }

    public bool Jump => playerInputActions.GamePlay.Jump.WasPressedThisFrame();
    public bool StopJump => playerInputActions.GamePlay.Jump.WasReleasedThisFrame();

    public bool Move => AxisX != 0;

    public float AxisX => axes.x;


    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        waitJumpInputBufferTime = new WaitForSeconds(jumpInputBufferTime);
    }

    private void OnEnable()
    {
        playerInputActions.GamePlay.Jump.canceled += delegate
        {
            HasJumpInputBuffer = false;
        };
    }

    //private void OnGUI()
    //{
    //    Rect rect = new Rect(200, 200, 200, 200);
    //    string message = "Has Jump Input Buffer" + HasJumpInputBuffer;
    //    GUIStyle style = new GUIStyle();

    //    style.fontSize = 20;
    //    style.fontStyle = FontStyle.Bold;
    //    GUI.Label(rect, message, style);
    //}

    public void EnableGamePlayInputs()
    {
        playerInputActions.GamePlay.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void DisableGamePlayInputs()
    {
        playerInputActions.GamePlay.Disable();
    }

    public void SetJumpInputBufferTimer()
    {
        StopCoroutine(nameof(JumpInputBufferCoroutine));
        StartCoroutine(nameof(JumpInputBufferCoroutine));
    }

    IEnumerator JumpInputBufferCoroutine()
    {
        HasJumpInputBuffer = true;

        yield return waitJumpInputBufferTime;

        HasJumpInputBuffer = false;
    }



}
