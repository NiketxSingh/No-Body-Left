using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI keysText;
    [SerializeField] private TextMeshProUGUI scrollsText;

    private int lastKeys = -1;
    private int lastScrolls = -1;

    public GameObject pauseMenu;
    private bool isPaused = false;


    [SerializeField] private GameObject player;
    private PlayerDeath playerDeath;
    private PlayerInventory playerInventory;

    private void Awake() {
        pauseMenu.SetActive(false);
        playerDeath = player.GetComponent<PlayerDeath>();
        playerInventory = player.GetComponent<PlayerInventory>();
    }


    private void Update() {
        int currentKeys = playerInventory.GetKeys();
        int currentScrolls = playerInventory.GetScrolls();

        if (currentKeys != lastKeys) {
            keysText.text = currentKeys.ToString();
            lastKeys = currentKeys;
        }

        if (currentScrolls != lastScrolls) {
            scrollsText.text = currentScrolls.ToString();
            lastScrolls = currentScrolls;
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) ResumeGame();
            else PauseGame();
        }
    }

    public void ResumeGame() {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
    }

    public void PauseGame() {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

}
