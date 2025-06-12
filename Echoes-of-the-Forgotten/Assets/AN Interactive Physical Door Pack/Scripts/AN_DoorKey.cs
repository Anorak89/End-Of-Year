using UnityEngine;
public class AN_DoorKey : MonoBehaviour
{
    public bool isRedKey = true;
    PlayerMovement player;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        if (NearView() && Input.GetKeyDown(KeyCode.E))
        {
            if (isRedKey) player.hasRedKey = true;
            else player.hasBlueKey = true;

            Destroy(gameObject);

        }
    }

    bool NearView()
    {
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        return distance < 2f;
    }
}
