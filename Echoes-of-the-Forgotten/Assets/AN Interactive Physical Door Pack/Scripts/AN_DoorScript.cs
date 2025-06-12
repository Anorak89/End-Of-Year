using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AN_DoorScript : MonoBehaviour
{
    [Header("Basic Door Settings")]
    public bool Locked = false;
    public bool Remote = false;
    public bool CanOpen = true;
    public bool CanClose = true;

    [Header("Key Locks")]
    public bool RedLocked = false;
    public bool BlueLocked = false;

    private PlayerMovement player;

    [Header("Door State")]
    public bool isOpened = false;
    [Range(0f, 4f)]
    public float OpenSpeed = 2f;

    private Quaternion closedRotation;
    private Quaternion targetRotation;
    private bool isRotating = false;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        closedRotation = transform.rotation;

        // Instead of hardcoding -90, rotate 90 degrees from current Y
        Vector3 openEuler = transform.eulerAngles + new Vector3(0f, -90f, 0f);
        targetRotation = Quaternion.Euler(openEuler);
    }

    void Update()
    {
        if (!Remote && Input.GetKeyDown(KeyCode.E) && NearView() && !isOpened)
        {
            Action();
        }

        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, OpenSpeed * 100f * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.5f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }
    }

    public void Action()
    {
        if (Locked || isOpened) return;

        // Unlock with key
        if (RedLocked && player != null && player.hasRedKey)
        {
            RedLocked = false;
            player.hasRedKey = false;
        }

        if (BlueLocked && player != null && player.hasBlueKey)
        {
            BlueLocked = false;
            player.hasBlueKey = false;
        }

        if (!RedLocked && !BlueLocked && CanOpen)
        {
            isOpened = true;
            isRotating = true;
        }
    }

    bool NearView()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        Vector3 direction = transform.position - Camera.main.transform.position;
        float angleView = Vector3.Angle(Camera.main.transform.forward, direction);
        return distance < 3f;
    }
}
