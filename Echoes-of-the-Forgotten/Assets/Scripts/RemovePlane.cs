using UnityEngine;

public class RemovePlane : MonoBehaviour
{
    public void Remove()
    {
        Debug.LogWarning("Attempting to remove the wall...");
        GameObject wall = GameObject.Find("Wall");

        if (wall != null)
        {
            Destroy(wall);
        }
        else
        {
            Debug.LogWarning("No GameObject named 'Wall' found in the scene.");
        }
    }
}
