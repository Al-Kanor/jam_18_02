using UnityEngine;
using System.Collections;

public class MobileControlableBarrel : ControlableBarrel {
    #region Attributs publics
    public float moveSpeed = 10f;
    public float stopDuration = 0.5f;
    public Transform startPosition;
    public Transform endPosition;
    #endregion

    #region Attributs privés
    private float startTime;
    private float journeyLength;
    private bool isStopped = true;
    private float stopTimer;
    #endregion

    #region Méthodes privées
    void FixedUpdate () {
        base.FixedUpdate ();
        if (!isStopped) {
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fracJourney = distCovered / journeyLength;
            transform.position = Vector3.Lerp (startPosition.position, endPosition.position, Mathf.SmoothStep (0, 1, fracJourney));

            if (Vector3.Distance (transform.position, endPosition.position) < 0.01f) {
                transform.position = endPosition.position;   // Clamp
                Transform tmpPosition = endPosition;
                endPosition = startPosition;
                startPosition = tmpPosition;
                isStopped = true;
                stopTimer = stopDuration;
            }
        }
        else {
            stopTimer -= Time.fixedDeltaTime;

            if (stopTimer <= 0) {
                isStopped = false;
                startTime = Time.time;
            }
        }
    }

    void Start () {
        base.Start ();
        journeyLength = Vector3.Distance (startPosition.position, endPosition.position);
        stopTimer = stopDuration;
    }
    #endregion
}
