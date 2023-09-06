using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    //this class will be to list all the floating text and also keeps them in a pool (to reuse the same object over and over again)
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>(); //note: we made FloatingText in the class FloatingText.cs lol

    private void Update(){
        foreach (FloatingText txt in floatingTexts)
            txt.UpdateFloatingText(); //updates every floating text in the array every frame
    }

    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();

        floatingText.txt.text = msg; //manually changing the text
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;

        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position); //transfer world space to screen space so we can use it in the UI
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }

    //pooling mechanic
    private FloatingText GetFloatingText() {
        FloatingText txt = floatingTexts.Find(t => !t.active); // we are looking for something that is not active

        if(txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab); //?? What does (Instantiate() do??)
            txt.go.transform.SetParent(textContainer.transform); //Kelly: What ???? 2:52:00
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt); //add it to our list
        }

        return txt;
    }
}
