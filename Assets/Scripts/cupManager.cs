using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class cupManager : MonoBehaviour
{
    private PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void moveCup(string cupName){
            Debug.Log("Cup Name: " + cupName);
            Transform cup = GameObject.Find(cupName).transform;
            if(cupName.Contains("red")){
                cup.position = new Vector3((cup.position.x - 0.5f), cup.position.y, cup.position.z);
            } else {
                cup.position = new Vector3((cup.position.x - 0.5f), cup.position.y, cup.position.z);
            }
            cup.GetChild(0).gameObject.SetActive(false);

    }
}
