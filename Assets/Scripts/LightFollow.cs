using UnityEngine;

public class LightFollow : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 followOffset = new Vector3(0, 0, -1);
    [SerializeField] private Vector3 startOffset = new Vector3(0, 0, 0);
    [SerializeField] private float smooth = 0.5f;

    private void Start() {
        if (player != null) {
            transform.position = Vector3.Lerp(player.position+startOffset,player.position+followOffset,Time.deltaTime*smooth*0.01f);
        }
    }
    private void LateUpdate() {
        if (player != null) {
            Vector3 newPosition = player.position + followOffset;
            transform.position = Vector3.Lerp(player.position, newPosition, Time.deltaTime * smooth);
        }
    }
}
