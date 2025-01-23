using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aspect : MonoBehaviour
{
    public float targetAspect = 16f / 10f; // Desired aspect ratio (16:10)

    void Start()
    {
        SetAspectRatio();
    }

    void SetAspectRatio()
    {
        // Get the current screen's aspect ratio
        float screenAspect = (float)Screen.width / Screen.height;

        // Calculate the scale factor to match the target aspect ratio
        float scaleHeight = screenAspect / targetAspect;

        Camera mainCamera = Camera.main;

        if (scaleHeight < 1.0f) // Add letterbox (top and bottom black bars)
        {
            Rect rect = mainCamera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            mainCamera.rect = rect;
        }
        else // Add pillarbox (left and right black bars)
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = mainCamera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            mainCamera.rect = rect;
        }
    }

    void OnPreCull()
    {
        // Ensure black bars are rendered outside the camera viewport
        GL.Clear(true, true, Color.black);
    }
}
