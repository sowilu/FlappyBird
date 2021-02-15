using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    AudioSource audio;
    bool isTriggered = false;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isTriggered)
        {
            PointManager.inst.AddPoints();
            LevelManager.inst.LoadPipe();
            audio.Play();
            isTriggered = true;
        }


    }

    
}
