using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class RoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ConnectedToServer = false;
    private Vector3 redBallPos = new Vector3(0.5f, 0.785f, 1.5f);
    private Vector3 blueBallPos = new Vector3(-0.345f, 0.78f, -1.4f);
    private int readyUp = 0;
    private int ballsSpawned = 0;
    private int currentBalls = 0;
    private string currentTurn = "red";
    bool gameStarted = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (readyUp == 2 && !gameStarted)
        {
            nextRound(currentTurn);
            currentTurn = "blue";
            currentBalls++;
            ballsSpawned++;
            gameStarted = true;
        }

    }
    public void SetConnectedToServer(bool connected)
    {
        ConnectedToServer = connected;
    }



    public void nextRound(string whosTurn)
    {


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
        currentBalls--;
        if (currentBalls == 0 && ballsSpawned ==2)
        {
            nextRound(currentTurn);
            if (currentTurn == "red")
            {
                currentTurn = "blue";
            }
            else
            {
                currentTurn = "red";
            }
        }
    }




}
