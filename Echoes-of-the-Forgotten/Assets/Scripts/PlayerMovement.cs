using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Transform orientation; 

    private CharacterController controller;
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
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = (orientation.forward * vertical + orientation.right * horizontal).normalized;

        controller.Move(moveDir * moveSpeed * Time.deltaTime);
    }
}
