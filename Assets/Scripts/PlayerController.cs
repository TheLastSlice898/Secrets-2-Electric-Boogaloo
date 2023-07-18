using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]


public class PlayerController : MonoBehaviour
{

    public Rigidbody PlayerRB;
    public GameObject PlayerOBJ;
    public float MaxSpeed = 20;
    public float JumpHeight = 10;
    public bool HasJumped;
    public bool DoubleJump;
    public float playerForce;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        float MoveX = Input.GetAxis("Horizontal");
        Debug.Log(MoveX);
        PlayerRB.velocity = new Vector3(MoveX * playerForce,PlayerRB.velocity.y,PlayerRB.velocity.z);
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
    }
        //Debug.Log(PlayerRB.velocity.magnitude);
//fuck off cam
//yea fuck cam
//<3 you cam

    
    //Debug.Log(PlayerRB.velocity);
    void Jump()
    {
       if (HasJumped)
       {
        PlayerRB.AddForce((Vector3.up * JumpHeight), ForceMode.Impulse);
        HasJumped = false;
        DoubleJump = true;
       }
       else if (DoubleJump)
       {
        PlayerRB.velocity.Set(0f,0f,0f);
        PlayerRB.AddForce((Vector3.up * JumpHeight), ForceMode.Impulse);
        DoubleJump = false;
       }
      
    }
    void OnCollisionEnter(Collision Collider)
    {
        if (HasJumped == false)
        {
            HasJumped = true;
        }
    }
}
