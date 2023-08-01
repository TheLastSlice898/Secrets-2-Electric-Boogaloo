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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }   
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        float MoveX = Input.GetAxis("Horizontal");
        //Debug.Log(MoveX
        //PlayerRB.velocity.Normalize();
        
        
        
        PlayerRB.velocity = new Vector3(MoveX * playerForce,PlayerRB.velocity.y,PlayerRB.velocity.z);

        if (PlayerRB.velocity.magnitude > MaxSpeed)
        {
            PlayerRB.velocity = Vector3.ClampMagnitude(PlayerRB.velocity, MaxSpeed);    
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
        //PlayerRB.velocity.Set(0f,0f,0f);
        PlayerRB.velocity = new Vector3(PlayerRB.velocity.x, JumpHeight,PlayerRB.velocity.z);
        HasJumped = false;
        DoubleJump = true;
       }
       else if (DoubleJump)
       {
            //PlayerRB.velocity.Set(0f,0f,0f);
            PlayerRB.velocity = new Vector3(PlayerRB.velocity.x, JumpHeight, PlayerRB.velocity.z);
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
