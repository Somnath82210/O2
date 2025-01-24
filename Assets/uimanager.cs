using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] Image title; // Reference to the Image component
    float timer = 0f; // Timer to track the current phase
    float fadeInDuration = 0.6f; // Time it takes to fade in
    float stayDuration = 0.6f;   // Time the image stays fully visible
    float fadeOutDuration = 0.6f; // Time it takes to fade out
    [SerializeField] GameObject menu;
    [SerializeField] GameObject panel;

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
        if (title.color.a == 0)
        {
            menu.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(false);
        }


    }

    void SetAlpha(float alpha)
    {
        title.color = new Color(title.color.r, title.color.g, title.color.b, Mathf.Clamp01(alpha));
    }

    public void onplay()
    {
        SceneManager.LoadScene(1);
    }
    public void exit()
    {
        Application.Quit();
    }

    public void control()
    {
        panel.SetActive(true);
    }
}