using UnityEngine;

public class spiderWalkerByDistance : MonoBehaviour
{
    [SerializeField]
    private Transform point1;
    [SerializeField]
    private Transform point2;

    // private Transform position1Tra,position2Tra;

    [SerializeField]
    private float moveSpeed = 5f;

    [SerializeField]
    private float initialPosition = 1f;

    private Transform target;
    [SerializeField]
    private SpriteRenderer spriteRenderer;


    void initialTarget()
    {

        if (initialPosition == 1f)
        {
            target = point1;
        }

        else if (initialPosition == 2f)
        {
            target = point2;

        }

        else
        {

            target = point1;
            spriteRenderer.flipX = true;
        }

    }


    private void Start()
    {
        initialTarget();
        OnBecameInvisible();
    }


    void setTarget()
    {

        if (Vector3.Distance(transform.position, target.position) < 0.1f)
        {
            if (target == point1)
            {
                target = point2;
                spriteRenderer.flipX = false;


            }

            else
            {
                target = point1;
                spriteRenderer.flipX = true;


            }

        }



    }


    void sawMovements()
    {

        transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

    }





    private void Update()
    {
        sawMovements();

    }

    private void FixedUpdate()
    {
        setTarget();
    }


    // If the GameObject will be active or not in out of camera view;
    [SerializeField]
    private bool RunInBackGround = false;
    private void OnBecameVisible()
    {
        enabled = true;
    }

    private void OnBecameInvisible()
    {
        if (!RunInBackGround)
        {
            enabled = false;

        }
    }
    //////////////////////////////////////////////////////////
}
