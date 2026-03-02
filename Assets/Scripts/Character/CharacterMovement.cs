using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Animator))]
public class CharacterMovement : LevelSingleton<CharacterMovement>
{
    [Header("Necessary Movement Components")]
    [SerializeField] private PlayableStats stats;
    [SerializeField] private Rigidbody charRigidBody;
    [SerializeField] private Animator charAnimator;
    [SerializeField] private Transform startPoint;

    [Header("Character Movement Settings")]
    [SerializeField] private float charRotationSpeed;
    [SerializeField] private float charDashSpeed;

    // Movement Speed Settings
    public IStamina baseStamina;
    private float charMovementSpeed;
    private bool isDashing = false;

    private Vector3 userInput;

    protected override void Awake()
    {
        base.Awake();
        userInput = Vector3.zero;
        if (FindAnyObjectByType<LevelEntrance>())
        {
            startPoint = FindAnyObjectByType<LevelEntrance>().transform;
            GetCharacterInPosition(startPoint);
        }
        charMovementSpeed = stats.GetStatValue("Speed");
        baseStamina = new BaseStamina(stats.GetStatValue("Stamina"));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift)) 
            Dash();
        GatherInput();
        Look();
    }

    void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Gets the key inputs from the user to understand which keys are pressed
    /// </summary>
    private void GatherInput()
    {
        userInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    }

    /// <summary>
    /// Calculates the relative position of the character, as we are in isometric view and handles their rotation
    /// </summary>
    private void Look()
    {
        if (userInput != Vector3.zero) {
            var matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
            var skewedInput = matrix.MultiplyPoint3x4(userInput);
            var rotation = Quaternion.LookRotation(skewedInput, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, charRotationSpeed);
            // Movement animation is based on Blend Tree, that's why we change the boolean according to a float variable
            charAnimator.SetBool("IsWalking", true);
            charAnimator.SetFloat("Walking", charAnimator.GetBool("IsWalking") ? 1f : 0f);
        } else
        {
            charAnimator.SetBool("IsWalking", false);
            charAnimator.SetFloat("Walking", charAnimator.GetBool("IsWalking") ? 1f : 0f);
        }
    }

    /// <summary>
    /// By getting the rigid body of the character, it moves the character to a specific speed at the position
    /// it translates.
    /// </summary>
    private void Move()
    {
        if (userInput == Vector3.zero) return;
        charRigidBody.MovePosition(transform.position + (transform.forward * userInput.magnitude) * charMovementSpeed * Time.deltaTime);
    }

    private void Dash()
    {
        if(baseStamina.CanDash() && !isDashing)
        {
            StartCoroutine(baseStamina.DashRoutine(
                onDashStart: () => {
                    isDashing = true;
                    charMovementSpeed *= charDashSpeed;
                },
                onDashEnd: () => {
                    charMovementSpeed /= charDashSpeed;
                    isDashing = false;
                }
            ));         
        }
    }

    public void GetCharacterInPosition(Transform sPoint)
    {
        charRigidBody.position = sPoint.position;
        charRigidBody.rotation = sPoint.rotation;
    }
}


// https://www.youtube.com/watch?v=8ZxVBCvJDWk