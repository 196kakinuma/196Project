using UnityEngine;
using System.Collections;

namespace Object
{
    /// <summary>
    /// 直線を等速での移動を実現
    /// startとendを何かしらの方法で伝達しておくこと
    /// </summary>
    public class LinerMove : MonoBehaviour
    {

        [SerializeField, Range(0, 10)]
        float time = 1;

        [SerializeField]
        public Vector3 endPosition;
        [SerializeField]
        public Vector3 startPosition;

        [SerializeField]
        bool destroyMyself = true;

        //[SerializeField]
        //AnimationCurve curve;

        private float startTime;


        void OnEnable()
        {
            if (time <= 0)
            {
                transform.position = endPosition;
                //enabled = false;
                Destroy(this.gameObject);
                return;
            }

            startTime = Time.timeSinceLevelLoad;
            this.transform.forward = endPosition - startPosition;
        }

        void Update()
        {
            var diff = Time.timeSinceLevelLoad - startTime;
            if (diff > time)
            {
                transform.position = endPosition;
                Debug.Log(endPosition);
                //enabled = false;
                if (destroyMyself) Destroy(this.gameObject);
            }

            var rate = diff / time;
            //var pos = curve.Evaluate(rate);

            transform.position = Vector3.Lerp(startPosition, endPosition, rate);
            //transform.position = Vector3.Lerp (startPosition, endPosition, pos);

        }

        void OnDrawGizmosSelected()
        {
#if UNITY_EDITOR

            if (!UnityEditor.EditorApplication.isPlaying || enabled == false)
            {
                startPosition = transform.position;
            }

            UnityEditor.Handles.Label(endPosition, endPosition.ToString());
            UnityEditor.Handles.Label(startPosition, startPosition.ToString());
#endif
            Gizmos.DrawSphere(endPosition, 0.1f);
            Gizmos.DrawSphere(startPosition, 0.1f);

            Gizmos.DrawLine(startPosition, endPosition);
        }
    }
}