using System.Collections;
using UnityEngine;

public class Void : MonoBehaviour
{

    private Transform reSpanwPoint;
    private GameObject player;

    public AnimationCurve curve;
    public float duration = .1f;
    private Camera MainCamera;


    public delegate void playerFalls();
    public static event playerFalls playerFallsToTheVoid;



    // function for camera shaking
    public IEnumerator shaking(float duration, AnimationCurve shakingCurve) { 
        Vector3 startPosition = MainCamera.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            MainCamera.transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        MainCamera.transform.position = startPosition;
    }


    private void Start() {
        
        reSpanwPoint = GameObject.FindGameObjectWithTag(TagManager.SPAWN_POINT).GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);
        MainCamera = Camera.main;

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag(TagManager.PLAYER_TAG)){
            
            if (playerFallsToTheVoid != null){
                StartCoroutine(shaking(duration,curve));

                // calling delegates when player falls in Void!!
                playerFallsToTheVoid();
            }

        }

    }


}
