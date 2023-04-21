using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
public class GrabDetector : MonoBehaviourPunCallbacks
{
    private XRGrabInteractable grabInteractable;
    private Rigidbody _rigidbody;
    public bool isPickedUp;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        // Get the XRGrabInteractable component
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Add event listeners for when the object is grabbed and released
        grabInteractable.onSelectEntered.AddListener(OnGrab);
        grabInteractable.onSelectExited.AddListener(OnRelease);
    }

    private void OnGrab(XRBaseInteractor interactor)
    {
        // Do something when the object is grabbed
        Debug.Log("Object grabbed");
        this.photonView.RPC("BallPickedUp", RpcTarget.All, true);

    }

    private void OnRelease(XRBaseInteractor interactor)
    {
        // Do something when the object is released
        Debug.Log("Object released");
        this.photonView.RPC("BallPickedUp", RpcTarget.All, false);


    }



    private void Update()
    {
        //Debug.Log(isPickedUp);
        if(!this.photonView.IsMine){
            //Debug.Log("Is not mine");
        }
        /* if(isPickedUp){
            _rigidbody.isKinematic = true;
        _rigidbody.useGravity = false;
        } else { 
            _rigidbody.isKinematic = false;
            _rigidbody.useGravity = true;
        }*/
    }
    [PunRPC]
    void BallPickedUp(bool someValue)
    {
        Debug.Log(someValue);
//          isPickedUp = someValue;
    }

}
