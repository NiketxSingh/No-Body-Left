using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject mechanism;

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
        mechanism.SetActive(true);
    }
    private void DeactivateMechanism() {
        mechanism.SetActive(false);
    }
}
