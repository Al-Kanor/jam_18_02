using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    #region Attributs publics
    public float speed = 500f;
    public float jumpForce = 5f;
    public Sprite[] sprites;
    #endregion

    #region Attributs privés
    private bool isGrounded = true;
    #endregion

    #region Accesseurs
    public bool IsGrounded {
        get { return isGrounded; }
        set { isGrounded = value; }
    }
    #endregion

    #region Méthodes publiques
    public void UpdateSprite () {
        transform.GetChild (1).GetComponent<SpriteRenderer> ().sprite = sprites[LevelManager.instance.level - 1];
    }
    #endregion

    #region Méthodes privées
    void FixedUpdate () {
        if (LevelManager.ActionEnum.PLAYER_MOVE == LevelManager.instance.Action) {
            float h = Input.GetAxis ("Horizontal");
            float v = Input.GetAxis ("Vertical");
            Vector3 move = new Vector3 (h, 0f, v);

            if (Input.GetButtonDown ("Jump") && isGrounded) {
                move.y = jumpForce;
            }

            rigidbody.AddForce (move * speed * Time.deltaTime);
        }
    }
    #endregion
}