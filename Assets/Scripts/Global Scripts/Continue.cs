using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Continue : MonoBehaviour
{
    // Start is called before the first frame update
public void GoToNextScene()
    {
        GameManage.GameManager.NextScene();
    }
}
