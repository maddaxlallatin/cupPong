using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
public class XrGrabNetworkInteractable : XRGrabInteractable
{
    private PhotonView photonView;
    private Rigidbody _rigidbody;
    public bool isPickedUp = false;
    // Start is called before the first frame update
    void Start()
    {
        photonView = GetComponent<PhotonView>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        photonView.RequestOwnership();
        base.OnSelectEntered(args);
    }
    
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
    }


}
