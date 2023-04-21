using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Photon.Pun;
public class NetworkPlayer : MonoBehaviour
{

    //Head
    private GameObject localHead;
    public GameObject networkHead;

    //Left Hand
    private GameObject localLeftHand;
    public GameObject networkLeftHand;

    //Right Hand
    private GameObject localRightHand;
    public GameObject networkRightHand;
    private PhotonView PV;
    public Animator leftHandAnimator;
    public Animator rightHandAnimator;
    
    private void Awake()
    {
        if (localHead == null)
            localHead = GameObject.FindWithTag("Local Head");

        if (localLeftHand == null)
            localLeftHand = GameObject.FindWithTag("Local Left Hand");

        if (localRightHand == null)
            localRightHand = GameObject.FindWithTag("Local Right Hand");

        

    }

    void UpdateHandAnimation(InputDevice targetDevice, Animator handAnimator)
    {
        if(PV.IsMine){
        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))
        {
            handAnimator.SetFloat("Trigger", triggerValue);
        }
        else
        {
            handAnimator.SetFloat("Trigger", 0);
        }

        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))
        {
            handAnimator.SetFloat("Grip", gripValue);
        }
        else
        {
            handAnimator.SetFloat("Grip", 0);
        }
        }
    }
    void Start()
    {
        PV = GetComponent<PhotonView>();
        if(PV.IsMine){
            foreach (var item in GetComponentsInChildren<Renderer>())
        {
           // item.enabled = false;
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            


            networkHead.transform.position = localHead.transform.position;
            networkHead.transform.rotation = localHead.transform.rotation;

            //Left Hand
            networkLeftHand.transform.position = localLeftHand.transform.position;
            networkLeftHand.transform.rotation = localLeftHand.transform.rotation;

            //Right Hand
            networkRightHand.transform.position = localRightHand.transform.position;
            networkRightHand.transform.rotation = localRightHand.transform.rotation;

            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.LeftHand), leftHandAnimator);
            UpdateHandAnimation(InputDevices.GetDeviceAtXRNode(XRNode.RightHand), rightHandAnimator);
        }

    }
}
