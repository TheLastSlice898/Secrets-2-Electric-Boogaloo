using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credit : MonoBehaviour
{
    // Start is called before the first frame update

    public void Credits()
    {
        GameManage.GameManager.LoadCredits();
    }

}
