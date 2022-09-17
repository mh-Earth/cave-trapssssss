
using UnityEngine;

public class SawController : MonoBehaviour
{
    [SerializeField]
    private Transform position1;
    [SerializeField]
    private Transform position2;

    // private Transform position1Tra,position2Tra;

    [SerializeField]
    private float moveSpeed = .5f;

    [SerializeField]
    private float initialPosition = 1f;

    private Transform target;
    [SerializeField]
    private float rotationSpeed = 5f;
    private Vector3 tampRotation;
    private Vector3 currentVelocity;

    [SerializeField]
    private bool SmoothDump;


    void initialTarget()
    {

        if (initialPosition == 1f)
        {
            target = position1;
        }

        else if (initialPosition == 2f)
        {
            target = position2;

        }

        else
        {

            target = position1;
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
            if (target == position1)
            {
                target = position2;

            }

            else
            {
                target = position1;

            }

        }



    }


    void sawMovements()
    {   
        if(SmoothDump){
            transform.position = Vector3.SmoothDamp(transform.position,target.position,ref currentVelocity,moveSpeed);

        }
        else{
            transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }



    }


    void handelRotations()
    {
        tampRotation.z = rotationSpeed * Time.deltaTime;
        transform.Rotate(tampRotation);



    }





    private void Update()
    {
        sawMovements();
        handelRotations();

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
