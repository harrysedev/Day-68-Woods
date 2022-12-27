using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearHazard : MonoBehaviour
{
    public InventoryScript inventory;
    public SceneLoader sceneLoader;
    public AudioSource source;
    public AudioClip roar;
    public float delay;
    public float tracker;
    private void Start()
    {
        tracker = 0.0f;
        delay = 16.20f;
        source = source.GetComponent<AudioSource>();
        source.clip = roar;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { 
                inventory.setShovel(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                sceneLoader.LoadSceneByName("Death Screen");
        }
    }
}
