using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Photon.Pun;
using Photon.Realtime;
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
            if (!PhotonNetwork.InRoom || !PhotonNetwork.IsConnected)
            {
                moveUpRight();

                Destroy(other.gameObject);
            }
            if (other.gameObject.GetComponent<PhotonView>().IsMine)
            {

                PV.RPC("moveCup", RpcTarget.All, gameObject.transform.parent.name);
                PV.RPC("streakCounter", RpcTarget.All, true);
                PV.RPC("ballDestroyed", RpcTarget.All);
                PhotonNetwork.Destroy(other.gameObject);

            }
            // transform.parent.gameObject.transform.position = new Vector3((transform.parent.gameObject.transform.position.x + 0.5f), transform.parent.gameObject.transform.position.y, transform.parent.gameObject.transform.position.z);
            //  gameObject.SetActive(false);
            scoreUpdated();

            void moveUpRight()
            {
                LeanTween.move(gameObject.transform.parent.gameObject, new Vector3((gameObject.transform.parent.transform.position.x), gameObject.transform.parent.transform.position.y + 0.25f, gameObject.transform.parent.transform.position.z), 0.5f).setEase(LeanTweenType.easeOutQuad).setOnComplete(moveRight);
            }
            void moveRight()
            {
                LeanTween.move(gameObject.transform.parent.gameObject, new Vector3((gameObject.transform.parent.transform.position.x - 0.5f), gameObject.transform.parent.transform.position.y, gameObject.transform.parent.transform.position.z), 0.5f).setEase(LeanTweenType.easeOutQuad).setOnComplete(moveDown);

            }
            void moveDown()
            {
                LeanTween.move(gameObject.transform.parent.gameObject, new Vector3((gameObject.transform.parent.transform.position.x), gameObject.transform.parent.transform.position.y - 0.25f, gameObject.transform.parent.transform.position.z), 0.5f).setEase(LeanTweenType.easeOutQuad);

            }
        }
    }



    void scoreUpdated()
    {
        scoreUpdate.Invoke();
    }
}
