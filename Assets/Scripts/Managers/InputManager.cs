using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary;
using System;
using Player;

namespace Managers
{
    /// <summary>
    /// 入力を処理にしたい
    /// </summary>
    public class InputManager : SingletonMonoBehaviour<InputManager>
    {
        void Update()
        {

            //if (Input.GetKeyUp(KeyCode.Space))
            if(Input.GetKeyUp(KeyCode.JoystickButton0))
            {
                Debug.Log("button Pressed");
                Global.Instance.MoveManager.Move();
            }

            if (Input.GetKey(KeyCode.W))
            {
                PlayerController.Instance.MoveForward();
            }
            if (Input.GetKey(KeyCode.S))
            {
                PlayerController.Instance.MoveBack();
            }
            if (Input.GetKey(KeyCode.A))
            {
                PlayerController.Instance.MoveLeft();
            }
            if (Input.GetKey(KeyCode.D))
            {
                PlayerController.Instance.MoveRight();
            }
        }

       
    }
}
