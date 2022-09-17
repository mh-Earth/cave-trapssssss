using UnityEngine;

public class player_animations : MonoBehaviour
{

    [SerializeField]
    private Animator anime;

    private void Awake() {
        anime = GetComponent<Animator>();
    }


    public  void play_walkAnimation(int walk){

        anime.SetInteger(TagManager.WALK_ANIMATIONS,walk);

    }

    public  void play_jumpAnimation(bool jump){

        anime.SetBool(TagManager.JUMP_ANIMATIONS,jump);

    }

    public void play_respawnAnimation(bool respwan){

        anime.SetBool(TagManager.RESPAWN_ANIMATION,respwan);


    }

}
