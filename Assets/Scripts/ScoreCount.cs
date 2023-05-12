using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
public class ScoreCount : MonoBehaviour
{

    int redScoreCount;
    int blueScoreCount;

    GameObject redGameOver;
    GameObject blueGameOver;
    GameObject gameOverUI;
    GameObject ReadyUpButton;
    public UnityEvent gameOver;
    // Start is called before the first frame update
    void Awake()
    {
        redGameOver = GameObject.Find("redSideGameOver");
        blueGameOver = GameObject.Find("blueSideGameOver");
        gameOverUI = GameObject.FindWithTag("gameOverUI");
        ReadyUpButton = GameObject.FindWithTag("ReadyUp");

    }
    void Start()
    {
        gameOverUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void updateRedScore()
    {
        redScoreCount++;
        Debug.Log("Red Score: " + redScoreCount);
        if (redScoreCount == 10)
        {
            blueWin();
        }
    }
    public void updateBlueScore()
    {
        blueScoreCount++;
        Debug.Log("Blue Score: " + blueScoreCount);
        if (blueScoreCount == 10)
        {
            redWin();
        }
    }

    void blueWin()
    {
        gameOverUI.SetActive(true);
        gameOverUI.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().GetComponent<TMP_Text>().text = "Game over \n\n Blue Wins!";
        LeanTween.scale(gameOverUI.transform.GetChild(0).gameObject.GetComponent<RectTransform>(), new Vector3(0.01f, 0.01f, 0.01f), 1.5f).setEase(LeanTweenType.easeOutBack);
            gameOver.Invoke();

    }
    void redWin()
    {
        gameOverUI.SetActive(true);
        gameOverUI.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "Game Over \n\n Red Wins!";
        LeanTween.scale(gameOverUI.transform.GetChild(0).gameObject.GetComponent<RectTransform>(), new Vector3(0.01f, 0.01f, 0.01f), 1.5f).setEase(LeanTweenType.easeOutBack);
            gameOver.Invoke();

    }
    
}
