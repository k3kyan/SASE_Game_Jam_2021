using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Attempt3DialogueTrigger : MonoBehaviour
{
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];
    protected bool collected; 

    public bool allowReplay; //I don't feel like implementing this right now

    public Sprite emptyChest; //so we can swap the full chest sprite to the empty chest sprite
    public int pesosAmount = 5; 

    
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;
    private bool calledStartCoroutine;

    public GameObject continueButton;

    protected virtual void Start(){
        boxCollider = GetComponent<BoxCollider2D>();
        //-//boxCollider = gameObject.GetComponent<BoxCollider2D>();
        calledStartCoroutine = false;
        continueButton.SetActive(false);
    }

    protected virtual void Update() {
        // Collission work
        boxCollider.OverlapCollider(filter, hits);
        for (int i = 0; i < hits.Length; i++){
            if (hits[i] == null)
                continue;

            //Debug.Log(hits[i].name); //this line works!! yayyayaya mmm
            OnCollide(hits[i]);

            //the array is not cleaned up so we do it ourself
            hits[i] = null;
        }

        if(calledStartCoroutine){
            if(textDisplay.text == sentences[index]){
                continueButton.SetActive(true);
            }
        }

        // if(index == sentences.Length){
        //     textDisplay.text = "";
        // }
    }

    protected virtual void OnCollide(Collider2D coll){
        if(coll.name == "Player")
            OnCollect();
    }

    protected virtual void OnCollect() {
        //collected = true;//base.OnCollect(); //this is literally  just "collected = true;"

        //Debug.Log("Grant pesos");

        //if it hasn't been collected previously, you can collect it now.
        if(!collected) {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            //Vector3.up * 50 means every frame(?) we're gonna gain 50 pixels in height??
            //GameManager.instance.ShowText("+" + pesosAmount + " pesos!", 25, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
            Debug.Log("Grant " + pesosAmount + " pesos!");
            
            StartCoroutine(Type());

            //ADD TO GAMEMANAGER OVERALL EVENT VALUES!!
            //Debug.Log("gamemanager.variablename: " + gamemanager.variablename);
            //GameManager.updateTasks(1);
            GameObject tasksDone = GameObject.Find("TasksDone");
            GameManager gameManager = tasksDone.GetComponent<GameManager>();
            gameManager.TasksDone++;
            Debug.Log(gameManager.TasksDone);
        }
        //continueButton.SetActive(true);
        //not sure if this works but I'm hoping it does lol
        if(index < sentences.Length - 1){
            continueButton.SetActive(true);
            //prob don't increment anything here?
            // index++;
            // textDisplay.text = "";
            // StartCoroutine(Type());
        } else {
            // textDisplay.text = "";
            // continueButton.SetActive(false);
        }
    }

    IEnumerator Type(){
        foreach(char letter in sentences[index].ToCharArray()){
            textDisplay.text += letter;
            yield return new WaitForSeconds(0.02f);
        }

        // if(index == sentences.Length){
        //     textDisplay.text = "";
        // }
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



    // public GameObject UiObject;
    // public GameObject trigger;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     UiObject.SetActive(false);
    // }

    // void OnTriggerEnter(Collider other){
    //     if(other.tag == "Player"){
    //         UiObject.SetActive(true);
    //     }
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    // void OnTriggerExit(Collider other){
    //     UiObject.SetActive(false);
    //     //Destroy(trigger);
    // }
}
