using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class SceneTransitionScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void TransitionToGameOverScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        GameObject gameOverObject = GameObject.FindWithTag("GameOver");
        GameOverScript gameOverScript = gameOverObject.GetComponent<GameOverScript>();
        gameOverScript.SetPreviousScene(currentSceneName);
        SceneManager.LoadScene("GameOverScene");
    }
}
