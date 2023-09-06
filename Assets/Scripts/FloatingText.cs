using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText //we don't need it to implement monocode, plus itd be too "heavy". we can just keep this as a C# object. However, now we need another way to update.
{
    public bool active;
    public GameObject go;
    public Text txt;
    public Vector3 motion;
    public float duration;
    public float lastShown;

    public void Show() {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }

    //hiding the game object bc we don't wanna destroy it, just hide it
    public void Hide(){
        active = false;
        go.SetActive(active);
    }

    public void UpdateFloatingText(){
        if(!active){
            return; // we dont have to do anything if we're active
        }

        //ex: 10 - 7 > 2 // the time in the game is 10 sec, we started showing the message at 7 seconds in. 
        //makes sure the time its been shown is no longer than 2 seconds. If so, it'll hide it
        if(Time.time - lastShown > duration) {
            Hide();
        }

        go.transform.position += motion * Time.deltaTime; // for every second it's active, we're gonna move the text by the motion or whatever idk
    }
}
