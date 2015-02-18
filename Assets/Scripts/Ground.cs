using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour {
    #region Méthodes privées
    void OnCollisionEnter (Collision other) {
        if ("Player" == other.gameObject.tag) {
            other.gameObject.GetComponent<Player> ().IsGrounded = true;
        }
    }
    #endregion
}
