using UnityEngine;

public class spiderWalker : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private LayerMask grounLayer;
    private RaycastHit2D raycastHit2D;

    private Transform Ground;
    [SerializeField]
    private float MoveDirection = -1;
    [SerializeField]
    private float moveSpeed = 40f;
    [SerializeField]
    private Rigidbody2D spiderBody;

    [SerializeField]
    private float movingDistance;

     
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spiderBody = GetComponent<Rigidbody2D>();
        Ground = transform.GetChild(0);
        
    }


    
    // If the GameObject will be active or not in out of camera view;
    [SerializeField]
    private bool RunInBackGround = false;
    private void OnBecameVisible() {
        enabled = true;
    }

    private void OnBecameInvisible() {
        if(!RunInBackGround){
            enabled = false;
            spiderBody.velocity = new Vector2(0,spiderBody.velocity.y);

        }
    }
    //////////////////////////////////////////////////////////

    void CheckForGround(){

        raycastHit2D = Physics2D.Raycast(Ground.position,Vector2.down,0.1f,grounLayer);

        if(!raycastHit2D){
            MoveDirection = MoveDirection * -1;
            transform.localScale = new Vector3(transform.localScale.x*-1,transform.localScale.y,transform.localScale.z);
            
        }


    }

    void walkWithGroundHit(){


        if (MoveDirection > 0){

            spiderBody.velocity = new Vector2(moveSpeed * Time.deltaTime,spiderBody.velocity.y);

        }

        else if(MoveDirection < 0){
            spiderBody.velocity = new Vector2(-moveSpeed * Time.deltaTime,spiderBody.velocity.y);

        }

    }


    private void Update() {
        CheckForGround();
        walkWithGroundHit();
    }


    void walkWithMovingDistance(){

        float tampX = transform.position.x + movingDistance;


    }



}
