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
            _camera = Camera.main;
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




        #region KeyBoardMove
        Vector3 vectVer;
        Vector3 vectHori;
        [SerializeField]
        float moveSpeed = 10;
        public void MoveForward()
        {
            vectVer = _camera.transform.forward.normalized * Time.deltaTime * moveSpeed;
            vectVer.y = 0;
            this.transform.position += vectVer;
        }

        public void MoveRight()
        {
            vectHori = _camera.transform.right.normalized * Time.deltaTime * moveSpeed / 2;
            vectHori.y = 0;
            this.transform.position += vectHori;
        }

        public void MoveLeft()
        {
            vectHori = _camera.transform.right.normalized * Time.deltaTime * moveSpeed / 2;
            vectHori.y = 0;
            this.transform.position -= vectHori;
        }

        public void MoveBack()
        {
            vectVer = _camera.transform.forward.normalized * Time.deltaTime * moveSpeed/2.5f;
            vectVer.y = 0;
            this.transform.position -= vectVer;
        }
        #endregion
    }
}