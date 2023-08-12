using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Bgmsourse;
    public AudioSource soundeffect;

    public List<AudioClip> bgmclip = new List<AudioClip>();
    public List<AudioClip> explosionclip = new List<AudioClip>();
    public List<AudioClip> itemclip = new List<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
