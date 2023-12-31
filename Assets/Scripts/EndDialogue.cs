﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndDialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;

    //triggered by if GameManager.TasksDone is >= 7;

    void Start(){
        StartCoroutine(Type());
    }

    void Update(){
        if(textDisplay.text == sentences[index]){
            continueButton.SetActive(true);
        }
    }

    IEnumerator Type(){

        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void NextSentence(){
        continueButton.SetActive(false);

        if(index < sentences.Length - 1){
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        } else {
            textDisplay.text = "";
            continueButton.SetActive(false);
        }
    }
}
