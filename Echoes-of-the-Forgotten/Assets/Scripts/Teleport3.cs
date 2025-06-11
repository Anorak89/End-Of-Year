using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport3 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("Room 3");
    }
}
