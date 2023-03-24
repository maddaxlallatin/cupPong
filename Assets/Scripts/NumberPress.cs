using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NumberPress : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject keyboard;
    private TMP_Text codeText;
    void Awake(){
                keyboard = GameObject.FindWithTag("Keyboard");

    }
    void Start()
    {
        keyboard.SetActive(false);
        codeText = GameObject.FindWithTag("codeText").GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressNumber(string number){
        Debug.Log(number);
        if(codeText.text.Length < 5){
        codeText.text += number;
        }
        if(codeText.text.Length == 4){
            //show submit button
        }
    }

    //add a clear button and set the refence to beginCodeEnter()
    public void beginCodeEnter(){
        keyboard.SetActive(true);
        codeText.text = "";
    }

    //add a joinRoom method, on the method connect to a room with a code (see NetworkManager.cs)
    //add a createRoom method, on the method create to a room with a code (see NetworkManager.cs)
}
