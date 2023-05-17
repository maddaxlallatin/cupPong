using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class NetworkBall : MonoBehaviour
{
    private bool isPickedUp = false;
    private Rigidbody _rigidbody;
    private PhotonView photonView;
    private PhotonView PV;
    private AudioSource sound;
    private bool objectFirstCollision = true;

    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        _rigidbody = GetComponent<Rigidbody>();
        PV = GameObject.FindWithTag("ScriptManager").GetComponent<PhotonView>();
        sound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
        {
            if (isPickedUp)
            {
                _rigidbody.isKinematic = true;
                _rigidbody.useGravity = false;
            }
            else
            {
                _rigidbody.isKinematic = false;
                _rigidbody.useGravity = true;
            }
        }
        if (gameObject.transform.position.y < 0.3f)
        {
            if(!PhotonNetwork.InRoom || !PhotonNetwork.IsConnected){
                Destroy(gameObject);
            }

            if (photonView.IsMine)
            {
                PV.RPC("ballDestroyed", RpcTarget.All);
                PhotonNetwork.Destroy(gameObject);
                PV.RPC("streakCounter", RpcTarget.All, false);
            }
        }
    }

    public void toggleBallState(bool ballState)
    {
        photonView.RPC("BallPickedUp", RpcTarget.All, ballState);

    }

    public void requestOwnership()
    {
        photonView.RequestOwnership();
    }
    void OnCollisionEnter(Collision other)
    {

        if (objectFirstCollision)
        {
            objectFirstCollision = false;
            return;
        }
        sound.Play(0);


    }

    [PunRPC]
    void BallPickedUp(bool someValue)
    {
        isPickedUp = someValue;
    }

}
