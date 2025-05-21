using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject doorClosed;
    [SerializeField] private GameObject doorOpen;
    private bool body = false;

    private void Start() {
        DeactivateMechanism();
        body = false;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("dead")) {
            ActivateMechanism();
            body = true;
        }
        else if(other.CompareTag("player") && !body) {
            ActivateMechanism();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("dead")) {
            DeactivateMechanism();
            body = false;
        }
        else if (other.CompareTag("player") && !body) {
            DeactivateMechanism();
        }
    }

    private void ActivateMechanism() {
        doorOpen.SetActive(true);
        doorClosed.SetActive(false);
    }
    private void DeactivateMechanism() {
        doorClosed.SetActive(true);
        doorOpen.SetActive(false);
    }
}
