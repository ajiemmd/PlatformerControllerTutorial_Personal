using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] VoidEventChannel levelClearedEventChannel;

    PlayerGroundDetector groundDetector;

    PlayerInput input;

    Rigidbody rigidBody;

    public AudioSource VoicePlayer { get; private set; }

    public bool Victory { get; private set; }
    public bool CanAirJump { get; set; }

    public bool IsGrounded => groundDetector.IsGrounded;

    public bool IsFalling => rigidBody.velocity.y < 0 && !IsGrounded;

    public float MoveSpeed => Mathf.Abs(rigidBody.velocity.x);

    private void Awake()
    {
        groundDetector = GetComponentInChildren<PlayerGroundDetector>();
        input = GetComponent<PlayerInput>();
        rigidBody = GetComponent<Rigidbody>();
        VoicePlayer = GetComponentInChildren<AudioSource>();
    }

    private void OnEnable()
    {
        levelClearedEventChannel.AddListener(OnLevelCleared);
    }

    void OnLevelCleared()
    {
        Victory = true;
    }

    internal void OnDefeated()
    {
        input.DisableGamePlayInputs();

        rigidBody.velocity = Vector3.zero;
        rigidBody.useGravity = false;
        rigidBody.detectCollisions = false;

        GetComponent<StateMachine>().SwitchState(typeof(PlayerState_Defeated));
    }

    private void Start()
    {
        input.EnableGamePlayInputs();
    }

    private void OnDisable()
    {
        levelClearedEventChannel.RemoveListener(OnLevelCleared);
    }

    public void Move(float speed)
    {
        if (input.Move)
        {
            transform.localScale = new Vector3(input.AxisX, 1f, 1f);
        }
        SetVelocityX(speed * input.AxisX);
    }

    public void SetVelocity(Vector3 velocity)
    {
        rigidBody.velocity = velocity;
    }

    public void SetVelocityX(float velocityX)
    {
        rigidBody.velocity = new Vector3(velocityX, rigidBody.velocity.y);
    }

    public void SetVelocityY(float velocityY)
    {
        rigidBody.velocity = new Vector3(rigidBody.velocity.x, velocityY);

    }

    public void SetUseGravity(bool value)
    {
        rigidBody.useGravity = value;
    }

}
