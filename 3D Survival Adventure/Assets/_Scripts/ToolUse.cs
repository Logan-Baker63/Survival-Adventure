using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class ToolUse : MonoBehaviourPun
{

    

    public void Start()
    {
        
    }

    public void UseAxe()
    {
        
        if (Input.GetMouseButton(0))
        {
            transform.Find("Axe").GetComponent<Animator>().Play("Axe");
        }
        else
        {
            transform.Find("Axe").GetComponent<Animator>().Play("Idle");
        }

        


    }


}
