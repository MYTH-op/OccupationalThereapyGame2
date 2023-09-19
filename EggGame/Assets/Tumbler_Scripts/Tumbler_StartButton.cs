using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
public class Tumbler_StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private string levelChoosingScene = "LevelChoosing";

    public void nextscene()
    {
        SceneManager.LoadScene(levelChoosingScene);
    }
}