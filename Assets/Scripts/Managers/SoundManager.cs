using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary;

public class SoundManager : SingletonMonoBehaviour<SoundManager> {

    [SerializeField]
    AudioSource envSound;
    [SerializeField]
    AudioSource warpSE;
    [SerializeField]
    AudioSource windSound;
	// Use this for initialization
	void Start () {
        envSound.Play();
        windSound.Play();
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void PlayWarpSE()
    {
        warpSE.Play();
    }


    float thresholdHeight = 50;
    private float beforeHeight=-1; 
    /// <summary>
    /// キャラクターのいる高さによって環境音の大きさ,サウンドそのものを変更する
    /// </summary>
    /// <param name="height">プレイヤーのいる高さy</param>
    public void CtrlEnvSound(float height)
    {
        if (beforeHeight == height) return;
        beforeHeight = height;



        if (height > thresholdHeight)
        {
            height = thresholdHeight - 0.5f;
            
        }
        envSound.volume =1 - (height/thresholdHeight);
        windSound.volume= (height / thresholdHeight)-0.1f;

    }
}
