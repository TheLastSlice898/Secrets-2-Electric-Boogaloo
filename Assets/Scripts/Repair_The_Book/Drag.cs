using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Drag : MonoBehaviour
{
    public delegate void DragEndedDelegate(Drag draggableObject);
    public DragEndedDelegate dragEndedCallback;

        
    Vector3 mousePosition;
    private bool isDragged = false; 
    private Vector3 getMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePosition = Input.mousePosition - getMousePos();
    }

    private void OnMouseUp()
    {
        isDragged = false;
        //dragEndedCallback(this);
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePosition);
    }


}

// thank you to curiousbits on youtube for the tutorial to build this script :) 
// https://youtu.be/axW46wCJxZ0 


