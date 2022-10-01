using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectibleMove : MonoBehaviour
{
    
    [SerializeField] private Transform tweenEndPoint;
    void Start()
    {
        transform.DOMove(tweenEndPoint.position, 1f).SetEase(Ease.InOutQuad).SetLoops(-1, LoopType.Yoyo);
    }
}

