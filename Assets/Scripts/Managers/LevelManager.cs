using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    #region Enum publics
    public enum ActionEnum {
        BARREL_MOVE,
        BEGIN_GAME,
        PLAYER_MOVE,
        SPLASH
    };
    #endregion

    #region Attributs publics
    public Barrel barrelInMovement = null;
    public int level = 1;
    public Player player;
    #endregion

    #region Attributs privés
    private ActionEnum action;
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
    static LevelManager m_instance;
    static public LevelManager instance { get { return m_instance; } }

    void Awake () {
        if (null == instance) {
            m_instance = this;
        }

        DontDestroyOnLoad (this);
    }
    #endregion

    #region Méthodes publiques
    
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
        player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player> ();
        Action = ActionEnum.PLAYER_MOVE;
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
