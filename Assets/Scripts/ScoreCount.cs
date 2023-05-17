using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using Photon.Pun;
public class ScoreCount : MonoBehaviour
{

    int redScoreCount;
    int blueScoreCount;

    GameObject redGameOver;
    GameObject blueGameOver;
    GameObject gameOverUI;
    GameObject ReadyUpButton;
    public GameObject redCups;
    public GameObject blueCups;
    public GameObject sixRedCups;
    public GameObject threeRedCups;
    public GameObject twoRedCups;
    public GameObject oneRedCup;
    public GameObject sixBlueCups;
    public GameObject threeBlueCups;
    public GameObject twoBlueCups;
    public GameObject oneBlueCup;

    private Vector3 sixRedPos = new Vector3(-0.8226004f, 1.1094f, 1.613f);
    private Vector3 threeRedPos = new Vector3(-0.8226004f, 1.1094f, 1.7032f);
    private Vector3 twoRedPos = new Vector3(-0.8226004f, 1.1094f, 1.7032f);
    private Vector3 oneRedPos = new Vector3(-0.8226004f, 1.1094f, 1.795f);
    private Vector3 sixBluePos = new Vector3(-1.1636f, 1.1094f, -1.553936f);
    private Vector3 threeBluePos = new Vector3(-1.1636f, 1.1094f, -1.643f);
    private Vector3 twoBluePos = new Vector3(-1.1636f, 1.1094f, -1.6511f);
    private Vector3 oneBluePos = new Vector3(-1.1636f, 1.1094f, -1.6502f);
    private Vector3 BluePos = new Vector3(-1.1636f, 1.1094f, -1.466f);
    private Vector3 RedPos = new Vector3(-0.8226004f, 1.1094f, 1.523f);
    private Quaternion redRotate = Quaternion.Euler(0, 180, 0);
    private string redName = "redCups";
    private string blueName = "blueCups";
    public UnityEvent gameOver;
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
        if (redScoreCount == 4)
        {
            //rerack to six blue cups
            Destroy(GameObject.FindWithTag("blueCups"));
            blueName = "sixBlueCups";
            Instantiate(sixBlueCups, sixBluePos, Quaternion.identity);
        }
        if (redScoreCount == 7)
        {
            //rerack to three blue cups
            Destroy(GameObject.FindWithTag("sixBlueCups"));
            blueName = "threeBlueCups";
            Instantiate(threeBlueCups, threeBluePos, Quaternion.identity);
        }
        if (redScoreCount == 8)
        {
            //rerack to two blue cups
            Destroy(GameObject.FindWithTag("threeBlueCups"));
            blueName = "twoBlueCups";
            Instantiate(twoBlueCups, twoBluePos, Quaternion.identity);
        }
        if (redScoreCount == 9)
        {
            //rerack to one blue cup
            Destroy(GameObject.FindWithTag("twoBlueCups"));
            blueName = "oneBlueCup";
            Instantiate(oneBlueCup, oneBluePos, Quaternion.identity);
        }
        if (redScoreCount == 10)
        {
            blueWin();
        }
    }
    public void updateBlueScore()
    {
        blueScoreCount++;
        if (blueScoreCount == 4)
        {
            //rerack to six red cups
            Destroy(GameObject.FindWithTag("redCups"));
            redName = "sixRedCups";
            Instantiate(sixRedCups, sixRedPos, redRotate);
        }
        if (blueScoreCount == 7)
        {
            //rerack to three red cups
            Destroy(GameObject.FindWithTag("sixRedCups"));
            redName = "threeRedCups";
            Instantiate(threeRedCups, threeRedPos, redRotate);
        }
        if (blueScoreCount == 8)
        {
            //rerack to two red cups
            Destroy(GameObject.FindWithTag("threeRedCups"));
            redName = "twoRedCups";
            Instantiate(twoRedCups, twoRedPos, redRotate);
        }
        if (blueScoreCount == 9)
        {
            //rerack to one red cup
            Destroy(GameObject.FindWithTag("twoRedCups"));
            redName = "oneRedCup";
            Instantiate(oneRedCup, oneRedPos, redRotate);
        }
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
        ReadyUpButton.SetActive(true);
        Destroy(GameObject.FindWithTag("ball"));
        Destroy(GameObject.FindWithTag(blueName));
        Destroy(GameObject.FindWithTag(redName));
        Instantiate(blueCups, BluePos, Quaternion.identity);
        Instantiate(redCups, RedPos, redRotate);
        foreach (Transform child in GameObject.Find("deadCups").transform)
        {
            Debug.Log("destroying");
            Destroy(child.gameObject);
        }
        blueScoreCount = 0;
        redScoreCount = 0;



    }
    void redWin()
    {
        gameOverUI.SetActive(true);
        gameOverUI.transform.GetChild(0).gameObject.GetComponent<TMP_Text>().text = "Game Over \n\n Red Wins!";
        LeanTween.scale(gameOverUI.transform.GetChild(0).gameObject.GetComponent<RectTransform>(), new Vector3(0.01f, 0.01f, 0.01f), 1.5f).setEase(LeanTweenType.easeOutBack);
        gameOver.Invoke();
        ReadyUpButton.SetActive(true);
        Destroy(GameObject.FindWithTag("ball"));
        Destroy(GameObject.FindWithTag(blueName));
        Destroy(GameObject.FindWithTag(redName));
        Instantiate(blueCups, BluePos, Quaternion.identity);
        Instantiate(redCups, RedPos, redRotate);
        foreach (Transform child in GameObject.Find("deadCups").transform)
        {
            Debug.Log("destroying");
            Destroy(child.gameObject);
        }
                blueScoreCount = 0;
        redScoreCount = 0;

    }

}
