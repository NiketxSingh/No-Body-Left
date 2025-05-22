using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject closedDoorVisual;
    [SerializeField] private GameObject openDoorVisual;

    GameObject audioManager_GO;
    AudioManager audioManager;

    private void Awake() {
        audioManager_GO = GameObject.FindGameObjectWithTag("audiomanager");
        audioManager = audioManager_GO.GetComponent<AudioManager>();
    }


    private void Start() {
        CloseDoor();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("player")) {
            PlayerInventory inventory = other.GetComponent<PlayerInventory>();
            if (inventory != null && inventory.GetKeys()>0) {
                audioManager.PlaySFX(audioManager.door); 
                OpenDoor();
                inventory.UseKey();
            }
        } 
    }

    private void OpenDoor() {
        closedDoorVisual.SetActive(false);
        openDoorVisual.SetActive(true);
        GetComponent<Collider2D>().enabled = false;
    }
    private void CloseDoor() {
        closedDoorVisual.SetActive(true);
        openDoorVisual.SetActive(false);
        GetComponent<Collider2D>().enabled = true;
    }
}
