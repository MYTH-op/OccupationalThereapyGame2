using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] string levelNum = "Level1";
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelChoosing"); 
    }

    public void Restart()
    {
        SceneManager.LoadScene(levelNum);
    }
}
