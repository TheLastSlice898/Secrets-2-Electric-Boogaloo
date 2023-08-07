using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookIcon : MonoBehaviour
{
    // Start is called before the first frame update
public void BookOpen()
    {
        //cause i dont actually know why unity is skipping my code on my game manager i cba
        GameManage.GameManager.PauseMenu = true;
    }
}
