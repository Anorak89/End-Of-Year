using UnityEngine;
using TMPro;

public class FlashlightTextReveal : MonoBehaviour
{
    public TMP_Text text;
    public Transform flashlight;
    public float revealDistance = 10f;

    void Update()
    {
        Vector3 direction = transform.position - flashlight.position;
        Ray ray = new Ray(flashlight.position, direction.normalized);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, revealDistance))
        {
            if (hit.transform == transform)
            {
                Color c = text.faceColor;
                c.a = Mathf.MoveTowards(c.a, 1f, Time.deltaTime * 3f); // fade in
                text.faceColor = c;
                return;
            }
        }

        // fade out if not hit
        Color current = text.faceColor;
        current.a = Mathf.MoveTowards(current.a, 0f, Time.deltaTime * 3f);
        text.faceColor = current;
    }
}
