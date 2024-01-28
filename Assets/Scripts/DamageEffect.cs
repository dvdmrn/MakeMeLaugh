using Unity.VisualScripting;
using UnityEngine;

public class DamageEffect : MonoBehaviour
{
    public Transform level;
    public GameObject emitterPrefab;

    void Start() {
    }

    private void OnTriggerEnter(Collider other) {
        var go = Instantiate(emitterPrefab, new Vector3(transform.position.x, transform.position.y, -5), Quaternion.identity);
        
        go.transform.parent = level;
    }

    private void OnTriggerExit(Collider other) {

    }
}