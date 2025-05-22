using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour {
    [SerializeField] private GameObject tut1;
    [SerializeField] private GameObject tut2;
    [SerializeField] private GameObject player;

    private bool tut1Done = false;
    private bool tut2Done = false;

    public GameObject InGameUI;

    private void Start() {
        tut1.SetActive(false);
        tut2.SetActive(false);
    }

    private void Update() {
        if (InRoom1() && !tut1Done) {
            tut1.SetActive(true);
            InGameUI.SetActive(false);
            Time.timeScale = 0f;
        }
        if (InRoom2() && !tut2Done) {
            tut2.SetActive(true);
            InGameUI.SetActive(false);
            Time.timeScale = 0f;
        }
    }

    public void Closetut1() {
        tut1.SetActive(false);
        tut1Done = true;
        InGameUI.SetActive(true);
        Time.timeScale = 1f;
    }
    public void Closetut2() {
        tut2.SetActive(false);
        tut2Done = true;
        InGameUI.SetActive(true);
        Time.timeScale = 1f;
    }

    private bool InRoom1() {
        Vector3 pos = player.transform.position;

        if (pos.x < 9 && pos.y > -3) {
            return true;
        }
        return false;
    }
    private bool InRoom2() {
        Vector3 pos = player.transform.position;

        if (pos.x >= 9 && pos.x < 28 && pos.y > -10) {
            return true;
        }
        return false;
    }
}
