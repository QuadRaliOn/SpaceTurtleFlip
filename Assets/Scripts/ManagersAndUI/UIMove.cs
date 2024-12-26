using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMove : MonoBehaviour
{
    [SerializeField] Vector2 startPos;
    [SerializeField] Vector2 targetPos;
    [SerializeField] AnimationCurve curve;
    [SerializeField] float moveTime;

    private RectTransform rectTransform;
    private float timer = 0;
    private float progress = 0;


    public void Move()
    {
        StartCoroutine(MoveCoututine());
    }

    public void MoveBack()
    {
        StartCoroutine(MoveBackCourutine());
    }

    private IEnumerator MoveCoututine()
    {
        var startPos = transform.localPosition;
        timer = 0;
        while (timer < moveTime)
        {
            timer += Time.deltaTime;
            progress = timer / moveTime;
            transform.localPosition = Vector3.LerpUnclamped(startPos,targetPos,curve.Evaluate(progress));
            yield return null;
        }
        transform.localPosition = targetPos;
    }

    private IEnumerator MoveBackCourutine()
    {
        timer = 0;
        while (timer < moveTime)
        {
            timer += Time.deltaTime;
            progress = timer / moveTime;
            transform.localPosition = Vector3.LerpUnclamped(targetPos, startPos, curve.Evaluate(progress));
            yield return null;
        }
        transform.localPosition = startPos;
    }
}
