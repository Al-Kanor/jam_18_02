using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    #region Attributs publics
    #endregion

    #region Attributs privés
    #endregion

    #region Accesseurs
    
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
    public void GoToGame () {
        Application.LoadLevel ("Main");
    }

    public void GoToPauseMenu () {

    }
    #endregion

    #region Méthodes privées
    
    #endregion
}
