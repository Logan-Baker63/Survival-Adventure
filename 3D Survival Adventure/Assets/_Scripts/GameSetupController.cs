using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using TMPro;

public class GameSetupController : MonoBehaviourPun
{

    private string username;
    [SerializeField] private GameObject PlayerInformation;
    
    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer(); //Creates a networked player object for each player in the room
        UpdateNicknames();
    }

    private void CreatePlayer()
    {
        Debug.Log("Creating player");
        
        PlayerInformation = GameObject.FindGameObjectWithTag("PlayerInformation");

        while (PlayerInformation == null)
        {
            PlayerInformation = GameObject.FindGameObjectWithTag("PlayerInformation");
        }

        username = PlayerInformation.GetComponent<PlayerInformation>().nickname;

        GameObject newCharacter = PhotonNetwork.Instantiate(Path.Combine("_Prefabs", "Player"), Vector3.zero, Quaternion.identity);
        newCharacter.name = username;

        newCharacter.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = username;

    }

    public void UpdateNicknames()
    {

    }

}
