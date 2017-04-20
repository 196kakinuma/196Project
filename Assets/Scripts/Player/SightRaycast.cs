﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class SightRaycast : MonoBehaviour
    {
        [SerializeField]
        bool raycastDebug = false;
        [SerializeField]
        Camera camera;

        const string PORTAL = "portal";
        [SerializeField]
        const float rayLength = 1000f;
        [SerializeField]
        const float hitTrueTime = 0.5f;
        [SerializeField]
        float rayRadious = 1f;

        Ray ray;
        RaycastHit hit;

        int hitPortalNum;
        bool hitting = false;
        float hitTime = 0f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            RaycastForward();
        }


        public void RaycastForward()
        {
            ray = new Ray(camera.transform.position, transform.TransformDirection(camera.transform.forward) * 200);
            //if (Physics.Raycast(ray.origin, ray.direction, out hit, rayLength))

            if (Application.loadedLevelName == "World")
            {
                if (Physics.SphereCast(ray, rayRadious, out hit, rayLength))
                {

                    //指定時間以上レイを当てたら
                    if (hitTime >= hitTrueTime)
                    {
                        Global.Instance.PortalManager.SetSelectPortalNum(hitPortalNum);
                    }

                    if (hit.collider.tag == PORTAL)
                    {
                        HitManage();
                    }


                    if (raycastDebug)
                    {
                        Debug.Log(hit.collider.name);
                        OnDrawGizmos();
                    }
                }
                else
                {
                    hitting = false;
                    hitTime = 0f;
                    hitPortalNum = -1;
                    Global.Instance.PortalManager.ClearPortalSelect();
                }
            }

        }

        int correntWatchPortal = -1;
        /// <summary>
        /// raycastがportalに反応している時に呼ばれる。
        /// カウントなどをおこなう
        /// </summary>
        void HitManage()
        {
            correntWatchPortal = hit.collider.GetComponent<Portal.Portal>().portalNum;
            if (!hitting || hitPortalNum!=correntWatchPortal)
            {
                hitting = true;
                hitTime = 0f;
                hitPortalNum = correntWatchPortal;
                Global.Instance.PortalManager.ClearPortalSelect();
            }
            else
            {
                hitTime += Time.deltaTime;
            }
        }

        /// <summary>
        /// なんかえらーが出るが一応可視化することが可能
        /// </summary>
        void OnDrawGizmos()
        {

            Gizmos.DrawRay(camera.transform.position, camera.transform.forward * hit.distance);
            Gizmos.DrawWireSphere(camera.transform.position + camera.transform.forward * (hit.distance), rayRadious);

        }

    }
}