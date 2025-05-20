using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramanager : MonoBehaviour {

    [SerializeField] private GameObject player;

    private Vector3 room1 = new Vector3(0,0, -10f);
    private Vector3 room2 = new Vector3(18,-6, -10f);
    private Vector3 room3 = new Vector3(37,-6, -10f);
    private Vector3 room4 = new Vector3(37,-16, -10f);
    private Vector3 room5 = new Vector3(19,-16, -10f);

    private Camera cam;

    [SerializeField] Transform spawn1;
    [SerializeField] Transform spawn2;
    [SerializeField] Transform spawn3;
    [SerializeField] Transform spawn4;
    [SerializeField] Transform spawn5;
    private Transform spawnLocation;

    void Start() {
        cam = Camera.main;
        spawnLocation = spawn1;
    }

    void Update() {
        Vector3 pos = player.transform.position;

        if (pos.x < 9 && pos.y > -3) {
            cam.transform.position = Vector3.Lerp(cam.transform.position, room1, Time.deltaTime * 5f);
            spawnLocation = spawn1;
        }
        else if (pos.x >= 9 && pos.x < 28 && pos.y > -10) {
            cam.transform.position = Vector3.Lerp(cam.transform.position, room2, Time.deltaTime * 5f);
            spawnLocation = spawn2;
        }
        else if (pos.x >= 28 && pos.y > -10) {
            cam.transform.position = Vector3.Lerp(cam.transform.position, room3, Time.deltaTime * 5f);
            spawnLocation = spawn3;
        }
        else if (pos.x >= 28 && pos.y <= -10) {
            cam.transform.position = Vector3.Lerp(cam.transform.position, room4, Time.deltaTime * 5f);
            spawnLocation = spawn4;
        }
        else if (pos.x < 28 && pos.y <= -10) {
            cam.transform.position = Vector3.Lerp(cam.transform.position, room5, Time.deltaTime * 5f);
            spawnLocation = spawn5;
        }
    }

    public Transform GetSpawnLocation() {
        return spawnLocation;
    }
}
