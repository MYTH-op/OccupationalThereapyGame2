using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bar : MonoBehaviour
{
    public TumblerController tumbler;
    public GameObject LevelSuccess;
    public GameObject bar;
    [SerializeField] float time;
    private float fillStartTime;
    private Vector3 initialScale;
    private bool isPaused = false;

    void Start()
    {
        initialScale = bar.transform.localScale;
        bar.transform.localScale = new Vector3(0, bar.transform.localScale.y, bar.transform.localScale.z);
        fillStartTime = Time.time;
    }

    void Update()
    {
        if (!isPaused)
        {
            float progress = (Time.time - fillStartTime) / time;
            progress = Mathf.Clamp01(progress);
            bar.transform.localScale = new Vector3(progress, bar.transform.localScale.y, bar.transform.localScale.z);
            if (progress >= 1.0f)
            {
                tumbler.StopTumblerMovement();
                LevelSuccess.SetActive(true);
            }
        }
    }
    public void Pause()
    {
        isPaused = true;
    }
    public void Resume()
    {
        isPaused = false;
    }
}
