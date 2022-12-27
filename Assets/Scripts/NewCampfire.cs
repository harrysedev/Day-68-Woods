using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCampfire : MonoBehaviour
{
    // Start is called before the first frame update
    public Campfire campfire;
    public Vector3 spawnPoint;
    public GameObject thisCampfire;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            campfire.nearCampFire = true;
            campfire.displayTimer = campfire.secondsToDeath;
            setSpawnPoint();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            campfire.nearCampFire = false;
            campfire.timer = (int)Time.time + 1;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            campfire.nearCampFire = true;
            campfire.displayTimer = campfire.secondsToDeath;
        }
    }

    void setSpawnPoint()
    {
        spawnPoint = thisCampfire.transform.position - new Vector3(1.0f, 0.0f, 1.0f);
        GameData.SaveCoord("x", spawnPoint.x);
        GameData.SaveCoord("y", spawnPoint.y);
        GameData.SaveCoord("z", spawnPoint.z);
    }
}
