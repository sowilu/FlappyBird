using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UiAnimator : MonoBehaviour
{
    public float value;
    public float time;

    void Start()
    {
        var endValue = transform.position.y + value;

        transform.DOMoveY(endValue, time / 2).SetLoops(-1, LoopType.Yoyo);
    }

}
