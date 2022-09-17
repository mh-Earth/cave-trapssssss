using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntiGravityPlafrom : MonoBehaviour
{

    private Vector3 initialPosition;
    private float waitTime;
    [SerializeField]
    private float cameBackTime=5f;
    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private bool canJump = true;

    private bool goBack = false;
    private BoxCollider2D boxCollider2D;
    private Rigidbody2D rb;
    private bool IsOnPlatform = false;
    private int layer;
    private void Start()
    {

        initialPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
        selectLayer();
    }
    void selectLayer(){

        if(canJump){
            layer = LayerMask.NameToLayer("ground");
            gameObject.layer = layer;

        }
        else{
            layer = LayerMask.NameToLayer("void");
            gameObject.layer = layer;
            

        }

    }

    void platformFalls(){
            if(IsOnPlatform & playerController.isGrounded){
                waitTime = Time.time + cameBackTime;
                rb.velocity = new Vector3(0f,-8f,0f);
                // playerController.isGrounded = false;
            }
    }



    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag(TagManager.PLAYER_TAG) & playerController.isGrounded)
        {
            IsOnPlatform = true;
        }

    }




    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {   
            IsOnPlatform = false;
            goBack = true;            
            boxCollider2D.isTrigger = true;


        }


    }

    private void Update() {
        platformFalls();
    }

    private void FixedUpdate()
    {


        if (Time.time > waitTime & goBack)
        {
            transform.position = Vector3.MoveTowards(transform.position,initialPosition,moveSpeed);
            rb.velocity = new Vector3(0f,0f,0f);


        }

        if(Vector3.Distance(transform.position,initialPosition) == 0f){

            goBack = false;
            boxCollider2D.isTrigger = false; 


        }

    }





}
