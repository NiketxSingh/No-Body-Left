using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool hasKey = false;
    private int scrollCount = 0;

    private GameObject player;
    private PlayerDeath playerDeath;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("player");
        playerDeath = player.GetComponent<PlayerDeath>();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.I)) {
            UseScroll(playerDeath);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("key")) {
            hasKey = true;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("scroll")) {
            scrollCount++;
            Destroy(other.gameObject);
        }
    }

    public bool HasKey() {
        return hasKey;
    }

    private void UseScroll(PlayerDeath playerDeath) {
        if (scrollCount > 0) {
            scrollCount--;
            playerDeath.UpdateLives(2);
        }
    }
}
