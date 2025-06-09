using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport3 : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(0, 1, 0); // Change to desired spawn point

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnManager.spawnPosition = targetPosition;
            SceneManager.LoadScene("Room 3");
        }
    }
}
