using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{

    private GameObject player;
    private GameObject Respawn;


    private void OnEnable() {

        GameManager.gameOverInfo += GameOverScene;
        
    }


    private void Start() {
        player = GameObject.FindGameObjectWithTag(TagManager.PLAYER_TAG);
        Respawn = GameObject.FindGameObjectWithTag(TagManager.SPAWN_POINT);
        
    }
    

    void GameOverScene(){

        SceneManager.LoadScene("Game Over");



    }

    private void OnDisable() {
        GameManager.gameOverInfo -= GameOverScene;

    }


}
