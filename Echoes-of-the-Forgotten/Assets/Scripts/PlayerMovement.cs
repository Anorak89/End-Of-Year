using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private CharacterController controller;

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
        Vector3 inputDir = new Vector3(horizontal, 0f, vertical).normalized;

        Vector3 rotatedDir = Quaternion.Euler(0f, -90f, 0f) * inputDir;

        controller.Move(rotatedDir * moveSpeed * Time.deltaTime);
    }
}
