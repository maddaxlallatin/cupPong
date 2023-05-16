using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
public class NumberPress : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject keyboard;
    private TMP_Text codeText;
    private GameObject joinRoomButton;
    private GameObject createRoomButton;
    void Awake(){
                keyboard = GameObject.FindWithTag("Keyboard");
                joinRoomButton = GameObject.FindWithTag("joinRoomButton");
        createRoomButton = GameObject.FindWithTag("createRoomButton");

    }
    void Start()
    {
        joinRoomButton.SetActive(false);
        createRoomButton.SetActive(false);
        keyboard.SetActive(false);
        codeText = GameObject.FindWithTag("codeText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressNumber(string number){
        Debug.Log(number);
        if(codeText.text.Length < 5){
        codeText.text += number;
        }
        if(codeText.text.Length == 5){
            //show submit button
            joinRoomButton.SetActive(true);
            createRoomButton.SetActive(true);

        }
    }

    //add a clear button and set the refence to beginCodeEnter()
    public void beginCodeEnter(){
        keyboard.SetActive(true);
        codeText.text = "";
    }

    //add a joinRoom method, on the method connect to a room with a code (see NetworkManager.cs)
    //add a createRoom method, on the method create to a room with a code (see NetworkManager.cs)

    public void createRoom(){
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        roomOptions.IsVisible = true;
        roomOptions.IsOpen = true;
        PhotonNetwork.CreateRoom(codeText.text, roomOptions, TypedLobby.Default);
        codeText.text = "Creating Room...";
    }

    public void joinRoom(){
        PhotonNetwork.JoinRoom(codeText.text);
        codeText.text = "Joining Room...";
    }

    public void leaveRoom(){
        PhotonNetwork.LeaveRoom();
    }
}
