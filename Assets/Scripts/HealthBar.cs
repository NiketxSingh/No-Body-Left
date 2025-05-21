using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject[] hearts;
    [SerializeField] GameObject player;
    private PlayerDeath playerDeath;

    void Start() {
        playerDeath = player.GetComponent<PlayerDeath>();
    }

    void Update() {
        int lives = playerDeath.GetLives();

        for (int i = 0; i < hearts.Length; i++) {
            hearts[i].SetActive(i < lives);
        }
    }
}
