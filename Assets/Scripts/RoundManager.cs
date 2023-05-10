using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;

public class RoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ConnectedToServer = false;
    private Vector3 redBallPos = new Vector3(0.5f, 0.785f, 1.5f);
    private Vector3 blueBallPos = new Vector3(0.5f, 0.78f, -1.5f);
    private int readyUp = 0;
    private int ballsSpawned = 0;
    private int currentBalls = 0;
    private int streakInt = 0;
    private string currentTurn = "red";
    bool gameStarted = false;
    public UnityEvent ballsBack;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (readyUp == 2 && !gameStarted)
        {
            nextRound(currentTurn);

            gameStarted = true;
        }
        

    }
    public void SetConnectedToServer(bool connected)
    {
        ConnectedToServer = connected;
    }



    public void nextRound(string whosTurn)
    {
        currentBalls++;
        ballsSpawned++;
        switch (whosTurn)
        {

            case "red":
                if (PhotonNetwork.CurrentRoom.MasterClientId != PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    return;
                }
                PhotonNetwork.Instantiate("Ball", redBallPos, Quaternion.identity);
                break;
            case "blue":
                if (PhotonNetwork.CurrentRoom.MasterClientId != PhotonNetwork.LocalPlayer.ActorNumber)
                {
                    PhotonNetwork.Instantiate("Ball", blueBallPos, Quaternion.identity);

                }


                break;
        }
    }

    public void clientReadyUp()
    {
        PhotonView PV;
        PV = GetComponent<PhotonView>();
        PV.RPC("serverReadyUp", RpcTarget.All);

    }
    [PunRPC]
    public void serverReadyUp()
    {
        readyUp++;
    }

    [PunRPC]
    public void ballDestroyed()
    {   
        
        currentBalls = 0;
        if (currentBalls == 0 && ballsSpawned == 2)
        {
            if(streakInt == 2){
                ballsSpawned = 0;
                streakInt = 0;
                ballsBack.Invoke();
                nextRound(currentTurn);
                return;
            } 
             else if (currentTurn == "red")
            {
                currentTurn = "blue";
            }
            else
            {
                currentTurn = "red";
            }
            ballsSpawned = 0;
            nextRound(currentTurn);
        }
        if (currentBalls == 0 && ballsSpawned == 1)
        {
            nextRound(currentTurn);
        }
        Debug.Log("Current Balls: " + currentBalls + " Balls Spawned: " + ballsSpawned + " Current streak: " + streakInt);

    }

    [PunRPC]
    public void streakCounter(bool toINC){
        if(toINC == true){
            streakInt++;
        } else {
            streakInt = 0;
        }

    }




}
