using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        
        // 3 for extra start scene and gameoverscene and WinGame
        if (currentSceneIndex + 3 >=  SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene("end of levels");
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }
    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<GameSession>().ResetGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
