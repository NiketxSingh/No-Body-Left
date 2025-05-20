using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject doorClosed;
    [SerializeField] private GameObject doorOpen;

    private void Start() {
        DeactivateMechanism();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("dead")) {
            ActivateMechanism();
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("dead")) {
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
