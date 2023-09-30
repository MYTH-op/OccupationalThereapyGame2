using UnityEngine;
using UnityEngine.SceneManagement;

public class Tumbler_PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public Tumbler_Bar bar;

    private bool isRestarting = false;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        bar.Pause();
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        bar.Resume();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Tumbler_LevelChoosing");
        
    }

    public void Restart_1()
    {
        RestartScene("Level_Tumbler_1");
        Continue();
    }

    public void Restart_2()
    {
        RestartScene("Level_Tumbler_2");
        Continue();
    }

    public void Restart_3()
    {
        RestartScene("Level_Tumbler_3");
        Continue();
    }

    public void Restart_4()
    {
        RestartScene("Level_Tumbler_4");
        Continue();
    }

    public void Restart_5()
    {
        RestartScene("Level_Tumbler_5");
        Continue();
    }

    public void Restart_6()
    {
        RestartScene("Level_Tumbler_6");
        Continue();
    }

    private void RestartScene(string sceneName)
    {
        if (!isRestarting)
        {
            isRestarting = true;
            SceneManager.LoadScene(sceneName);
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // After scene reloads, reset the restarting flag
        isRestarting = false;
    }
}
