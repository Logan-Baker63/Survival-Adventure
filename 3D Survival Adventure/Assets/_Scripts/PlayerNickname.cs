using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerNickname : MonoBehaviourPun
{
    
    [SerializeField] private TextMeshPro nickname;
    
    // Start is called before the first frame update
    void Start()
    {
        if (photonView.IsMine) { return; }

        SetName();
    }

    private void SetName()
    {
        nickname.text = photonView.Owner.NickName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
