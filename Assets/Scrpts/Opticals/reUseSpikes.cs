using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reUseSpikes : MonoBehaviour
{
    [SerializeField]
    private LayerMask layerMask;
    private RaycastHit2D raycastHit2D;
    [SerializeField]
    private Vector3 initialPosition;
    private Rigidbody2D body;
    private float speed = 5f;
    private bool isGoBack = false;
    private Vector3 rayCastPositions;
    [SerializeField]
    private float fallTriggerDistance = 1f;
    [SerializeField]
    private float downForce = 20f;

    private EdgeCollider2D EdgeCollider2D;
    private void Start()
    {
        initialPosition = transform.position;
        body = GetComponent<Rigidbody2D>();
        rayCastPositions = transform.position;
        rayCastPositions.x = transform.position.x - fallTriggerDistance;
        EdgeCollider2D = GetComponent<EdgeCollider2D>();
    }

    void isPlayerThere()
    {

        raycastHit2D = Physics2D.Raycast(rayCastPositions, Vector2.down, 80f, layerMask);

        if (EdgeCollider2D.isTrigger == false)
        {
            if (raycastHit2D)
            {
                body.velocity = new Vector2(0f, -downForce);
                Invoke("resetGoBack", 3);

            }



        }

    }

    void resetGoBack()
    {
        isGoBack = true;

    }


    void backToInitialPosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, initialPosition, speed * Time.deltaTime);
        EdgeCollider2D.isTrigger = true;

        if (Vector3.Distance(transform.position, initialPosition) < 0.1f)
        {

            isGoBack = false;
            EdgeCollider2D.isTrigger = false;


        }


    }





    void Update()
    {
        isPlayerThere();

        if (isGoBack)
        {

            backToInitialPosition();

        }

    }
}
