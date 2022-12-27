using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbHazard : MonoBehaviour
{
    public InventoryScript inventory;
    public GameObject obstacle;
    public GameObject collider;
    public GameObject useItemText;

    private void Start()
    {
        useItemText.SetActive(false);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (inventory.hasOrb)
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

    private void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            if (useItemText.activeSelf == true)
            {
                //inventory.setShovel(false);
                useItemText.SetActive(false);
                obstacle.SetActive(false);
                collider.SetActive(false);
                inventory.setOrb(false);
            }
        }
    }
}
