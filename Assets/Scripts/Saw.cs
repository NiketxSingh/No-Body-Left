using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    private Animator saw_anim;

    private void Start() {
        saw_anim = GetComponent<Animator>();
        saw_anim.Play("Saw_Clip");
    }
}
