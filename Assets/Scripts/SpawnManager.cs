using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR;
public class SpawnManager : MonoBehaviour
{
    bool ConnectedToServer = false;
    public GameObject ballPrefab;
    bool pressed = false;
    UnityEngine.XR.InputDevice device;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        var leftHandDevices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, leftHandDevices);

        if (leftHandDevices.Count == 1)
        {
            device = leftHandDevices[0];
        }
        else if (leftHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }
        if (!ConnectedToServer && device.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue) && triggerValue == true && pressed == false)
        {
            pressed = true;
            Debug.Log(triggerValue);
            SpawnBall();
        }
        if(device.TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerValue2) && triggerValue2 == false){
            pressed = false;
        }
    }

    public void SpawnBall()
    {
        if (ConnectedToServer)
        {
            PhotonNetwork.Instantiate("Ball", new Vector3(0, 0, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(ballPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }

    public void SetConnectedToServer(bool connected)
    {
        ConnectedToServer = connected;
    }
}
