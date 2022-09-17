using UnityEngine;

public class dismond : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem diamondDistory;

    private void Start() {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(TagManager.PLAYER_TAG)){

            if(transform.localScale != Vector3.zero){
                GameManager.Score++;
                transform.localScale = Vector3.zero;
                diamondDistory.Play();
                Destroy(gameObject,1f);
                print(GameManager.Score);

            }

        }
    }


}
