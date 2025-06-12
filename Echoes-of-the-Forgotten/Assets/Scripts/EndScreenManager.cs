using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();  // Only works in builds
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("IntroCut"); // Replace with your main gameplay scene name
    }
}
