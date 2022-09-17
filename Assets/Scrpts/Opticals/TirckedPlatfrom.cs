using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TirckedPlatfrom : MonoBehaviour
{

    [SerializeField]
    private GameObject movePoint;
    private Vector3 initialPosition;
    private Vector3 currentVelocity = Vector3.zero;
    [SerializeField]
    private float moveSpeed;
    private Vector3 target;
    private float waitTime = 2f;    


    private void Start() {
        initialPosition = transform.position;
        target = movePoint.transform.position;
        waitTime = waitTime + Time.time;
    }
    
    private bool isMove = false;

    // Function for move the platform to a point
    void movePlatform(){
        if(Vector3.Distance(transform.position,target) < 0.1f){


            // Going to the movePoint if the player in range of circle collider
            if(target == initialPosition){

                target = movePoint.transform.position;
                isMove = false;

            }

            // Going to the back to the start position.wait time = 2f
            else{
                target = initialPosition;
                // wait time
                waitTime = Time.time + 2f;
                // move a frame to make the if condition false (distance > 0.1f)
                transform.position = Vector3.SmoothDamp(transform.position,target,ref currentVelocity,1f);

            }
        }

        else{
            // Main movement;
            if(Time.time > waitTime){
                transform.position = Vector3.MoveTowards(transform.position,target,moveSpeed);
            }



        }
            


    }



    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag(TagManager.PLAYER_TAG)){

        // isMove = true if player enter the collider
        isMove = true;
        // make the wait time 0 for instance movement in trigger
        waitTime= 0;
        }


    }

    private void Update() {
        if(isMove){
            movePlatform();        
        }

    }


}
