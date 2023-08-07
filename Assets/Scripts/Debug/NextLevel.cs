using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    // Start is called before the first frame update
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameManage.GameManager.WinScreen();
        }

    }
    public void Press()
        {
        GameManage.GameManager.WinScreen();
        }
    }
