using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public string SceneName;
    public
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        WhatSceneAmI();
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(SceneName);
    }

    public void WhatSceneAmI()
    {
        Scene MyScene = SceneManager.GetActiveScene();
        SceneName = MyScene.name;
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Additive);
    }
    public void LoadRun()
    {
        SceneManager.LoadScene("Temple_Run", LoadSceneMode.Single);
    }
}
