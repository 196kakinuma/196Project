using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IkLibrary;
using Managers;
using Player;

public class Global : SingletonClass<Global>
{
    GameManager gameManager;
    public GameManager GameManager
    {
        get
        {
            if (gameManager == null)
            {
                gameManager = GameManager.Instance;
            }
            return gameManager;
        }
    }

    PortalManager portalManager;
    public PortalManager PortalManager
    {
        get
        {
            if (portalManager == null)
            {
                portalManager = PortalManager.Instance;
            }
            return portalManager;
        }
    }

    MoveManager moveManager;
    public MoveManager MoveManager
    {
        get
        {
            if (moveManager == null)
            {
                moveManager = MoveManager.Instance;
            }
            return moveManager;
        }

    }

    PlayerController playerController;
    public PlayerController PlayerController
    {
        get
        {
            if (playerController == null)
            {
                playerController = PlayerController.Instance;
            }
            return playerController;
        }
    }

    SoundManager soundManager;
    public SoundManager SoundManager
    {
        get
        {
            if(soundManager == null){
                soundManager = SoundManager.Instance;
            }
            return soundManager;
        }
    }

    ParticleManager particleManager;
    public ParticleManager ParticleManager
    {
        get
        {
            if(particleManager == null)
            {
                particleManager = ParticleManager.Instance;
            }
            return particleManager;
        }
    }


}