using UnityEngine;
using UnityEngine.SceneManagement;
public class Teleport : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("/Scenes/Room 2.unity", LoadSceneMode.Single);
        }
    }
}
