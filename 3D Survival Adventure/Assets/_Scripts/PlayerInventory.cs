using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerInventory : MonoBehaviourPun
{

    [SerializeField] private GameObject[] slots;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.IsMine)
        {
            PlayerHUDUpdate();
        }
    }

    void PlayerHUDUpdate()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forwards
        { 

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {

        }
    }

}
