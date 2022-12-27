using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShovelHazardScript : MonoBehaviour
{
    public InventoryScript inventory;
    public GameObject obstacle;
    public GameObject collider;
    public GameObject useItemText;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (inventory.hasShovel)
            {
                useItemText.SetActive(true);
            }
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            useItemText.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown("e"))
            {
                if (useItemText.activeSelf == true)
                {
                    useItemText.SetActive(false);
                    obstacle.SetActive(false);
                    collider.SetActive(false);
                    inventory.setShovel(false);
                }
            }
        }
    }

}
