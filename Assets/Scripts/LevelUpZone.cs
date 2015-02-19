using UnityEngine;
using System.Collections;

public class LevelUpZone : MonoBehaviour {
    void OnTriggerEnter (Collider other) {
        if ("Player" == other.gameObject.tag) {
            LevelManager.instance.level++;

            //LevelManager.instance.player.transform.GetChild (1).GetComponent<SpriteRenderer> ().sprite = (Sprite)Resources.Load ("Asset_player/player_lvl_" + LevelManager.instance.level);
            LevelManager.instance.player.UpdateSprite ();
            SoundManager.instance.StopSound ("World " + (LevelManager.instance.level - 1));
            SoundManager.instance.PlaySound ("World " + LevelManager.instance.level);
            GameObject.Destroy (gameObject);
        }
    }
}
