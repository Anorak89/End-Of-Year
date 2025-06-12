using UnityEngine;
using UnityEngine.SceneManagement; // Needed to change scenes

public class EnemyCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        PlayerMovement player = other.GetComponent<PlayerMovement>();
        if (player != null)
        {
            Debug.Log("Player collided with enemy. Loading 'Jumpscare' scene...");
            SceneManager.LoadScene("Jumpscare-Room3");
        }
    }
}
