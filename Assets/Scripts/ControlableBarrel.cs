using UnityEngine;
using System.Collections;

public class ControlableBarrel : Barrel {
    #region Méthodes privées
    void FixedUpdate () {
        if (GameManager.ActionEnum.BARREL_MOVE == GameManager.instance.Action && this == GameManager.instance.barrelInMovement) {
            float h = Input.GetAxis ("Mouse X");
            Vector3 move = new Vector3 (0f, 0f, -h);
            rigidbody.transform.Rotate (move * turnSpeed * Time.fixedDeltaTime);
        }
    }
    #endregion
}
