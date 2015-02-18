using UnityEngine;
using System.Collections;

public class DeadZone : MonoBehaviour {
    void OnTriggerEnter (Collider other) {
        if ("Player" == other.gameObject.tag) {
            if (null != LevelManager.instance.barrelInMovement) {
                other.transform.position = LevelManager.instance.barrelInMovement.transform.position;
            }
        }
    }
}
