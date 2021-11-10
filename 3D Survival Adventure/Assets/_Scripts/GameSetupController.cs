using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.IO;
using TMPro;
using Cinemachine;

public class GameSetupController : MonoBehaviourPun
{

    private string username;
    [SerializeField] private PlayerInformation playerInformation;

    [SerializeField] private CinemachineFreeLook playerCamera = null;

    [SerializeField] private GameObject[] inventorySlots;

    // Start is called before the first frame update
    void Start()
    {
        CreatePlayer(); //Creates a networked player object for each player in the room
        UpdateNicknames();

        

    }

    private void CreatePlayer()
    {
        Debug.Log("Creating player");
        
        playerInformation = GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerInformation>();

        while (playerInformation == null)
        {
            playerInformation = GameObject.FindGameObjectWithTag("PlayerInformation").GetComponent<PlayerInformation>();
        }

        username = playerInformation.nickname;

        GameObject newCharacter = PhotonNetwork.Instantiate(Path.Combine("_Prefabs", "Player"), Vector3.zero, Quaternion.identity);
        newCharacter.name = username;

        playerCamera.Follow = newCharacter.transform;
        playerCamera.LookAt = newCharacter.transform;

        newCharacter.transform.GetChild(0).gameObject.GetComponent<TextMeshPro>().text = username;

        Cursor.lockState = CursorLockMode.Locked;

        UpdateInventorySlots();


    }

    public void UpdateNicknames()
    {

    }

    public void UpdateInventorySlots()
    {
        inventorySlots[0].transform.GetChild(1).GetComponent<Image>().sprite = playerInformation.slotOneImage;
        
        
    }

}
