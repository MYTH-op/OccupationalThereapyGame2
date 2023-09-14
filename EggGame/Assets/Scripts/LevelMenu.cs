using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{

    public void Lvl1()
    {
        SceneManager.LoadScene("Level1");
        Debug.Log("sceneswitch");
    }

    public void Lvl2()
    {
        SceneManager.LoadScene("Level2");
        Debug.Log("sceneswitch");
    }

    public void Lvl3()
    {
        SceneManager.LoadScene("Level3");
        Debug.Log("sceneswitch");
    }

    public void Lvl4()
    {
        SceneManager.LoadScene("Level4");
        Debug.Log("sceneswitch");
    }

    public void Lvl5()
    {
        SceneManager.LoadScene("Level5");
        Debug.Log("sceneswitch");
    }

    public void Lvl6()
    {
        SceneManager.LoadScene("Level6");
        Debug.Log("sceneswitch");
    }
}
