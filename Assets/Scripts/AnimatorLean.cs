using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorLean : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Animator>().SetFloat("Lean", Player.GetComponent<TempleRunMovement>().PlayerInput);
    }
}
