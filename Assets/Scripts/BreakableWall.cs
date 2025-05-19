using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    private void OnEnable() {
        PlayerDeath.OnBlast += ReceivedBlast;
    }

    private void OnDisable() {
        PlayerDeath.OnBlast -= ReceivedBlast;
    }

    private void ReceivedBlast(Vector2 blastPosition, float blastRadius) { 
        float dist = Vector2.Distance(transform.position, blastPosition);
        Debug.Log(dist);
        if (dist < blastRadius) {
            Destroy(gameObject);
        }
    }
}
