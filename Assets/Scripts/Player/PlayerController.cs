using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary;
using Managers;

namespace Player
{
    /// <summary>
    /// プレイヤーにアタッチされている
    /// </summary>
    public class PlayerController : SingletonMonoBehaviour<PlayerController>
    {
        SightRaycast caster;
        // Use this for initialization
        void Start()
        {
            caster = this.GetComponent<SightRaycast>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        /// <summary>
        /// プレイヤーを指定したいちまで移動させる
        /// </summary>
        /// <param name="movePos">Move position.</param>
        public void MoveTo(Vector3 movePos)
        {
            this.transform.position = movePos;
        }
    }
}