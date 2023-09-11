using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    public GameObject bar;
    [SerializeField] float time;

    private float fillStartTime;
    private Vector3 initialScale;

    void Start()
    {
        // Store the initial scale of the inner bar.
        initialScale = bar.transform.localScale;

        // Set the inner bar's X scale to zero at the start.
        bar.transform.localScale = new Vector3(0, bar.transform.localScale.y, bar.transform.localScale.z);

        // Start the animation.
        fillStartTime = Time.time;
    }

    void Update()
    {
        // Calculate the progress of the animation.
        float progress = (Time.time - fillStartTime) / time;

        // Clamp the progress to [0, 1] to prevent overfilling.
        progress = Mathf.Clamp01(progress);

        // Update the scale of the inner bar based on the progress.
        bar.transform.localScale = new Vector3(progress, bar.transform.localScale.y, bar.transform.localScale.z);
    }
}
