using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private int keyCount = 0;
    private int scrollCount = 0;

    private GameObject player;
    private PlayerDeath playerDeath;
    [SerializeField] private GameObject MenuManager_GO;
    private MenuManager menuManager;
    GameObject audioManager_GO;
    AudioManager audioManager;

    private void Awake() {
        audioManager_GO = GameObject.FindGameObjectWithTag("audiomanager");
        audioManager = audioManager_GO.GetComponent<AudioManager>();
    }

    private void Start() {
        player = GameObject.FindGameObjectWithTag("player");
        playerDeath = player.GetComponent<PlayerDeath>();
        menuManager = MenuManager_GO.GetComponent<MenuManager>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            UseScroll(playerDeath);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("key")) {
            audioManager.PlaySFX(audioManager.get_key); 
            keyCount++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("scroll")) {
            audioManager.PlaySFX(audioManager.get_scroll);
            scrollCount++;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("end")) {
            menuManager.WinGame();
        }
    }

    public void UseKey() {
        keyCount--;
    }

    private void UseScroll(PlayerDeath playerDeath) {
        if (scrollCount > 0) {
            audioManager.PlaySFX(audioManager.use_scroll); 
            scrollCount--;
            playerDeath.UpdateLives(2);
        }
    }

    public int GetKeys() {
        return keyCount;
    }
    public int GetScrolls() {
        return scrollCount;
    }
}
