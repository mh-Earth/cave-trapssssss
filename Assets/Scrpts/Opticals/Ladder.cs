using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private bool isLadder = false;
    private bool isClimbing = false;
    private float Vertical;
    [SerializeField]
    private float speed = 5f;
    // [SerializeField]
    private Rigidbody2D playerBody;
    // private GameObject player;

    private void Start() {
        
        playerBody = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG).GetComponent<Rigidbody2D>();

    }

    private void Update() {
        
        Vertical = Input.GetAxis("Vertical");
        if(isLadder & Mathf.Abs(Vertical) > 0){
            isClimbing = true;


        }

    }


    private void FixedUpdate() {
        if(isClimbing)
        {
            playerBody.gravityScale = 0;
            playerBody.velocity = new Vector2(playerBody.velocity.x,Vertical * speed);
        }

        else{

            playerBody.gravityScale = 2;

        }

    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag(TagManager.PLAYER_TAG))
        {   

            isLadder = true;
        }


    }


    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag(TagManager.PLAYER_TAG))
        {

            isLadder = false;
            isClimbing = false;

        }
    }



}
