using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepsController : MonoBehaviour
{
    public AudioSource source;
    public AudioClip steps;
    public movement player;
    void Start()
    {
        source = source.GetComponent<AudioSource>();
        source.clip = steps;
        source.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.moving)
        {
            if (!source.isPlaying)
            {
                source.Play();
            }
        }
        else
        {
            if (source.isPlaying)
            {
                source.Pause();
            }
        }
    }
}
