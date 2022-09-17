using UnityEngine;

public class spiderDestory : MonoBehaviour
{


    void selfDestroy(){
        if(gameObject.activeInHierarchy){
            Destroy(gameObject);

        }

    }


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(TagManager.PLAYER_TAG)){

            selfDestroy();

        }

        if(other.gameObject.CompareTag("Foreground"))
        {

            selfDestroy();

        }
    }
    
}
