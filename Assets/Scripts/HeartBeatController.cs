using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBeatController : MonoBehaviour
{
    public AudioSource source;
    public AudioSource source2;
    public AudioClip scary1;
    public AudioClip scary2;
    public AudioClip scary3;
    public AudioClip clip;
    public AudioClip clip2;
    public AudioClip clip3;
    public Campfire campfire;
    public int timer;
    public int prevTier;
    public void Awake()
    {
        //PlayerPrefs.DeleteAll();
        source = source.GetComponent<AudioSource>();
        source2 = source2.GetComponent<AudioSource>();
        source.loop = true;
        prevTier = 3;
    }

    public void Update()
    {
        if (campfire.displayTimer <= 1.5)
        {
            source2.clip = scary3;
            if (!source2.isPlaying)
            {
                source2.Play();
            }
        }
        if (!campfire.nearCampFire)
        {
            if ((float)campfire.displayTimer / (float)campfire.secondsToDeath > 0.666f)
            {
                prevTier = 3;
                source.clip = clip;
                if (!source.isPlaying)
                {
                    source.Play();
                }
            }
            else if ((float)campfire.displayTimer / (float)campfire.secondsToDeath > 0.333f)
            {
                if (prevTier == 3)
                {
                    source2.clip = scary1;
                    source2.Play();
                }
                prevTier = 2;
                source.clip = clip2;
                if (!source.isPlaying)
                {
                    source.Play();
                }
            }
            else
            {
                if (prevTier == 2)
                {
                    source2.clip = scary2;
                    source2.Play();
                }
                prevTier = 1;
                source.clip = clip3;
                if (!source.isPlaying)
                {
                    source.Play();
                }
            }
        }
        else
        {
            source.Pause();
        }
    }
}
