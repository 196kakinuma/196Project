using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Portal
{
    public class Portal : MonoBehaviour
    {
        Material material;

        //FIXME: PortalManagerで自動で割り振って欲しい
        [SerializeField]
        public int portalNum { get; set; }
        void Start()
        {
            //色の変更
            material = this.GetComponent<MeshRenderer>().material;
            material.color = Color.blue;
        }

        public void Selected()
        {
            material.color = Color.red;
        }
        public void ClearSelected()
        {
            material.color = Color.blue;
        }

        public Vector3 GetPortalPosition()
        {
            return this.transform.parent.transform.position;
        }
    }
}
