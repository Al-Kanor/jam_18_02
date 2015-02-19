using UnityEngine;
using System.Collections;

public class Barrel : MonoBehaviour {
    #region Attributs publics
    public float turnSpeed = 600f;
    public float maxStrength = 100000f;
    public float minStrength = 40000f;
    public float chargeSpeed = 2000f;
    #endregion

    #region Attributs privés
    private float activeStrength = 0;
    private Player player;
    #endregion

    #region Accesseurs

    #endregion

    #region Méthodes publiques
    public void ChargeStrength () {
        if (activeStrength == 0) {
            SoundManager.instance.PlaySound ("Charge");
        }

        activeStrength = Mathf.Clamp (activeStrength + chargeSpeed, 0, maxStrength);
        GetComponent<MeshRenderer> ().material.color = Color.Lerp (Color.white, Color.red, activeStrength / maxStrength);
    }

    // Lance le rigidbody en paramètre
    public void Throw (Rigidbody _rigidbody) {
        activeStrength = Mathf.Clamp (activeStrength, minStrength, maxStrength);
        _rigidbody.AddForce (transform.up * activeStrength * Time.deltaTime);
        activeStrength = 0;
        GetComponent<MeshRenderer> ().material.color = Color.white;
        SoundManager.instance.PlaySound ("Shoot");
    }

    #region Méthodes privées
    
    #endregion

    void OnTriggerEnter (Collider other) {
        if ("Player" == other.gameObject.tag) {
            LevelManager.instance.Action = LevelManager.ActionEnum.BARREL_MOVE;
            LevelManager.instance.barrelInMovement = this;
            other.gameObject.transform.position = transform.position;   // Clamp
            other.gameObject.rigidbody.isKinematic = true;
        }
    }
    #endregion

    #region Méthodes privées
    protected void FixedUpdate () {
        if (LevelManager.ActionEnum.BARREL_MOVE == LevelManager.instance.Action && this == LevelManager.instance.barrelInMovement) {
            player.transform.position = transform.position;
        }
    }

    protected void Start () {
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
    }
    #endregion
}