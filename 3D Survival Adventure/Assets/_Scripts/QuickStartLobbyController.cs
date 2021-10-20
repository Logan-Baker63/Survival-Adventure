using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class QuickStartLobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject QuickStartButton;
    [SerializeField] private GameObject QuickCancelButton;
    [SerializeField] private int RoomSize; //sets the amount of players in a room

    public override void OnConnectedToMaster() //callback for when the first connection is made
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        MainMenu.SetActive(true);
    }

    public void QuickStart() //run by 'Find Game' button
    {
        MainMenu.SetActive(false);
        QuickCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom(); //tries to join an existing room
        Debug.Log("Quick Start");
    }

    public override void OnJoinRandomFailed(short returnCode, string message) //callback when 'PhotonNetwork.JoinRandomRoom' fails
    {
        Debug.Log("Failed to join a room");
        CreateRoom();
    }

    void CreateRoom() //create our own room
    {
        Debug.Log("Creating room");
        int RandomRoomNumber = Random.Range(0, 10000); //Creating random room name
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
        PhotonNetwork.CreateRoom("Room" + RandomRoomNumber, roomOps); //attempts to create a new room
        Debug.Log(RandomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room.... trying again");
        CreateRoom(); //Attempts to create a room with a different name (Most likely picked a name that already exists)
    }

    public void QuickCancel() //run by the 'Quick Cancel' button to stop the client looking for a room
    {
        QuickCancelButton.SetActive(false);
        MainMenu.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }

}
