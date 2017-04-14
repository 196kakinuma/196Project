using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object;

namespace Managers
{
    /// <summary>
    /// 直線に走る車をマネージする
    /// </summary>
    public class LinerCarsManager : MonoBehaviour
    {
        [SerializeField]
        Transform startPosition;
        [SerializeField]
        Transform endPosition;

        [SerializeField]
        LinerMove carPref;

        [SerializeField]
        float interval = 3f;
        
        // Use this for initialization
        void Start()
        {

        }

        float countInterval=0;
        // Update is called once per frame
        void Update()
        {
            if (countInterval < interval)
            {
                countInterval += Time.deltaTime;
                return;
            }
            else
            {
                //生成
                LinerMove car =Instantiate(carPref);
                car.startPosition = this.startPosition.position;
                car.endPosition = this.endPosition.position ;
                countInterval = 0;

            }
        }
    }
}