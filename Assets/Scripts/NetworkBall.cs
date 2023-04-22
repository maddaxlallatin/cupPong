using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class NetworkBall : MonoBehaviour
{
    private bool isPickedUp = false;
    private Rigidbody _rigidbody;
    private PhotonView photonView;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        _rigidbody = GetComponent<Rigidbody>();

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
    }

    public void toggleBallState(bool ballState)
    {
        photonView.RPC("BallPickedUp", RpcTarget.All, ballState);

    }

    public void requestOwnership()
    {
        photonView.RequestOwnership();
    }

    [PunRPC]
    void BallPickedUp(bool someValue)
    {
        //Debug.Log(someValue);
        isPickedUp = someValue;
    }
}
