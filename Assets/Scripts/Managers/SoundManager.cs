using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary;

public class SoundManager : SingletonMonoBehaviour<SoundManager> {

    [SerializeField]
    AudioSource envSound;
    [SerializeField]
    AudioSource warpSE;
	// Use this for initialization
	void Start () {
        envSound.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayWarpSE()
    {
        warpSE.Play();
    }
}
