using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballsBack : MonoBehaviour
{
    private GameObject ballsBackUI;
    private GameObject player;
    private GameObject redSideUI;
    // Start is called before the first frame update
    private void Awake() {
        ballsBackUI = GameObject.FindWithTag("ballsBackUI");
        redSideUI = GameObject.Find("redSide");
        player = GameObject.FindWithTag("Player");
    }
    void Start()
    {
        ballsBackUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localPoint = ballsBackUI.transform.InverseTransformPoint(player.transform.position);
        if (localPoint.z > -535.0f) transform.Rotate(0f,180f,0f);
    }

    public void animateUI(){
        LeanTween.scale(ballsBackUI.transform.GetChild(0).gameObject.GetComponent<RectTransform>(), new Vector3(0.01f, 0.01f, 0.01f), 1.5f).setEase(LeanTweenType.easeOutBack).setOnComplete(DestoyMe);
    }

    void DestoyMe(){
        LeanTween.scale(ballsBackUI.transform.GetChild(0).gameObject.GetComponent<RectTransform>(), new Vector3(0.001f, 0.001f, 0.001f), 0.5f);
        ballsBackUI.SetActive(false);
    }
}
