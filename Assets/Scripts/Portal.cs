using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

//We are inheriting from Collidable, NOT Collectable, because we don't want to collect this!
public class Portal : Collidable
{
        public string[] sceneNames;

    protected override void OnCollide(Collider2D coll)
    {

        if(coll.name == "Player"){
            //Teleport Player
            GameManager.instance.SaveState();
            string sceneName = sceneNames[Random.Range(0, sceneNames.Length)];

            //Loading a scene in Unity
            //SceneManager.LoadScene(sceneName); //You'd only use this if you called the "using UnityEngine.SceneManagement;" components/library! 
            //but this way is more clear to me personally (esp if i'm just loading one/a few scenes):
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}

//Something Epitome didn't do but you need in order for the switching scenes to work is to copy the Player object from Main into Dungeon1, 
//and also attatch the CameraMotor.cs component to the camera for the new scene.