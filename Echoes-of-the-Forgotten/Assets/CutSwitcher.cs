using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutSwitcher : MonoBehaviour
{
    public string sceneToLoad; // Set this in the Inspector
    private PlayableDirector director;

    void Start()
    {
        director = GetComponent<PlayableDirector>();
        if (director != null)
        {
            director.stopped += OnTimelineStopped;
        }
    }

    void OnTimelineStopped(PlayableDirector pd)
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}