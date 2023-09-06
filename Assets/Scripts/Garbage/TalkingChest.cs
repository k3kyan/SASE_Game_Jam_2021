using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TalkingChest : Collectable
{

    // public Sprite emptyChest; //so we can swap the full chest sprite to the empty chest sprite
    // public int pesosAmount = 5; //tells how much pesos you're gonna earn from this

    // public TextMeshProUGUI textDisplay;
    // public string[] sentences;
    // private int index;
    // public float typingSpeed;

    // public GameObject continueButton;

    // protected override void OnCollect()
    // {
    //     //collected = true;//base.OnCollect(); //this is literally  just "collected = true;"

    //     //Debug.Log("Grant pesos");

    //     //if it hasn't been collected previously, you can collect it now.
    //     if(!collected) {
    //         collected = true;
    //         GetComponent<SpriteRenderer>().sprite = emptyChest;
    //         //Vector3.up * 50 means every frame(?) we're gonna gain 50 pixels in height??
    //         //GameManager.instance.ShowText("+" + pesosAmount + " pesos!", 25, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
    //         Debug.Log("Grant " + pesosAmount + " pesos!");
    //         StartCoroutine(Type());
    //         //Start();
    //     }
    // }

    // // void Start(){
    // //     StartCoroutine(Type());
    // // }
    
    // void Update(){
    //     if(textDisplay.text == sentences[index]){
    //         continueButton.SetActive(true);
    //     }
    // }

    // IEnumerator Type(){

    //     foreach(char letter in sentences[index].ToCharArray()){
    //         textDisplay.text += letter;
    //         yield return new WaitForSeconds(0.02f);
    //     }
    // }

    // public void NextSentence(){
    //     continueButton.SetActive(false);

    //     if(index < sentences.Length - 1){
    //         index++;
    //         textDisplay.text = "";
    //         StartCoroutine(Type());
    //     } else {
    //         textDisplay.text = "";
    //         continueButton.SetActive(false);
    //     }
    // }    
}

//2020.3