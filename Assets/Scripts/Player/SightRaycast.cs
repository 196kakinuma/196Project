using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class SightRaycast : MonoBehaviour
    {
        [SerializeField]
        Camera camera;

        const string PORTAL = "portal";
        [SerializeField]
        const float rayLength = 2000f;
        const float hitTrueTime = 0.5f;

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
            if (Physics.Raycast(ray.origin, ray.direction, out hit, rayLength))
            {
                if (hit.collider.tag == PORTAL)
                {
                    HitManage();
                }
                else if (hitting)
                {
                    hitting = false;
                    hitTime = 0f;
                    hitPortalNum = -1;
                    Global.Instance.PortalManager.ClearPortalSelect();
                }

                //指定時間以上レイを当てたら
                if (hitTime >= hitTrueTime)
                {
                    Global.Instance.PortalManager.SetSelectPortalNum(hitPortalNum);
                }
            }

#if UNITY_EDITOR
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
#endif

        }

        /// <summary>
        /// raycastがportalに反応している時に呼ばれる。
        /// カウントなどをおこなう
        /// </summary>
        void HitManage()
        {
            if (!hitting)
            {
                hitting = true;
                hitTime = 0f;
                hitPortalNum = hit.collider.GetComponent<Portal.Portal>().portalNum;
            }
            else
            {
                hitTime += Time.deltaTime;
            }
        }

    }
}