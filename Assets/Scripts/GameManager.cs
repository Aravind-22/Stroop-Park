using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject quitGame;
    public GameObject pauseGame;
    public GameObject homePage;
    public GameObject optionsPage;
    public GameObject nextLevel;
    public AudioSource audioSource;
    public LevelSelection levelSelection;
    public GameObject instructionsPage;

    public Text toggleMusicText;
    public Button ToggleSound;

    bool isGamePaused = false;
    bool isLevelComplete = false;
    bool isMuted;
    public int nextSceneLoad;
    public AudioClip audioClip;
    AudioSource gameOverAudio;
    private void Start()
    {
        Time.timeScale = 1;
        if (audioSource.isPlaying)
        {
            toggleMusicText.text = "OFF";
        }
        else
        {
            toggleMusicText.text = "ON";
        }
        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        gameOverAudio = GetComponent<AudioSource>();
        //isMuted = PlayerPrefs.GetInt("Muted")==1;
        //AudioListener.pause = isMuted;
    }
    private void Update()
    {
        if (isLevelComplete)
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("Reset level");
            isLevelComplete = false;
            levelSelection.ResetLevel();
        }
    }
    public void Gameover()
    {
        gameOverAudio.PlayOneShot(audioClip,0.5f);
        gameOver.SetActive(true);
        Time.timeScale = 0;
        audioSource.Stop();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(nextSceneLoad);
        if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
    }
    public void ResetLevel()
    {
        isLevelComplete = true;
       
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Start Game");
    }
    public void PauseMenu()
    {
        pauseGame.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
        if(isGamePaused)
            toggleMusicText.text = "ON";
        audioSource.Pause();
    }
    public void ResumeGame()
    {
         pauseGame.SetActive(false);
         Time.timeScale = 1;
         audioSource.UnPause();
    }
    public void StartGame()
    {
        homePage.SetActive(false);
        instructionsPage.SetActive(true);
    }
    public void NewGame()
    {
        SceneManager.LoadScene("Level 1");
    }
    public void OptionsMenu()
    {
        optionsPage.SetActive(true);
        homePage.SetActive(false);
    }
    public void BackButton()
    {
        optionsPage.SetActive(false);
        homePage.SetActive(true);
    }
    public void QuitGame()
    {
        quitGame.SetActive(true);
       //if(SceneManager.GetActiveScene().name == "Gameplay Scene")
        if (SceneManager.GetActiveScene().name == "Start Game")
            homePage.SetActive(false);
        else
            pauseGame.SetActive(false);
    }
    public void QuitConfirm()
    {
        Application.Quit();
    }
    public void CancelQuit()
    {
        quitGame.SetActive(false);
        if (SceneManager.GetActiveScene().name == "Start Game")
            homePage.SetActive(true);
        if(isGamePaused == true)
        {
            pauseGame.SetActive(true);
            //if (SceneManager.GetActiveScene().name == "Gameplay Scene")
            //{
            //    pauseGame.SetActive(true);
            //}
        }       
    }
    public void ToggleMusic()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
            toggleMusicText.text = "ON";
            PlayerPrefs.SetFloat("volume", 0.0F);
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
            //isMuted = !isMuted;
            //AudioListener.pause = isMuted;
            //PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
        }
        else
        {
            audioSource.Play();
            toggleMusicText.text = "OFF";
            PlayerPrefs.SetFloat("volume", 1F);
            AudioListener.volume = PlayerPrefs.GetFloat("volume");
        }
    }

}
