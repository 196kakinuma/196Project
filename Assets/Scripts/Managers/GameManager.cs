using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary;
using Player;

namespace Managers
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField]
        PlayerManager playerPref;

        PlayerManager player;

        
        // Use this for initialization
        void Start()
        {
            player = Instantiate(playerPref, Global.Instance.PortalManager.GetFirstPortal().transform.position, Quaternion.identity);
            Global.Instance.PortalManager.SetPortalActiveByFirst();

        }

        // Update is called once per frame
        void Update()
        {
            Global.Instance.SoundManager.CtrlEnvSound(player.transform.position.y);
        }
    }
}