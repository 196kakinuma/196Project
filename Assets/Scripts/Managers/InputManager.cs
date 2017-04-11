using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary;
using System;

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
            //DownKeyCheck();
        }

        void DownKeyCheck()
        {
            if (Input.anyKeyDown)
            {
                foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
                {
                    if (Input.GetKeyDown(code))
                    {
                        //処理を書く
                        Debug.Log(code);
                        break;
                    }
                }
            }
        }
    }
}
