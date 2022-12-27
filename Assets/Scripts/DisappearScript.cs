using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shovel;
    public InventoryScript inventory;
    public GameObject ItemPickupText;
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ItemPickupText.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            ItemPickupText.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {
                if (ItemPickupText.activeSelf == true && inventory.hasShovel == false)
                {
                    shovel.SetActive(false);
                    inventory.setShovel(true);
                    ItemPickupText.SetActive(false);
                }
            }
        }
    }

}
