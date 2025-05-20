using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void StartGame() {
        SceneManager.LoadScene("GameScene");
        Time.timeScale = 1f;
    }
    public void GoToMainMenu() {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;
    }
    public void ShowInstructions() {
        SceneManager.LoadScene("Instructions");
        Time.timeScale = 1f;
    }
    public void QuitGame() {
        Application.Quit();
        Debug.Log("Game Quit");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stops play mode in editor
#endif
    }
    public void WinGame() {
        SceneManager.LoadScene("WinScene");
        Time.timeScale = 1f;
    }
    public void LoseGame() {
        SceneManager.LoadScene("LoseScene");
        Time.timeScale = 1f;
    }
}
