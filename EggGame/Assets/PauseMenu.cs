using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("LevelChoosing");
    }

    public void Restart_1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void Restart_2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Restart_3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Restart_4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void Restart_5()
    {
        SceneManager.LoadScene("Level5");
    }
    public void Restart_6()
    {
        SceneManager.LoadScene("Level6");
    }

}
