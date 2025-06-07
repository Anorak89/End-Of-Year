using UnityEngine;

public class SpawnInRoom : MonoBehaviour
{
    void Start()
    {
        GameObject spawnPoint = GameObject.Find("SpawnPoint");
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null && spawnPoint != null)
        {
            player.transform.position = spawnPoint.transform.position;
            player.transform.rotation = spawnPoint.transform.rotation;
        }
        else
        {
            Debug.LogWarning("Spawn point or player not found.");
        }
    }
}
