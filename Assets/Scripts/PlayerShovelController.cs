using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShovelController : MonoBehaviour
{
    public InventoryScript inventory;
    public MeshRenderer mesh;
    public GameObject orb;
    Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        mesh.enabled = false;
        orb.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //shovel.transform.position += offset;
        if(inventory.hasShovel)
        {
            mesh.enabled = true;
        } else
        {
            mesh.enabled = false;
        }

        if (inventory.hasOrb)
        {
            orb.SetActive(true);
        }
        else
        {
            orb.SetActive(false);
        }
    }
}
