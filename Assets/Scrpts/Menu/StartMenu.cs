using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public void StartGame()
    {

        SceneManager.LoadScene(1);


    }

    public void quit()
    {


        Application.Quit();


    }


}
