using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hasShovel = false;
    public bool hasOrb = false;
    public void setShovel(bool b)
    {
        hasShovel = b;
    }

    public void setOrb(bool b)
    {
        hasOrb = b;
    }
}
