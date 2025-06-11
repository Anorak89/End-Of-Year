using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public Transform spawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            Debug.Log("Player is here");

            // Disable controller before teleporting
            CharacterController controller = player.GetComponent<CharacterController>();
            if (controller != null)
            {
                controller.enabled = false;
                player.transform.position = spawnPoint.position;
                controller.enabled = true;
            }
            else
            {
                Debug.LogWarning("No CharacterController found on player!");
            }
        }
    }
}
