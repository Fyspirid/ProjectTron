using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public SceneManager currentLevel;
    public Canvas canvasSetting;
    public AudioSource audioSourceSound;
    public void ToggleSound()
    {
        audioSourceSound.mute = !audioSourceSound.mute; // включаем/выключаем звук
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void CanvasSett()
    {
        canvasSetting.enabled = true;
        Time.timeScale = 0;
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}
