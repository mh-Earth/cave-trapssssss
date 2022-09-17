using UnityEngine;

public class HallAwayLoop : MonoBehaviour
{


    private GameObject player;
    private GameObject repwanPoint;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);
        repwanPoint = GameObject.FindGameObjectWithTag(TagManager.SPAWN_POINT);


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {

            player.transform.position = repwanPoint.transform.position;

        }
    }

}







