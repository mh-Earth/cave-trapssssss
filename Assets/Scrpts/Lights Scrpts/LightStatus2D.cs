using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class LightStatus2D : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private Light2D pointLight;

    private Camera mainCamera;
    private float distance;
    private GameObject[] player;
    private Transform playerPos;

    private void Start() {
        pointLight = GetComponent<Light2D>();
        mainCamera = Camera.main;
        player = GameObject.FindGameObjectsWithTag(TagManager.PLAYER_TAG);
        playerPos = player[0].GetComponent<Transform>();
    }

    // Enable the light if the light object is not in the game view
    void getPlayerToMainLightDistance(){
        distance = Vector3.Distance(playerPos.transform.position,transform.position);

        if(distance > 40){

        // if(distance > (mainCamera.WorldToScreenPoint(mainCamera.transform.localScale))){

            pointLight.enabled = false;

        }

        else{

            pointLight.enabled = true;


        }

    }


    private void FixedUpdate() {
        getPlayerToMainLightDistance();
    }


}
