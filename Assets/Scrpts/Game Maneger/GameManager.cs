using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public static GameManager instance;

    public delegate void GameOver();
    public static event GameOver gameOverInfo;


    public static float Score = 0;
    public static float Coins = 0;
    public static int playerLifeCount = 20; // Max 20


    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);


        }
    }

    private void LateUpdate()
    {
        print(playerLifeCount);
        if (playerLifeCount < 1)
        {
            if (gameOverInfo != null)
            {

                gameOverInfo();
            }

        }


    }


}


