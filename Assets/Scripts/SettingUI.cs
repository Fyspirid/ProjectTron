using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingUI : MonoBehaviour
{
    public void OnClickSceneMainMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 0.0f;
    }
    public void OnClickClose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1.0f;
    }
    public void OnClickNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1.0f;
    }
    public void PauseMenu()
    {
        Time.timeScale = 0.0f;
    }
    public void PlayGame()
    {
        Time.timeScale = 1.0f;
    }
}
