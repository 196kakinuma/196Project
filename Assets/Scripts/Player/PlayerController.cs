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
        [SerializeField]
        Camera _camera;
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

        /// <summary>
        /// ワープ前の微妙にワープ先に近づく処理を行う
        /// </summary>
        public void ApproachTo(Vector3 movePos)
        {
            //movePos =  this.transform.position - movePos;
            this.transform.position += _camera.transform.forward * Time.deltaTime; //movePos.normalized*Time.deltaTime;
        }
    }
}