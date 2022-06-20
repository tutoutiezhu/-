using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    //≤•∑≈±≥æ∞“Ù¿÷
    public static Audiomanager instance { get; private set; }
    private AudioSource  audioS ;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AudioPlay(AudioClip clip ) {

        audioS.PlayOneShot(clip);
    
    }










}
