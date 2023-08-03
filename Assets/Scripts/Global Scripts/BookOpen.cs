using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpen : MonoBehaviour
{
    public bool bookbool;
    public GameObject BookOBJ;
    // Start is called before the first frame update
    //turns the bool between on and off everytime the button is clicked
    public void BookFunction()
    {
        if (bookbool)
        {
            bookbool = false;
        }
        else
        {
            bookbool = true;
        }
    }
    //sets the book active according to the bool
    public void Update()
    {
        BookOBJ.SetActive(bookbool);



        if (bookbool)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
