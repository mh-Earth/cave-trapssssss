using UnityEngine;
using System.Collections;


public class enemyCollaids : MonoBehaviour
{   

    [SerializeField]
    private bool ShakeCamera = false;
    [SerializeField]
    private float duration = .15f;
    private GameObject player;
    private GameObject Respawn_Point;
    
    public AnimationCurve ShakingCurve;


    public delegate void playerDead();
    public static event playerDead playerHasDead;


    private void Start() {
        Respawn_Point = GameObject.FindGameObjectWithTag(TagManager.SPAWN_POINT);
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);

    }



    // //  Camera shaking method
    // 
    public IEnumerator shaking(float duration, AnimationCurve shakingCurve) { 
        Vector3 startPosition = Camera.main.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float strength = shakingCurve.Evaluate(elapsedTime / duration);
            Camera.main.transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        Camera.main.transform.position = startPosition;
    }




    private void OnCollisionEnter2D(Collision2D other) {
        // Camera shaking effect;
        if (ShakeCamera){
            if(other.gameObject.CompareTag(TagManager.PLAYER_TAG)){
                StartCoroutine(shaking(duration,ShakingCurve));

            }

        }


        // action,when player collide with any enemy;
        if(other.gameObject.CompareTag(TagManager.PLAYER_TAG)){
            // calling delegates when player collide with any enemy!!
            if(playerHasDead != null){

                playerHasDead();

            }

        }


    }

}
