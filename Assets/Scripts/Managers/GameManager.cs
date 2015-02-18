using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    #region Enum publics
    public enum ActionEnum {
        BARREL_MOVE,
        PLAYER_MOVE
    };
    #endregion

    #region Attributs publics
    public Player player;
    public Barrel barrelInMovement = null;
    #endregion

    #region Attributs privés
    private ActionEnum action = ActionEnum.PLAYER_MOVE;
    #endregion

    #region Accesseurs
    public ActionEnum Action {
        get { return action; }
        set {
            switch (value) {
                case ActionEnum.BARREL_MOVE:

                    break;
                case ActionEnum.PLAYER_MOVE:

                    break;
            }

            action = value;
        }
    }
    #endregion

    #region Singleton
    static GameManager m_instance;
    static public GameManager instance { get { return m_instance; } }

    void Awake () {
        if (null == instance) {
            m_instance = this;
        }

        DontDestroyOnLoad (this);
    }
    #endregion

    #region Méthodes publiques
    public void GoToMainMenu () {

    }

    public void GoToPauseMenu () {

    }
    #endregion

    #region Méthodes privées
    void FixedUpdate () {
        switch (action) {
            case ActionEnum.BARREL_MOVE:
                if (Input.GetButton ("Fire1")) {
                    barrelInMovement.ChargeStrength ();
                }
                break;
        }
    }

    void Start () {
        
    }

    void Update () {
        switch (action) {
            case ActionEnum.BARREL_MOVE:
                if (Input.GetButtonUp ("Fire1")) {
                    // To the moon !
                    player.rigidbody.isKinematic = false;
                    barrelInMovement.Throw (player.rigidbody);
                    Action = ActionEnum.PLAYER_MOVE;
                }
                break;
        }
    }
    #endregion
}
