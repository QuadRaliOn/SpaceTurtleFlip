using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private AnimationCurve movementCurve;
    [SerializeField] private GravityChanger grabityChanger;

    public void Move(Directions direction)
    {
        StartCoroutine(MoveCoroutine(direction));
    }

    private IEnumerator MoveCoroutine(Directions direction)
    {
        Vector3 startPoint = transform.position + (grabityChanger.IsNormalGravity==true
            ? new Vector3(0f, +0.05f, 0f)
            : new Vector3(0f, -0.05f, 0f));
        float progress = 0;

        while (progress < 1)
        {
            progress += Time.deltaTime * speed;
            transform.position = Vector3.LerpUnclamped(startPoint,
                direction == Directions.Left ? startPoint + Vector3.left : startPoint + Vector3.right,
                movementCurve.Evaluate(progress));
            yield return null;
        }
        transform.position = new Vector3(Mathf.Round(transform.position.x), transform.position.y, 0);
        progress = 0;
    }
}
