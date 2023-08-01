using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Achivement_System : MonoBehaviour
{
    public string SceneName;
    public void UnlockedLevel()
    {
        SceneName = GameManage.GameManager.SceneName;
        PlayerPrefs.SetInt($"{SceneName}Int", 1);
        Debug.Log($"{SceneName}Int");
    }
}
