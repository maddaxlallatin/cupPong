using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
public class BallTrigger : MonoBehaviour
{
    private PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        PV = GameObject.FindWithTag("ScriptManager").GetComponent<PhotonView>();
    }
    public UnityEvent scoreUpdate;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ball"))
        {
            if (other.gameObject.GetComponent<PhotonView>().IsMine)
            {

                PV.RPC("moveCup", RpcTarget.All, gameObject.transform.parent.name);
                PV.RPC("ballDestroyed", RpcTarget.All);
                PhotonNetwork.Destroy(other.gameObject);

            }
            // transform.parent.gameObject.transform.position = new Vector3((transform.parent.gameObject.transform.position.x + 0.5f), transform.parent.gameObject.transform.position.y, transform.parent.gameObject.transform.position.z);
            //  gameObject.SetActive(false);
            scoreUpdated();
        }
    }

    void scoreUpdated()
    {
        scoreUpdate.Invoke();
    }
}
