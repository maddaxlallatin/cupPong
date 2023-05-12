using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;
public class cupManager : MonoBehaviour
{
    private PhotonView PV;
    public UnityEvent updateRedScore;
    public UnityEvent updateBlueScore;
    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void moveCup(string cupName){
        if(cupName.Contains("red")){
            updateBlueScore.Invoke();
        }
        else{
            updateRedScore.Invoke();
        }
            Debug.Log("Cup Name: " + cupName);
            GameObject cup = GameObject.Find(cupName);
            moveUpRight();
            void moveUpRight()
            {
                LeanTween.move(cup, new Vector3((cup.transform.position.x), cup.transform.position.y + 0.25f, cup.transform.position.z), 0.5f).setEase(LeanTweenType.easeOutQuad).setOnComplete(moveRight);
            }
            void moveRight()
            {
                LeanTween.move(cup, new Vector3((cup.transform.position.x - 0.5f), cup.transform.position.y, cup.transform.position.z), 0.5f).setEase(LeanTweenType.easeOutQuad).setOnComplete(moveDown);

            }
            void moveDown()
            {
                LeanTween.move(cup, new Vector3((cup.transform.position.x), cup.transform.position.y - 0.25f, cup.transform.position.z), 0.5f).setEase(LeanTweenType.easeOutQuad);

            }
            cup.transform.GetChild(0).gameObject.SetActive(false);

    }
}
