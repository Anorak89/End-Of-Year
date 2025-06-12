using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleport2 : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene("CutRoom 2");
    }
}
