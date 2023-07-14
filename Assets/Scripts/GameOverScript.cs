using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Button retryButton;
    public Button quitButton;
    private Stack<string> previousScenes = new Stack<string>();

    void Start()
    {
        //Add a listener to the retryButton's click event
        Debug.Log("ummmmm why");

        retryButton.onClick.AddListener(RetryClicked);
        
        //Add a listener to the quitButton's click event

        quitButton.onClick.AddListener(QuitClicked);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("ummmmm why");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                //Get the Button component from the hit collider

                Button hitButton = hit.collider.GetComponent<Button>();

                //Check if the hitButton is the retryButton

                if (hitButton == retryButton)
                {
                    Debug.Log("ummmmm okay");
                    //Check if there are any previous scenes in the stack

                    if (previousScenes.Count > 0)
                    {
                        Debug.Log("ummmmm i don't know");
                        //Retrieve and remove the most recent scene from the stack

                        string lastScene = previousScenes.Pop();
                        //Load the last scene

                        SceneManager.LoadScene(lastScene);
                    }
                }
            }
        }
    }

    public void RetryClicked()
    {
        //Check if there are any previous scenes in the stack

        if (previousScenes.Count > 0)
        {
            //Retrieve and remove the most recent scene from the stack

            string lastScene = previousScenes.Pop();
            //Load the last scene

            SceneManager.LoadScene(lastScene);
        }
    }

    public void QuitClicked()
    {
        //Quit the application
        Debug.Log("quitted");
        Application.Quit();
    }

    public void SetPreviousScene(string sceneName)
    {
        //Add the scene name to the stack of previous scenes

        previousScenes.Push(sceneName);
    }
}
