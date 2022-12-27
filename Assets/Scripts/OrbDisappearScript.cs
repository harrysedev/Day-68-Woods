using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDisappearScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject orb;
    public InventoryScript inventory;
    public GameObject ItemPickupText;

    private void Start()
    {
        inventory.setOrb(false);
        ItemPickupText.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ItemPickupText.SetActive(true);
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {
                orb.SetActive(false);
                inventory.setOrb(true);
                //inventory.setShovel(false);
                ItemPickupText.SetActive(false);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ItemPickupText.SetActive(false);
        }
    }
}
