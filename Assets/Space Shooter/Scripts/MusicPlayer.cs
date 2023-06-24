using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource track1;
    public AudioSource track2;
    public AudioSource track3;
    public AudioSource track4;
    public AudioSource track5;
    public AudioSource track6;

    public int trackSelector;
    public int trackHistory;


    void Start() //a random song is played
    {
        trackSelector = Random.Range(0, 6);

        if(trackSelector == 0)
        {
            track1.Play();
            trackHistory = 1;
        } else if(trackSelector == 1)
        {
            track2.Play();
            trackHistory = 3;
        } else if(trackSelector == 2)
        {
            track3.Play();
            trackHistory = 4;
        } else if(trackSelector == 3)
        {
            track4.Play();
            trackHistory = 5;
        } else if(trackSelector == 4)
        {
            track5.Play();
            trackHistory = 6;
        } else if(trackSelector == 5)
        {
            track6.Play();
            trackHistory = 7;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(track1.isPlaying == false && track2.isPlaying == false && track3.isPlaying == false && track4.isPlaying == false && track5.isPlaying == false && track6.isPlaying == false)
        {
                    trackSelector = Random.Range(0, 3);

        if(trackSelector == 0 && trackHistory != 1)
        {
            track1.Play();
            trackHistory = 1;
        } else if(trackSelector == 1 && trackHistory != 2)
        {
            track2.Play();
            trackHistory = 2;
        } else if(trackSelector == 2 && trackHistory != 3)
        {
            track3.Play();
            trackHistory = 3;
        } else if(trackSelector == 3 && trackHistory != 4)
        {
            track4.Play();
            trackHistory = 4;
        } else if(trackSelector == 4 && trackHistory != 5)
        {
            track5.Play();
            trackHistory = 5;
        } else if(trackSelector == 5 && trackHistory != 6)
        {
            track6.Play();
            trackHistory = 6;
        }
        }
    }
}
