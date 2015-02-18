using UnityEngine;
using System.Collections;

public class EvolutionZone : MonoBehaviour {
    #region Attributs publics
    public float newPlayerSpeed = 1000f;
    public float newPlayerJumpForce = 10f;
    public float newCameraSize = 7;
    public float dezoomSpeed = 10;
    #endregion

    #region Attributs privés
    private float startZoom;
    private float endZoom;
    private bool isInDezoom = false;
    private float startTime;
    private float journeyLength;
    private Player player;
    #endregion

    #region Méthodes privées
    void FixedUpdate () {
        if (isInDezoom) {
            float distCovered = (Time.time - startTime) * dezoomSpeed;
            float fracJourney = distCovered / journeyLength;
            Camera.main.GetComponent<Camera> ().orthographicSize = Mathf.Lerp(startZoom, endZoom, Mathf.SmoothStep (0, 1, fracJourney));

            if (Mathf.Abs (Camera.main.GetComponent<Camera> ().orthographicSize - endZoom) <= 0.01f) {
                Camera.main.GetComponent<Camera> ().orthographicSize = newCameraSize;   // Clamp
                startZoom = endZoom;
            }
        }
    }

    void OnTriggerEnter (Collider other) {
        if ("Player" == other.gameObject.tag) {
            player.speed = newPlayerSpeed;
            player.jumpForce = newPlayerJumpForce;
            startTime = Time.time;
            isInDezoom = true;
        }
    }

    void Start () {
        startZoom = Camera.main.GetComponent<Camera> ().orthographicSize;
        endZoom = newCameraSize;
        journeyLength = Mathf.Abs(startZoom - endZoom);
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
    }
    #endregion
}
