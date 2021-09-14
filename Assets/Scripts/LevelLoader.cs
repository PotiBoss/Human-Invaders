using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField] float delayBeforeLoad= 2f;

    public void LoadMenuLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadNewGame()
    {
        SceneManager.LoadScene(1);
        //FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadOptions()
    {
        SceneManager.LoadScene("Options");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
