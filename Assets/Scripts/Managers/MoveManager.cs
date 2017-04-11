using System;
using UnityEngine;
using Player;

namespace Managers
{
    /// <summary>
    /// キャラクターを移動させるクラス
    /// </summary>
    public class MoveManager
    {
        public MoveManager()
        {
        }

        /// <summary>
        /// ポータルを消すなどの処理をしてから、
        /// キャラクターを移動させる
        /// </summary>
        public void Move()
        {
            PortalManager port = Global.Instance.PortalManager;

            if (!port.IsSelecting()) return;
            //ポータルのActiveを変更
            Global.Instance.PortalManager.SetPortalActiveByMove();
            //移動関数を呼ぶ
            PlayerController.Instance.MoveTo(port.GetSelectingPortal().GetPortalPosition());
        }
    }
}
