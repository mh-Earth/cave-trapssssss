using UnityEngine;

public class windEffect : MonoBehaviour
{

    // Disable player jump if player in the effector
    private bool isInEffector = false;
        

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.CompareTag(TagManager.PLAYER_TAG)){
            isInEffector = true;

        }

    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag(TagManager.PLAYER_TAG)){
            isInEffector = false;

        }
        
    }

    private void FixedUpdate() {
        if(isInEffector){

            playerController.isGrounded = false;

        }
    }


}
