using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    private int Scene;
    [SerializeField]
    private Animator anime;
    [SerializeField]
    private float waitTime = 1f;

    [SerializeField] [Tooltip("Enactive all UI object those will not show in  scene transition")]
    private GameObject[] ObjectsToNotShow;

    private GameObject player;

    private void Start() {
        Scene = SceneManager.GetActiveScene().buildIndex + 1;
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag(TagManager.PLAYER_TAG))
        {

            StartCoroutine("LoadScene");

        }


    }

    IEnumerator LoadScene()

    {     

        // enactive all UI object those will not show in  scene transition
        for (int i = 0; i < ObjectsToNotShow.Length; i++)
        {

            ObjectsToNotShow[i].SetActive(false);
            
        }

        // Playing the transition end effects;
        anime.SetTrigger("Start");
        // Enactive player for not to move
        player.SetActive(false);
        // wait for the animation to end
        yield return new WaitForSeconds(waitTime);

        SceneManager.LoadScene(Scene);

    }



}
