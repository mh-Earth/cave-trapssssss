using System.Collections;
using UnityEngine;

public class PlayerDead : MonoBehaviour
{


    private GameObject player,respanwPonit;
    // [SerializeField]
    private player_animations playerAnime;

    private void Start() {

        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);
        playerAnime = player.GetComponent<player_animations>();
        respanwPonit = GameObject.FindGameObjectWithTag(TagManager.SPAWN_POINT);



    }


    private void OnEnable() {
        // if player die from enemy collide
        enemyCollaids.playerHasDead += playerDeadEvents;
        // if player die from the void
        Void.playerFallsToTheVoid  += playerDeadEvents;

    }
    
    void playerDeadEvents(){
        //  Reset player position
        player.transform.position  = respanwPonit.transform.position;
        //  Decries player life
        GameManager.playerLifeCount -= 1;
        // play player respawn animation
        StartCoroutine(animations());
        // playerAnime.play_respawnAnimation(false);

    }

    // use Coroutine for wait until the animations are finished!!   
    IEnumerator animations(){
        playerAnime.play_respawnAnimation(true);
        yield return new WaitForSecondsRealtime(1);
        playerAnime.play_respawnAnimation(false);

    }




    private void OnDisable() {

        enemyCollaids.playerHasDead -= playerDeadEvents;
        Void.playerFallsToTheVoid  -= playerDeadEvents;
        
    }


}
