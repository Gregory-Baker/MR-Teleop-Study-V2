using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomZEDBlinkHandler : MonoBehaviour
{
    public float alpha_init = 1.5f;
    public float current_time = 0.4f;
    public float start_value = 0f;
    public float value_change_multiplier = 0.5f;
    public float duration = 1.5f;

    /// <summary>
    /// Material used to perform the fade.
    /// </summary>
    private Material fader;

    /// <summary>
    /// Current alpha value of the black overlay used to darken the image. 
    /// </summary>
    private float alpha;

    /// <summary>
    /// Start flag. Set to true when the ZED is opened.
    /// </summary>
    private bool start = false;

    /// <summary>
    /// Sets the alpha to above 100% (to add a delay to the effect) and loads the fade material. 
    /// </summary>
	void Start()
    {
        fader = new Material(Resources.Load("Materials/GUI/Mat_ZED_Fade") as Material);
    }

    public void Blink()
    {
        alpha = alpha_init;
        start = true;
    }

    /// <summary>
    /// Applies the darkening effect to the camera's image. 
    /// Called by Unity every time the camera it's attached to renders an image.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="destination"></param>
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (start)
        {
            //Lower the alpha. We use hard-coded values instead of using Time.deltaTime
            //to simplify things, but the function is quite customizable. 
            alpha -= EaseIn(current_time, start_value, value_change_multiplier, duration);
        }
        alpha = alpha < 0 ? 0 : alpha; //Clamp the alpha at 0.
        fader.SetFloat("_Alpha", alpha); //Apply the new alpha to the fade material. 

        Graphics.Blit(source, destination, fader); //Render the image effect from the camera's output.
        if (alpha == 0) start = false; //Disable the component when the fade is over. 
    }

    /// <summary>
    /// An ease-in function for reducing the alpha value each frame.
    /// </summary>
    /// <param name="t">Current time.</param>
    /// <param name="b">Start value.</param>
    /// <param name="c">Value change multiplier.</param>
    /// <param name="d">Duration.</param>
    /// <returns>New alpha value.</returns>
    static float EaseIn(float t, float b, float c, float d)
    {
        return -c * (Mathf.Sqrt(1 - (t /= d) * t) - 1) + b;
    }
}
