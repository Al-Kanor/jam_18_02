using UnityEngine;
using System.Collections;

public class AutomaticBarrel : Barrel {
    #region Attributs publics
    public bool clockwiseDirection = true;
    #endregion

    #region Méthodes privées
    void FixedUpdate () {
        Vector3 move = Vector3.forward;
        move *= clockwiseDirection ? -1 : 1;
        rigidbody.transform.Rotate (move * turnSpeed * Time.fixedDeltaTime);
    }
    #endregion
}
