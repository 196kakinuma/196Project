using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary;

namespace Managers
{
    public class ParticleManager : SingletonMonoBehaviour<ParticleManager>
    {
        [SerializeField]
        ParticleSystem warpEffect;
        [SerializeField]
        Camera _camera;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PlayWarpEffect()
        {
            warpEffect.transform.position = _camera.transform.position +_camera.transform.forward*2;
            warpEffect.Play();
        }
    }
}