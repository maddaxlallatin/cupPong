using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallTrigger : MonoBehaviour
{

    public UnityEvent scoreUpdate;
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("ball")){
            transform.parent.gameObject.transform.position = new Vector3((transform.parent.gameObject.transform.position.x + 0.5f), transform.parent.gameObject.transform.position.y, transform.parent.gameObject.transform.position.z);
            gameObject.SetActive(false);        
           Debug.Log("Ball entered the trigger");
           scoreUpdated();
        }
    }

    void scoreUpdated(){
        scoreUpdate.Invoke();
    }
}
