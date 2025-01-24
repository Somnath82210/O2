using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class comicfade : MonoBehaviour
{
    [SerializeField] GameObject comic;
    Image i;
    float timer = 0f; // Timer to track the current phase
    float fadeInDuration = 0.6f; // Time it takes to fade in
    float stayDuration = 3f;   // Time the image stays fully visible
    float fadeOutDuration = 0.6f; // Time it takes to fade out
    // Start is called before the first frame update
    void Start()
    {
         i  = comic.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer <= fadeInDuration) // Fade in 
        {
            float t = timer / fadeInDuration; // Normalize to 0-1
            SetAlpha(t);
        }
        else if (timer <= fadeInDuration + stayDuration) // Stay visible
        {
            SetAlpha(1f); // Fully opaque
        }
        else if (timer <= fadeInDuration + stayDuration + fadeOutDuration) // Fade out
        {
            float t = 1f - ((timer - fadeInDuration - stayDuration) / fadeOutDuration); // Normalize and invert to 1-0
            SetAlpha(t);
        }
        else // Reset or stop the sequence
        {
            SetAlpha(0f); // Fully transparent
        }
        if (i.color.a == 0)
        {
            SceneManager.LoadScene(2);
        }
    }
    void SetAlpha(float alpha)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, Mathf.Clamp01(alpha));
    }
}
