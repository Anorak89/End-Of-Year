using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_Teleport : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("End");
    }
}