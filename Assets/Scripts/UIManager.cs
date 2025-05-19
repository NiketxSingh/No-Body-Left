using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI livesText;

    private GameObject player;
    private PlayerDeath playerDeath;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("player");
        playerDeath = player.GetComponent<PlayerDeath>();
    }

    private void Update() {
        livesText.text = "Lives: " + playerDeath.GetLives(); 
    }
}
