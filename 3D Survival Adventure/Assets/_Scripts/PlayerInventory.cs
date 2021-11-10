using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerInventory : MonoBehaviourPun
{

    [SerializeField] private GameObject[] slots;

    private ToolUse toolUse;

    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine)
        {
            toolUse = GetComponent<ToolUse>();
        }
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
            Debug.Log("Scrolled Forwards");
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            Debug.Log("Scrolled Backwards");
        }

        toolUse.UseAxe();


    }

}
