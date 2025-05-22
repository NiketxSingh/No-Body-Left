using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerDeath : MonoBehaviour {
    [SerializeField] private int lives = 10;
    [SerializeField] private GameObject deadPrefab;
    [SerializeField] private GameObject ghostPrefab;
    [SerializeField] private GameObject blastPrefab;
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

    GameObject audioManager_GO;
    AudioManager audioManager;

    private void Awake() {
        audioManager_GO = GameObject.FindGameObjectWithTag("audiomanager");
        audioManager = audioManager_GO.GetComponent<AudioManager>();
    }

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
        SpawnGhost(transform.position);
        StartCoroutine(StayingDead());
        transform.position = spawnLocation.position;
    }

    private void BlastDeath() {
        audioManager.PlaySFX(audioManager.blast_death);
        lives--;
        TriggerBlast(transform.position, blastRadius);
        BlastPlayer(transform.position);
        SpawnGhost(transform.position);
        transform.position = spawnLocation.position;
    }
    private void NormalDeath() {
        lives--;
        SpawnGhost(transform.position);
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
            audioManager.PlaySFX(audioManager.blade_death); 
            NormalDeath();
        }
    }

    public int GetLives() {
        return lives;
    }
    public void UpdateLives(int count) {
        int newLives = lives + count;
        if (newLives > 0 && newLives <= 10) {
            lives = newLives;
        }
    }

    private void SpawnGhost(Vector3 deathPos) {
        audioManager.PlaySFX(audioManager.ghost);
        GameObject ghost = Instantiate(ghostPrefab, deathPos, Quaternion.identity);
        StartCoroutine(GhostFloatAndDestroy(ghost));
    }
    private IEnumerator GhostFloatAndDestroy(GameObject ghost) {
        float duration = 2f;
        float elapsed = 0f;
        Vector3 startPos = ghost.transform.position;
        SpriteRenderer sr = ghost.GetComponentInChildren<SpriteRenderer>();

        while (elapsed < duration) {

            float yOffset = Mathf.Lerp(0f, 2f, elapsed / duration);
            float xOffset = Mathf.Sin(elapsed * 5f) * 0.1f;

            ghost.transform.position = startPos + new Vector3(xOffset, yOffset, 0f);

            float alpha = Mathf.Lerp(1f, 0f, elapsed / duration);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, alpha);
            elapsed += Time.deltaTime;
            yield return null;
        }
        Destroy(ghost);
    }

    private void BlastPlayer(Vector3 deathPos) {
        GameObject blast = Instantiate(blastPrefab, deathPos, Quaternion.identity);
        StartCoroutine(BlastAndFadeAway(blast));
    }
    private IEnumerator BlastAndFadeAway(GameObject blast) {
        float duration = 0.8f;
        float elapsed = 0f;
        SpriteRenderer sr = blast.GetComponentInChildren<SpriteRenderer>();

        Vector3 startScale = Vector3.zero;
        Vector3 endScale = Vector3.one * 3f;

        while (elapsed < duration) { 

            blast.transform.localScale =Vector3.Lerp(startScale,endScale,elapsed / duration);

            Color c = Color.Lerp(Color.red,Color.yellow, elapsed / duration);
            c.a = Mathf.Lerp(1f,0f,elapsed / duration);
            sr.color = c;
            
            elapsed += Time.deltaTime;
            yield return null;
        }
        Destroy(blast);
    }
}


