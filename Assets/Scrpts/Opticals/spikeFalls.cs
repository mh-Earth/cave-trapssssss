using UnityEngine;

public class spikeFalls : MonoBehaviour
{
    [SerializeField]
    private bool Fall = true;
    private Rigidbody2D body;
    private RaycastHit2D rayCast;
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float gravatyApplied;
    private Vector3 rayCastPositions;
    [SerializeField]
    private float fallTriggerDistance = 1f;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        rayCastPositions = transform.position;
        rayCastPositions.x = transform.position.x - fallTriggerDistance;
    }

    private void Start() {
        OnBecameInvisible();
    }

    void isPlayerThere()
    {   

        rayCast = Physics2D.Raycast(rayCastPositions, Vector2.down, 100f, layerMask);
        // Debug.DrawRay(rayCastPositions, Vector3.down, Color.red, 100f);

        if (rayCast)
        {
            body.gravityScale = gravatyApplied;
        }



    }

    private void Update()
    {
        if (Fall)
        {

            isPlayerThere();
        }
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
