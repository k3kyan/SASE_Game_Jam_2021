using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : Collidable
{
    //Logic
    protected bool collected; 
    // protected means its private but your children can have access to it. Private to everyone BUT ur children. 
    //Chest is a child of Collectable
    //Collectable is a child of Collidable
    //Btw, : means inherits lol. Collectable inherits Collidable, I'm p sure. 
    //so only Collectable and Chest can call bool collected, i think. 

    protected override void OnCollide(Collider2D coll) {
        if(coll.name == "Player")
            OnCollect();
    }

    protected virtual void OnCollect() {
        collected = true;
    }

}
