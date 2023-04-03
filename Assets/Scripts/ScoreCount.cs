using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{

    int redScoreCount;
    int blueScoreCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateRedScore(){
        redScoreCount++;
        Debug.Log("Red Score: " + redScoreCount);
        if(redScoreCount == 10){
            Debug.Log("Blue Wins!");
        }
    }
   public void updateBlueScore(){
        blueScoreCount++;
        Debug.Log("Blue Score: " + blueScoreCount);
        if(blueScoreCount == 10){
            Debug.Log("Red Wins!");
        }
    }
}
