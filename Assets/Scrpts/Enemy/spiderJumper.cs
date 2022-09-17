using UnityEngine;

public class spiderJumper : MonoBehaviour
{
    [SerializeField]
    private bool isAutoJump = false;
    [SerializeField]
    private float jumpForce = 5;

    [SerializeField]
    private int minJumpTime = 1, maxJumpTime = 10;

    [SerializeField]
    private LayerMask playerLayer;

    private float jumpTime;
    [SerializeField]
    private Rigidbody2D spiderBody;
    [SerializeField]
    private Animator anime;
    private RaycastHit2D RaycastHit2D;

    private float playerDetectionHight = 90f;

    private void Awake()
    {
        jumpTime = Time.time + Random.Range(minJumpTime, maxJumpTime);

        spiderBody = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
    }

    void isPlayerThere()
    {
        if (!isAutoJump)
        {


            RaycastHit2D = Physics2D.Raycast(transform.position, Vector2.up, playerDetectionHight, playerLayer);
            Debug.DrawRay(transform.position, Vector3.up, Color.red, playerDetectionHight);

            if (RaycastHit2D)
            {
                jump();
            }

        }

    }
    void jump()
    {

        spiderBody.velocity = new Vector2(spiderBody.velocity.x, jumpForce);
        jumpTime = Time.time + Random.Range(minJumpTime, maxJumpTime);

    }


    void autoJump()
    {

        if (Time.time > jumpTime)
        {

            spiderBody.velocity = new Vector2(spiderBody.velocity.x, jumpForce);
            jumpTime = Time.time + Random.Range(minJumpTime, maxJumpTime);

        }

    }

    private void Update()
    {
        if (isAutoJump)
        {

            autoJump();
        }


        handelAnimations();
        isPlayerThere();
    }

    void handelAnimations()
    {

        anime.SetInteger(TagManager.JUMP_ANIMATIONS, (int)spiderBody.velocity.magnitude);

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

        }
    }
    //////////////////////////////////////////////////////////




}
