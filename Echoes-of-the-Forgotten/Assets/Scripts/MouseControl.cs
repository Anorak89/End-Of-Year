using UnityEngine;

public class MouseControl : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Hide & lock the cursor
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevent flipping

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Look up/down
        playerBody.Rotate(Vector3.up * mouseX); // Turn body left/right
    }
}
