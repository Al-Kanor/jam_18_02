using UnityEngine;
using System.Collections;

public class IdleBarrel : Barrel {
    #region Méthodes privées
    void FixedUpdate () {
        base.FixedUpdate ();
        if (LevelManager.ActionEnum.BARREL_MOVE == LevelManager.instance.Action && this == LevelManager.instance.barrelInMovement) {
            float h = Input.GetAxis ("Mouse X");
            Vector3 move = new Vector3 (0f, 0f, -h);
            rigidbody.transform.Rotate (move * turnSpeed * Time.fixedDeltaTime);
        }
    }
    #endregion
}
