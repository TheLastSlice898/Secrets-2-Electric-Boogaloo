using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    // Start is called before the first frame update

    public void Level()
    {
        GameManage.GameManager.LoadLevels();
        GameManage.GameManager.CheckLevels();
    }

}
