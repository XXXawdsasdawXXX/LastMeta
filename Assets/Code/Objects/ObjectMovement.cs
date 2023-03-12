using System;
using DG.Tweening;
using UnityEngine;

namespace Code.Objects
{
    public class ObjectMovement : MonoBehaviour
    {
        [SerializeField] private float _distance = 2;
        [SerializeField] private float _cycleLength = 10;
        

        void Start()
        {
            Vector3 target = transform.position;
            target.x += _distance;
            transform.DOMove(target, _cycleLength).SetEase(Ease.Flash).SetLoops(-1, LoopType.Yoyo);
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawRay(transform.position, Vector3.right * _distance);
        }
    }
}