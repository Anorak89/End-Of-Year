using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using System.Collections;

public class CutSwitcher : MonoBehaviour
{
    [Tooltip("Name of the scene to load after the Timeline ends")]
    public string sceneToLoad;

    [Tooltip("Optional delay in seconds after the timeline ends before switching scenes")]
    public float delayBeforeLoad = 0.2f;

    [Tooltip("Optional tag to identify the player object if it's persistent")]
    public string playerTag = "Player";

    private PlayableDirector director;

    void Start()
    {
        director = GetComponent<PlayableDirector>();
        if (director != null)
        {
            director.stopped += OnTimelineStopped;
        }
        else
        {
            Debug.LogError("[CutSwitcher] No PlayableDirector found.");
        }
    }

    void OnTimelineStopped(PlayableDirector pd)
    {
        StartCoroutine(LoadSceneAfterDelay(delayBeforeLoad));
    }

    IEnumerator LoadSceneAfterDelay(float delay)
    {
        if (delay > 0f)
            yield return new WaitForSeconds(delay);

        if (string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.LogError("[CutSwitcher] Scene name not set.");
            yield break;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;

        GameObject spawnPoint = GameObject.Find("SpawnPoint");
        if (spawnPoint == null)
        {
            Debug.LogWarning("[CutSwitcher] No GameObject named 'SpawnPoint' found in the scene.");
            return;
        }

        GameObject player = GameObject.FindWithTag(playerTag);
        if (player == null)
        {
            Debug.LogWarning("[CutSwitcher] No GameObject with tag '" + playerTag + "' found.");
            return;
        }

        CharacterController controller = player.GetComponent<CharacterController>();
        if (controller != null)
        {
            controller.enabled = false; // Temporarily disable to avoid movement conflict
        }

        player.transform.position = spawnPoint.transform.position;
        player.transform.rotation = spawnPoint.transform.rotation;

        if (controller != null)
        {
            controller.enabled = true;
        }

        Debug.Log("[CutSwitcher] Player moved to SpawnPoint.");
    }

    void OnDisable()
    {
        if (director != null)
        {
            director.stopped -= OnTimelineStopped;
        }
    }
}
