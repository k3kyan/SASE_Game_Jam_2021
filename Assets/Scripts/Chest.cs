using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    // protected override void OnCollide(Collider2D coll)
    // {
    //     //2:02:00
    //     //YOOO BOI LOL IT WAS SPAMMING THE DEBUG.LOG() BECAUSE YOU PUT THE CHEST ON TOP OF ANOTHER COLLIDER (THE WALL). 
    //     //Hmm... thats kind of a problem tho bc I'll def want something touching the wall... Esp like, ornaments... Or maybe its not a
    //     //problem actually. It can be constant, yeah. Hm, I'll ponder this later, but I'm p sure this is actually a good thing..
    //     //No yeah bc it was just outputting "Grant pesos" whenever it collided with ANYTHING, and I didn't specify outputting the coll.name
    //     //to the debugging log. If I had, it probably would've given me the name of the wall or something. WAIT NO YEAH THAT'S EXACTLY WHAT HAPPENED!!
    //     //ITS LITERALLY WHAT HAPPENED BC THAT WHOLE COLLISION LAYER IS CALLED "Collision" SO coll.name *IS* "Collision"!!! Yoooo. 
    //     //base.OnCollide(coll);
    //     //Debug.Log("Grant pesos"); //1:57:30
    //     //Debug.Log(coll.name);

    //     //if(coll.name == "Player") 
    //     //if you put the Debug.Log() into this if statement, it probably would have only printed out to the Debug log if the Player was
    //     //the one touching, and not outputted to the debug log for the Collision wall collider. 
    // }

    public Sprite emptyChest; //so we can swap the full chest sprite to the empty chest sprite
    public int pesosAmount = 5; //tells how much pesos you're gonna earn from this

    protected override void OnCollect()
    {
        //collected = true;//base.OnCollect(); //this is literally  just "collected = true;"

        //Debug.Log("Grant pesos");

        //if it hasn't been collected previously, you can collect it now.
        if(!collected) {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            //Vector3.up * 50 means every frame(?) we're gonna gain 50 pixels in height??
            //GameManager.instance.ShowText("+" + pesosAmount + " pesos!", 25, Color.yellow, transform.position, Vector3.up * 50, 3.0f);
            Debug.Log("Grant " + pesosAmount + " pesos!");
        }
    }
}

//2020.3