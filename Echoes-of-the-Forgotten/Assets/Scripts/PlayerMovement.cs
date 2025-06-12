using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    public float groundCheckDistance = 0.4f;
    public LayerMask groundMask;
    public Transform orientation;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;

    // 🔑 Key Inventory
    public bool hasRedKey = false;
    public bool hasBlueKey = false;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogWarning("No CharacterController found. Adding one automatically.");
            controller = gameObject.AddComponent<CharacterController>();
        }
    }

    void Update()
    {
        // Check if grounded
        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Movement input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = (orientation.forward * vertical + orientation.right * horizontal).normalized;
        controller.Move(moveDir * moveSpeed * Time.deltaTime);

        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
