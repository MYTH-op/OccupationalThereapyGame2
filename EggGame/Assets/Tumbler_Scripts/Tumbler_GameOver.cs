using UnityEngine;
using UnityEngine.SceneManagement;
public class Tumbler_GameOver : MonoBehaviour
{
    [SerializeField] string levelNum = "Level_Tumbler_1";
    public void LevelSelect()
    {
        SceneManager.LoadScene("Tumbler_LevelChoosing"); 
    }

    public void Restart()
    {
        SceneManager.LoadScene(levelNum);
    }
}
