using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.Events;
public class cupManager : MonoBehaviour
{
        Vector3[] redCupPosArray = new [] { 
            new Vector3(-1.7426f, 1.0110716f, 1.525f), 
            new Vector3(-1.6426f, 1.0110716f, 1.525f),
            new Vector3(-1.5426f, 1.0110716f, 1.525f),
            new Vector3(-1.4426f, 1.0110716f, 1.525f),
            new Vector3(-1.6926f, 1.0110716f, 1.437f),
            new Vector3(-1.5926f, 1.0110716f, 1.437f),
            new Vector3(-1.4926f, 1.0110716f, 1.437f),
            new Vector3(-1.6426f, 1.0110716f, 1.349f),
            new Vector3(-1.5426f, 1.0110716f, 1.349f),
            new Vector3(-1.5926f, 1.0110716f, 1.251f),
            };
        Vector3[] blueCupPosArray = new[]{
            new Vector3(-1.6436f, 1.0110716f, -1.466f),
            new Vector3(-1.5436f, 1.0110716f, -1.466f),
            new Vector3(-1.4436f, 1.0110716f, -1.466f),
            new Vector3(-1.3436f, 1.0110716f, -1.466f),
            new Vector3(-1.5936f, 1.0110716f, -1.376f),
            new Vector3(-1.4936f, 1.0110716f, -1.376f),
            new Vector3(-1.3936f, 1.0110716f, -1.376f),
            new Vector3(-1.5436f, 1.0110716f, -1.286f),
            new Vector3(-1.4436f, 1.0110716f, -1.286f),
            new Vector3(-1.4936f, 1.0110716f, -1.196f),
        };
    int redNum = 0;
    int blueNum = 0;
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
        
            GameObject cup = GameObject.Find(cupName);
            cup.transform.GetChild(0).gameObject.SetActive(false);
            cup.transform.SetParent(GameObject.Find("deadCups").transform);
            cup.name = "deadCup  " + cup.name;
            if(cupName.Contains("red")){
                moveUpRightRed();
            }
            else{
                moveUpRightBlue();
            }
            
            void moveUpRightRed()
            {
                LeanTween.move(cup, new Vector3((cup.transform.position.x), cup.transform.position.y + 0.25f, cup.transform.position.z), 0.5f).setEase(LeanTweenType.easeOutQuad).setOnComplete(moveRight);
            }
            void moveUpRightBlue()
            {
                LeanTween.move(cup, new Vector3((cup.transform.position.x), cup.transform.position.y + 0.25f, cup.transform.position.z), 0.5f).setEase(LeanTweenType.easeOutQuad).setOnComplete(moveRightBlue);
            }
            void moveRight()
            {
                LeanTween.move(cup, redCupPosArray[redNum], 0.5f).setEase(LeanTweenType.easeOutQuad).setOnComplete(moveDown);
                redNum++;

            }
             void moveRightBlue()
            {
                LeanTween.move(cup, blueCupPosArray[blueNum], 0.5f).setEase(LeanTweenType.easeOutQuad).setOnComplete(moveDown);
                blueNum++;

            }
            void moveDown()
            {
                LeanTween.move(cup, new Vector3((cup.transform.position.x), cup.transform.position.y - 0.25f, cup.transform.position.z), 0.5f).setEase(LeanTweenType.easeOutQuad);

            }
            

    }
}
