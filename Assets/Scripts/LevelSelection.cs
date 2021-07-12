using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    public Button[] levelButtons;
    // Start is called before the first frame update
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelAt)
                levelButtons[i].interactable = false;
        }
    }
    //Reset all levels
    public void ResetLevel()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 1);
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 1 > levelAt)
                levelButtons[i].interactable = false;
        }
    }
    //Load level from level selector
    public void LoadLevel(int levelIndex)
    { 
        SceneManager.LoadScene(levelIndex);
    }
}
