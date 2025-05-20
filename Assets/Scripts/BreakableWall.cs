using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject noWall;

    private void OnEnable() {
        PlayerDeath.OnBlast += ReceivedBlast;
    }
    private void OnDisable() {
        PlayerDeath.OnBlast -= ReceivedBlast;
    }

    private void Start() {
        wall.SetActive(true);
        noWall.SetActive(false);
    }
    private void ReceivedBlast(Vector2 blastPosition, float blastRadius) { 
        float dist = Vector2.Distance(transform.position, blastPosition);
        Debug.Log(dist);
        if (dist < blastRadius) {
            BreakWall();
        }
    }
    void BreakWall() {
        wall.SetActive(false);
        noWall.SetActive(true);
    }
}
