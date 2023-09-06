using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    //static means you can access this from anywhere in your code. like, this whole file folder, so like you could call this in Chest.cs:
    //GameManager.instance;

    //this script should be everywhere in ur code?
    
    private void Awake() {
        if(GameManager.instance != null) {
            //the if statements means if there isn't already an instance of GameManager, aka GameManager has already been called once
            Destroy(gameObject);
            return; //this makes sure that we DONT run the rest of the code in Awake();. I guess it's kinda like break;?
        }

        //PlayerPrefs.DeleteAll(); // (I think) this will reset all of ur progress/states/etc. I think it lets you start fresh.

        instance = this; //?? what is "this"? //I think "this" = the first GameManager that it finds in the current scene.

        //I think SceneManager.scene loaded... is an event???
        SceneManager.sceneLoaded += LoadState; //this is so everytime a scene is loaded / event is fired, this function's functions will play..??

        DontDestroyOnLoad(gameObject); //this is so GameManager will NOT be destroyed everytime you load a scene. GameManager will remain even if you change scenes.
        //I think this is (the better) alternative to copying and pasting GameManager into every scene lol
        //to only load once so we don't have duplicate GameManagers, we could create a load screen at the start, which we will load ONLY ONCE, so that the GameManager will be loaded ONLY ONCE.
    }

    //Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    //References
    public Player player;
    //public weapon weapon..... etc ....
    public FloatingTextManager floatingTextManager;

    //Logic
    public int pesos; //how much money you have rn
    public int experience; //how much experience does ur player have rn?

    
    public int TasksDone = 0;
    // public void updateTasks(int i){
    //     tasksDone += i;

    //     if(tasksDone >= 7){
    //         Debug.Log("End of game is reached! All 7 tasks are complete!");
    //     }
    // }

    //Floating Text
    //this is so we don't have a reference to FloatingTextManager from everywhere. 
    //this is so we can just use GameManager to call this method and not have to import FloatTextManager everytime
    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration){
        floatingTextManager.Show(msg, fontSize, color, position, motion, duration);
    }

    //Save State (functions)
    /*
        INT preferedSkin
        INT pesos
        INT experience
        INT weaponLevel
    */
    public void SaveState() {
        //saves ur game
        Debug.Log("SaveState");

        //we're gonna save everytime we change scenes
        //we want to save before we exit scenes or before we exit the game

        string s = ""; //s for "saving"

        s += "0" + "|"; //preferred skin placeholder
        s += pesos.ToString() +  "|"; //ToString() turns pesos's value into a string
        s += experience.ToString() + "|";
        s += "0"; //weapons placeholder //don't need "|" because its the last trait thing

        PlayerPrefs.SetString("SaveState", s);
    }

    public void LoadState(Scene scene, LoadSceneMode mode){
        //loads ur progress

        if(!PlayerPrefs.HasKey("SaveState")) {
            return; //rhis is kinda like a break statement, except for the whole method. 
        }

        //this is loading ur game data and progress for ur stats/preferences/progress/etc
        string[] data = PlayerPrefs.GetString("SaveState").Split('|'); //we put in "SaveState" bc its gotta be the same keyword that we put in the PlayerPrefs. thing in SaveState() method function
        //the Split('|') allows the strings to be split between the pipe signs (|)
        //now, data = {preferedSkin, pesos, experience, weaponLevel} (in string form tho)

        // preferedSkin = int.Parse(data[0]); // Change player skin
        pesos = int.Parse(data[1]); //had to cast data[1] to an int using int.Parse(string s)
        experience = int.Parse(data[2]); 

        //SceneManager.sceneLoaded -= LoadState; //removing this allows LoadState to relaunch everytime! I *think* this allows ur progress to follow you everywhere..? no matter the scene??
        Debug.Log("LoadState");
    }
}
