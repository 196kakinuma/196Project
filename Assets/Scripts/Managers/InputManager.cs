using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary;

namespace Managers
{
    /// <summary>
    /// 入力を処理にしたい
    /// </summary>
    public class InputManager : SingletonMonoBehaviour<InputManager>
    {
        void Update()
        {

            if (Input.GetKeyUp(KeyCode.Space))
            {
                Debug.Log("button Pressed");
                Global.Instance.MoveManager.Move();
            }
        }
    }
}
