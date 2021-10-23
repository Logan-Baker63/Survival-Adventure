using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;
public class MenuController : MonoBehaviourPunCallbacks
{
    //[SerializeField] private string VersionName = "0.1";
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject JoinMenu;
    [SerializeField] private GameObject HostMenu;

    [SerializeField] private GameObject JoinGameInput;
    [SerializeField] private GameObject HostGameInput;

    [SerializeField] private GameObject UsernameInput;

    private string Username;

    [SerializeField] private GameObject NicknameSuccessText;
    [SerializeField] private GameObject NicknameFailText;

    [SerializeField] private PlayerInformation PlayerInformation;

    private void Awake()
    {
        //PhotonNetwork.ConnectUsingSettings(VersionName);
    }

    private void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        HideUI();
        MainMenu.SetActive(true);
    }

    public void SetNickname()
    {
        if (UsernameInput.GetComponent<TextMeshProUGUI>().text.Length != 1 && UsernameInput.GetComponent<TextMeshProUGUI>().text.Length <= 30)
        {
            Username = UsernameInput.GetComponent<TextMeshProUGUI>().text;
            Debug.Log(Username);
            NicknameFailText.SetActive(false);
            NicknameSuccessText.SetActive(true);
            PlayerInformation.nickname = Username;
        }
        else
        {
            NicknameSuccessText.SetActive(false);
            NicknameFailText.SetActive(true);
        }
    }

    public void HideUI()
    {
        MainMenu.SetActive(false);
        JoinMenu.SetActive(false);
        HostMenu.SetActive(false);
        //NicknameSuccessText.SetActive(false);
        //NicknameFailText.SetActive(false);

    }

    private void Update()
    {
        
    }

    

    public override void OnConnectedToMaster()
    {
        //PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Successfully connected to the " + PhotonNetwork.CloudRegion + " server!!!");
    }


}
