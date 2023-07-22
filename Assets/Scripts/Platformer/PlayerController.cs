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
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        Debug.Log(PlayerRB.velocity.x);
//fuck off cam
     if(PlayerRB.velocity.x > MaxSpeed)
     {
        PlayerRB.velocity.Set(PlayerRB.velocity.x,PlayerRB.velocity.y,PlayerRB.velocity.z);
     }


    }
    void Move()
    {

            //make this a rb.addforce

        float MoveX = Input.GetAxis("Horizontal");
        PlayerRB.AddForce(new Vector3((MoveX * playerForce),0,0), ForceMode.Impulse);       
    }
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
