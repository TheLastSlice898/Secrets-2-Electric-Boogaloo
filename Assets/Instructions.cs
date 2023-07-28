using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour
{
    public List<Sprite> Images;
    
    public GameObject ForwardButton;
    public GameObject BackButton;
    public Image CurrentPage;
    public Image NextPage;
    public Animator BookAnim;
    [SerializeField]private int BookIndex;
    [SerializeField]private int CurrentIndex;

    
    // Start is called before the first frame update
    void Start()
    {
        CurrentIndex = BookIndex;
        CurrentPage.sprite = Images[CurrentIndex];
    }

    // Update is called once per frame
    void Update()
    {

        
        //Debug.Log(Images.Count);
        if (Images.Count == BookIndex + 1)
        {
            NoForward();
        }
        else
        {
            ForwardButton.SetActive(true);
        }

        if (BookIndex == 0)
        {
            NoBack();
        }
        else
        {
            
            BackButton.SetActive(true);
        }
    }

    public void NextImage()
    {
        NextPage.sprite = Images[BookIndex + 1];    
        BookAnim.SetTrigger("NextPage");
        BookIndex = BookIndex + 1;
    }
    public void PreviousImage()
    {
        NextPage.sprite = Images[BookIndex - 1];
        BookAnim.SetTrigger("NextPage");
        BookIndex = BookIndex - 1;
    }

    public void NoForward()
    {
        ForwardButton.SetActive(false);
    }

    public void NoBack()
    {
        BackButton.SetActive(false);
    }

}
