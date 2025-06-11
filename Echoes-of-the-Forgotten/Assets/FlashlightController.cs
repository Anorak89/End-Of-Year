using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    private Light flashlight;
    public Transform cameraTransform; // Assign this to the Main Camera in the inspector

    void Start()
    {
        flashlight = GetComponent<Light>();
        if (flashlight == null)
        {
            Debug.LogError("No Light component found on the Flashlight GameObject!");
        }
    }

    void Update()
    {
        // Follow the camera's position and rotation
        transform.position = cameraTransform.position;
        transform.rotation = cameraTransform.rotation;

        // Toggle flashlight with F key
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
