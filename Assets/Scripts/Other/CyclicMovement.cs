using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CyclicMovement : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector2 startPos;
    [SerializeField] Vector2 finishPos;
    [SerializeField] AnimationCurve curve;  

    private void Awake()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        float timer = 0;

        while (gameObject.activeInHierarchy)
        {
            timer += Time.deltaTime;
            float progress = (timer * speed)%1;
            transform.position = Vector2.LerpUnclamped(startPos,finishPos, curve.Evaluate(progress));
            yield return null;
        }
    }
}
