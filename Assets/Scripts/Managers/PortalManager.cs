using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary;
using Portal;

namespace Managers
{
    public class PortalManager : SingletonMonoBehaviour<PortalManager>
    {
        [SerializeField]
        Portal.Portal[] portals;
        Dictionary<int, Portal.Portal> portalDict = new Dictionary<int, Portal.Portal>();

        [SerializeField]
        int firstPortalNum = 0;
        int nowPortalNum; //現在いるポータルの番号
        int decidedMovePortalNum = -1;

        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < portals.Length; i++)
            {
                portals[i].portalNum = i;
                portalDict.Add(i, portals[i]);
            }
        }

        // Update is called once per frame
        void Update()
        {

        }


        #region ColorChange

        const int NOTSELECT = -1;
        int selectPortalNum = NOTSELECT;
        public void SetSelectPortalNum(int i)
        {
            selectPortalNum = i;
            portalDict[selectPortalNum].Selected();
        }

        public void ClearPortalSelect()
        {
            if (selectPortalNum == NOTSELECT) return;
            portalDict[selectPortalNum].ClearSelected();
            selectPortalNum = NOTSELECT;
        }
        #endregion


        #region portalSearch

        /// <summary>
        /// 一つでもWorldにポータルがなければエラーになる
        /// </summary>
        /// <returns>The first portal.</returns>
        public Portal.Portal GetFirstPortal()
        {
            return portals[firstPortalNum];
        }


        Portal.Portal GetPortalByName(string name)
        {
            foreach (Portal.Portal port in portals)
            {
                if (port.name == name)
                    return port;
            }
            Debug.LogError("Cant find " + name + " portal");
            return null;
        }

        public Portal.Portal GetPortalByPortalNum(int i)
        {
            return portalDict[i];
        }
        #endregion



        #region portalActivate
        public void SetPortalActiveByMove()
        {
            portalDict[nowPortalNum].gameObject.SetActive(true);
            portalDict[decidedMovePortalNum].gameObject.SetActive(false);
            nowPortalNum = decidedMovePortalNum;
        }

        public void SetPortalActiveByFirst()
        {
            GetFirstPortal().gameObject.SetActive(false);
            nowPortalNum = firstPortalNum;
        }

        #endregion

        #region selectPort
        public bool IsSelecting()
        {
            if (selectPortalNum == NOTSELECT) return false;
            return true;
        }
        public Portal.Portal GetSelectingPortal()
        {
            return portalDict[selectPortalNum];
        }

        /// <summary>
        /// 移動先のポータルがエフェクト等の待ち時間時により変更されるのを防ぐ
        /// 移動前に必ず呼ぶ事
        /// それ以外では呼ばないこと
        /// </summary>
        public void HoldSelectPortal()
        {
            decidedMovePortalNum = selectPortalNum;
        }

        public Portal.Portal GetDecidedMovePortal()
        {
            return portalDict[decidedMovePortalNum];
        }
        #endregion

    }
}