using UnityEngine;

public class playerController : MonoBehaviour
{

    private player_animations playerAnime;
    [SerializeField]
    private float playerJump;
    [SerializeField]
    private float playerSpeed = 280f;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float waitFrameTime = 20;




    private Rigidbody2D body;
    private SpriteRenderer sp;
    private RaycastHit2D raycastHit2D;

    [HideInInspector]
    public static bool isGrounded = true;

    private float frameCount;
    private bool isJumped = false;
    private float Axis;
    private float gravity = 2f;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        playerAnime = GetComponent<player_animations>();
        sp = GetComponent<SpriteRenderer>();
        // Vector2.SmoothDamp()
        
    }

    

    private void Update()
    {

        ifPlayerNoTheGround();
        handle_playerAnimations();


    }
    private void FixedUpdate()
    {
        playerMovement();
        player_jump();
        

    }

    // Handling the player facing directions
    void handelDic(bool dir)
    {   
        sp.flipX = dir;
    }



    // Move player using rigidbody velocity;
    void playerMovement()
    {
        Axis = Input.GetAxis("Horizontal");
        if (Axis > 0)
        {
            // SmoothPlayerMovement();
            body.velocity = new Vector2(Axis * playerSpeed *Time.deltaTime, body.velocity.y);
            handelDic(false);


        }
        else if (Axis < 0)
        {
            // SmoothPlayerMovement();
            body.velocity = new Vector2(playerSpeed*Axis*Time.deltaTime, body.velocity.y);
            handelDic(true);

        }

        else
        {
            body.velocity = new Vector2(0, body.velocity.y);
            // playerSpeed = playerInitialSpeed;
        }
    }


    void handle_playerAnimations()
    {

        playerAnime.play_walkAnimation((int)Mathf.Abs(body.velocity.x));
        playerAnime.play_jumpAnimation(isJumped);

    }


    void ifPlayerNoTheGround()
    {

        raycastHit2D = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, layerMask);
        if (raycastHit2D)
        {
            isGrounded = true;
            isJumped = false;

        }
        else
        {   
            // allow player jump ("waitFrameTime" frame) although he left the ground.
            isJumped = true; 
            body.gravityScale = gravity;
            if (frameCount > waitFrameTime)
            {
                isGrounded = false;
                frameCount = 0;

            }

            frameCount++;
        }



    }


    // Make the player jump using this velocity;
    void player_jump()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            if (isGrounded)

            {   
                body.gravityScale = 0;
                // body.AddForce(Vector2.up * playerJump * Time.deltaTime,ForceMode2D.Impulse);
                body.velocity = new Vector2(body.velocity.x,playerJump*Time.deltaTime);
                isGrounded = false;

            }
        }

    }




}

