using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {
    #region Attributs publics
    public float speed = 600f;
    public float maxStrength = 1000f;
    public float minStrength = 200f;
    public float chargeSpeed = 1000f;
    #endregion

    #region Attributs privés
    private float activeStrength = 0;
    #endregion

    #region Accesseurs

    #endregion

    #region Méthodes publiques
    public void ChargeStrength () {
        activeStrength = Mathf.Clamp (activeStrength + chargeSpeed, 0, maxStrength);
        GetComponent<MeshRenderer> ().material.color = Color.Lerp (Color.white, Color.red, activeStrength / maxStrength);
    }

    // Lance le rigidbody en paramètre
    public void Throw (Rigidbody _rigidbody) {
        activeStrength = Mathf.Clamp (activeStrength, minStrength, maxStrength);
        _rigidbody.AddForce (transform.up * activeStrength * Time.deltaTime);
        activeStrength = 0;
        GetComponent<MeshRenderer> ().material.color = Color.white;
    }

    #region Méthodes privées
    void FixedUpdate () {
        if (GameManager.ActionEnum.BARREL_MOVE == GameManager.instance.Action && this == GameManager.instance.barrelInMovement) {
            float h = Input.GetAxis ("Mouse X");
            Vector3 move = new Vector3 (0f, 0f, -h);
            rigidbody.transform.Rotate (move * speed * Time.fixedDeltaTime);
        }
    }
    #endregion

    void OnTriggerEnter (Collider other) {
        if ("Player" == other.gameObject.tag) {
            GameManager.instance.Action = GameManager.ActionEnum.BARREL_MOVE;
            GameManager.instance.barrelInMovement = this;
            //Player player = other.gameObject.GetComponent<Player> ();

            other.gameObject.transform.position = transform.position;   // Clamp
            other.gameObject.rigidbody.isKinematic = true;
        }
    }
    #endregion
}
