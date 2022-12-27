using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Campfire : MonoBehaviour
{
    public TextMeshProUGUI text;
    public SceneLoader sceneLoader;
    public GameObject campFire;
    public GameObject player;
    public Vector3 spawnPoint;
    public int timer;
    public int displayTimer;
    public int secondsToDeath;
    public bool nearCampFire;
    // Start is called before the first frame update
    void Start()
    {
        if (GameData.GetFloatValue("x") == 0.0f)
        {
            spawnPoint = new Vector3(42.845f, 100.379f, 453.922f);
        } else
        {
            getSpawnPoint();
            nearCampFire = true;
        }
        player.transform.position = spawnPoint;
        timer = (int)Time.time - 1;
        secondsToDeath = 60;
        displayTimer = secondsToDeath;
        //text.text = displayTimer.ToString() + " seconds until death";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearCampFire = true;
            displayTimer = secondsToDeath;
            setSpawnPoint();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearCampFire = true;
            displayTimer = secondsToDeath;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            nearCampFire = false;
            timer = (int)Time.time + 1;
        }
    }
   // if(Time.time>=nextUpdate){
       //      Debug.Log(Time.time+">="+nextUpdate);
             // Change the next update (current second+1)
         //    nextUpdate=Mathf.FloorToInt(Time.time)+1;
             // Call your fonction
          //   UpdateEverySecond();
//}
// Update is called once per frame
void Update()
    {   
        if (Time.time > timer && !nearCampFire)
        {
            timer++;
            displayTimer--;
        }
        //text.text = displayTimer.ToString() + " seconds until death";

        if (displayTimer <= 0)
        {
            timer = 0;
            displayTimer = secondsToDeath;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            sceneLoader.LoadSceneByName("Death Screen");
        }
    }

    void getSpawnPoint()
    {
        float x = GameData.GetFloatValue("x");
        float y = GameData.GetFloatValue("y");
        float z = GameData.GetFloatValue("z");
        spawnPoint = new Vector3(x, y, z);
    }

    void setSpawnPoint()
    {
        spawnPoint = campFire.transform.position - new Vector3(1.0f, 0.0f, 1.0f);
        GameData.SaveCoord("x", spawnPoint.x);
        GameData.SaveCoord("y", spawnPoint.y);
        GameData.SaveCoord("z", spawnPoint.z);
    }
}
