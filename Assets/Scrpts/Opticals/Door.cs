using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
[SerializeField]

private Animator anime;



private void OnTriggerEnter2D(Collider2D other) {
    if(other.CompareTag(TagManager.PLAYER_TAG))
    {
        anime.SetBool(TagManager.DOOR_ANIMATION ,true);
    }

}


private void OnTriggerExit2D(Collider2D other) {
    if(other.CompareTag(TagManager.PLAYER_TAG))
    {
        anime.SetBool(TagManager.DOOR_ANIMATION ,false);
    }
    
}


}
