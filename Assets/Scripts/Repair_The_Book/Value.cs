using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class Value : MonoBehaviour
{
    public GameObject timer; 
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        text.text = timer.GetComponent<Timer>().timeLeft.ToString();
    }
}
