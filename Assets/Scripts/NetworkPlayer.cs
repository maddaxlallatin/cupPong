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
    // Start is called before the first frame update
    private void Awake()
    {
        if (localHead == null)
            localHead = GameObject.FindWithTag("Local Head");

        if (localLeftHand == null)
            localLeftHand = GameObject.FindWithTag("Local Left Hand");

        if (localRightHand == null)
            localRightHand = GameObject.FindWithTag("Local Right Hand");

    }
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PV.IsMine)
        {
            networkLeftHand.gameObject.SetActive(false);
            networkRightHand.gameObject.SetActive(false);
            networkHead.gameObject.SetActive(false);
            networkHead.transform.position = localHead.transform.position;
            networkHead.transform.rotation = localHead.transform.rotation;

            //Left Hand
            networkLeftHand.transform.position = localLeftHand.transform.position;
            networkLeftHand.transform.rotation = localLeftHand.transform.rotation;

            //Right Hand
            networkRightHand.transform.position = localRightHand.transform.position;
            networkRightHand.transform.rotation = localRightHand.transform.rotation;
        }

    }
}
