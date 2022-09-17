using UnityEngine;
using System.Collections;
public class playerDustEffect : MonoBehaviour
{

    [SerializeField]
    private ParticleSystem dust;
    private RaycastHit2D ray;
    private LayerMask layer;
    private bool isFirst = true;
    private GameObject player;
    private Rigidbody2D playerBody;
    private float dustParticleEmission;

    private void Start()
    {

        layer = LayerMask.NameToLayer("Ground");
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);
        playerBody = player.GetComponent<Rigidbody2D>();


    }
    
    public AnimationCurve curve;
    public float duration = 1f;


    public IEnumerator shaking(float duration, AnimationCurve shakingCurve) { 
        Vector3 startPosition = transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < duration) {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = startPosition + Random.insideUnitSphere * strength;
            yield return null;
        }

        transform.position = startPosition;
    }


    // void controlPlayerDustParticleAmountOverHight(){
    //         // Setting the player dust particle Effect Emission burst by player jump hight aka velocity.magnitude
    //         var emission = dust.emission;
    //         ParticleSystem.Burst[] burst = new ParticleSystem.Burst[emission.burstCount];
    //         emission.GetBursts(burst);
    //         burst[0].count = playerBody.velocity.magnitude;
    //         emission.SetBursts(burst);

    // }


    void playerJumpDustEffect()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (playerController.isGrounded)
            {   

                if(!dust.isPlaying){
                    dust.Play();
                }
            }

        }

    }


    private void FixedUpdate()
    {

        // controlPlayerDustParticleAmountOverHight();
        ray = Physics2D.Raycast(transform.position, Vector2.down, .5f, layer);

        if (ray & playerController.isGrounded)
        {
            // Avoid player for multiple dust effect
            // print(playerBody.velocity.magnitude);
            if (isFirst & playerBody.velocity.magnitude > 18f)
            {
                // Shake Camera when player fall from to much hight
                dust.Play();
                StartCoroutine(shaking(duration,curve));
                isFirst = false;

            }

            else if (isFirst & playerBody.velocity.magnitude > 10f)
            {
                dust.Play();
                isFirst = false;

            }



        }
        else
        {
            isFirst = true;

        }

    }



}
