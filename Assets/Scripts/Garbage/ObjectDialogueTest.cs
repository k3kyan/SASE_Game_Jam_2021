using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDialogueTest : MonoBehaviour
{
    public GameObject uiObject;

    
    public ContactFilter2D filter;
    private BoxCollider2D boxCollider;
    private Collider2D[] hits = new Collider2D[10];

    protected virtual void Start(){
        boxCollider = GetComponent<BoxCollider2D>();
        //-//boxCollider = gameObject.GetComponent<BoxCollider2D>();
        uiObject.SetActive(false);
    }

    // void Start(){
    //     uiObject.SetActive(false);
    // }
    //update is called once per frame
    // void OnTriggerEnter(Collider player){
    //     if(player.gameObject.tag == "Player"){
    //         uiObject.SetActive(true);
    //         StartCoroutine("WaitForSec");
    //     }
    // }
    protected void OnCollide(Collider2D coll) {
        if(coll.name == "Player")
            uiObject.SetActive(true);
            StartCoroutine("WaitForSec");
    }

    IEnumerator WaitForSec(){
        yield return new WaitForSeconds(5);
        Destroy(uiObject);
        Destroy(gameObject);
    }

    // protected override void OnCollide(Collider2D coll) {
    //     if(coll.name == "Player")
    //         OnCollect();
    // }
}
