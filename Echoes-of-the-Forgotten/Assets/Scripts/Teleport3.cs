using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport3 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Room 3");
    }
}
