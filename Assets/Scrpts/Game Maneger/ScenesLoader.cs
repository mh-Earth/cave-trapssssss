using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesLoader : MonoBehaviour
{

    [SerializeField]
    private int Scene;
    [SerializeField]
    private Animator anime;
    [SerializeField]
    private float waitTime = 1f;


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {

            StartCoroutine("LoadScense");

        }


    }

    IEnumerator LoadScense()
    {     
        // Playing the transition end effects;
        anime.SetTrigger("Start");

        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(Scene);

    }




}
