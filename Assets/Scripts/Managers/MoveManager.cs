using System;
using System.Collections;
using UnityEngine;
using Player;
using IkLibrary;

namespace Managers
{
    /// <summary>
    /// キャラクターを移動させるクラス
    /// </summary>
    public class MoveManager : SingletonMonoBehaviour<MoveManager>
    {

        /// <summary>
        /// ポータルを消すなどの処理をしてから、
        /// キャラクターを移動させる
        /// </summary>
        public void Move()
        {
            PortalManager port = Global.Instance.PortalManager;

            if (!port.IsSelecting()) return;

            StartCoroutine("StartWarp",port);
        }

        IEnumerator StartWarp(PortalManager port)
        {
            Global.Instance.PortalManager.HoldSelectPortal();
            Global.Instance.ParticleManager.PlayWarpEffect();
            Global.Instance.SoundManager.PlayBeforeWarpSE();

            //yield return new WaitForSeconds(0.7f);
            for (float time=0; time < 0.7f;)
            {
                Global.Instance.PlayerController.ApproachTo(port.transform.position);
                time += Time.deltaTime;
                Debug.Log("call co");
                yield return new WaitForEndOfFrame();
            }

            Global.Instance.SoundManager.PlayWarpSE();
            //ポータルのActiveを変更
            Global.Instance.PortalManager.SetPortalActiveByMove();
            //移動関数を呼ぶ
            PlayerController.Instance.MoveTo(port.GetDecidedMovePortal().GetPortalPosition());

        }

    }
}
