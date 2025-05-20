using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
    [SerializeField] private int lives = 10;
    [SerializeField] private GameObject deadPrefab;
    [SerializeField] private float deadTime = 50f;
    private Transform spawnLocation;

    private List<GameObject> blastedObjects = new List<GameObject>();
    private float blastRadius = 2f;
    [SerializeField] private LayerMask destructible;

    public static event Action<Vector2, float> OnBlast;

    [SerializeField] private GameObject cameraManager_GO;
    Cameramanager cameraManager_;

    [SerializeField] private GameObject MenuManager_GO;
    private MenuManager menuManager;

    private void Start() {
        cameraManager_ = cameraManager_GO.GetComponent<Cameramanager>();
        menuManager = MenuManager_GO.GetComponent<MenuManager>();
    }

    private void Update() {

        spawnLocation = cameraManager_.GetSpawnLocation();

        if (Input.GetKeyDown(KeyCode.K) && lives > 0) {
            SelfDeath();
        }
        if (Input.GetKeyDown(KeyCode.L) && lives > 0) {
            BlastDeath();
        }
        //get hit to die normally
        if (lives <= 0) {
            gameObject.SetActive(false);
            menuManager.LoseGame();
        }
    }

    private void SelfDeath() {
        lives--;
        StartCoroutine(StayingDead());
        transform.position = spawnLocation.position;
    }

    private void BlastDeath() {
        lives--;
        TriggerBlast(transform.position, blastRadius);
        transform.position = spawnLocation.position;
    }
    private void NormalDeath() {
        lives--;
        transform.position = spawnLocation.position;
    }

    public static void TriggerBlast(Vector2 position, float radius) {
        OnBlast?.Invoke(position, radius);
    }

    IEnumerator StayingDead() {
        GameObject dead = Instantiate(deadPrefab, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(deadTime);
        Destroy(dead);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("obstacle") || other.CompareTag("enemy")) {
            NormalDeath();
        }
    }

    public int GetLives() {
        return lives;
    }
    public void UpdateLives(int count) {
        int newLives = lives + count;
        if (newLives > 0 && newLives < 10) {
            lives = newLives;
        }
    } 
}


