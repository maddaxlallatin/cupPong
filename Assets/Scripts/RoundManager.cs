using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class RoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool ConnectedToServer = false;
    private Vector3 redBallPos = new Vector3(0.5f,0.785f,1.5f);
    private Vector3 blueBallPos = new Vector3(-0.345f,0.78f,-1.4f);
   bool ballSpawned = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void SetConnectedToServer(bool connected)
    {
        ConnectedToServer = connected;
    }

    public void nextRound(string whosTurn){
        
        switch(whosTurn){
            case "red":
                PhotonNetwork.Instantiate("Ball", redBallPos, Quaternion.identity);
                break;
            case "blue":

            PhotonNetwork.Instantiate("Ball", blueBallPos, Quaternion.identity);

                
                break;
        }
    }
}
