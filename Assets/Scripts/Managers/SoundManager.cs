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


    [SerializeField]
    float limitheight = 60;
    private float beforeHeight=-1; 
    /// <summary>
    /// キャラクターのいる高さによって環境音の大きさを変更する
    /// </summary>
    /// <param name="height">プレイヤーのいる高さy</param>
    public void CtrlEnvSound(float height)
    {
        if (beforeHeight == height) return;
        if (height > limitheight) height = limitheight;
        envSound.volume =(Mathf.Cos( (height / limitheight)*Mathf.PI/2));

       
    }
}
