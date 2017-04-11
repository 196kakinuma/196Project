using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary;
using Player;

namespace Managers
{

    public class PlayerManager : SingletonMonoBehaviour<PlayerManager>
    {
        [SerializeField]
        SightRaycast caster;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            //caster.RaycastForward();
        }


    }
}