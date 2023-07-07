using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForkScript : MonoBehaviour
{
    [SerializeField] private int NextPath;

    public bool LeftPath;
    public bool RightPath;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int PathReturn()
    {
        return NextPath;
    }


}
