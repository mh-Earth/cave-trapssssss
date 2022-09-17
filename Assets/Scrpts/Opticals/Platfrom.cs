using UnityEngine;

public class Platfrom : MonoBehaviour
{

    private GameObject player;
    private bool isPlatform;
    [SerializeField]
    private bool canStayOnPlatform = true;
    private void Start()
    {

        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);
    }

    private void Update()
    {
        if (canStayOnPlatform)
        {

            if (isPlatform)
            {
                player.transform.SetParent(this.transform);
                return;
            }
            player.transform.SetParent(null);

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {
            isPlatform = true;

        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {

        if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {

            isPlatform = false;

        }

    }

}
