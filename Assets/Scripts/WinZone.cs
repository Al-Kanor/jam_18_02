using UnityEngine;
using System.Collections;

public class WinZone : MonoBehaviour {
    void OnTriggerEnter (Collider other) {
        if ("Player" == other.gameObject.tag) {
            SoundManager.instance.StopSound ("World 4");
            Application.LoadLevel ("MainMenu");
        }
    }
}
