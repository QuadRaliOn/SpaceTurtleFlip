using Assets;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Transactions;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.Video;

public enum Directions
{
    Left,
    Right
}

public class PlayerMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private AnimationCurve movementCurve;
    [SerializeField] private float speed;
    [SerializeField] private float readInputPauseTime = 0.6f;
    [SerializeField] private Trigger leftTrigger;
    [SerializeField] private Trigger leftTrigger2;
    [SerializeField] private Trigger rightTrigger;
    [SerializeField] private Trigger rightTrigger2;

    private GravityChanger gravityChanger;
    private Rigidbody2D rb;
    private float timer = 0;
    private int collidesObj = 0;
    private SpriteRenderer sprite;
    private Trigger Trigger ;
    private Trigger Trigger2;
    private Directions direction;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        gravityChanger = FindFirstObjectByType<GravityChanger>();
        gravityChanger.OnGravityFlip += FlipByDistance;
    }

    void Update()
    {
        ReadInput();
    }

    private void ReadInput()
    {
        timer += Time.deltaTime;

        if (timer > readInputPauseTime && collidesObj > 0)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                timer = 0;
                sprite.flipX = gravityChanger.IsNormalGravity;
                Trigger = leftTrigger;
                Trigger2 = leftTrigger2;
                direction = Directions.Left;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                timer = 0;
                sprite.flipX = !gravityChanger.IsNormalGravity;
                Trigger = rightTrigger;
                Trigger2 = rightTrigger2;
                direction = Directions.Right;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
            {
                foreach (GameObject go in Trigger.CollideWiths) 
                {
                    if (go.CompareTag("Moveable"))
                        Trigger.CollideWith = go;
                }
                if (Trigger.CollideWith == null || Trigger.CollideWith.CompareTag("Bottle"))
                    StartCoroutine(Move(direction));
                else if (Trigger.CollideWith.CompareTag("Moveable") && Trigger2.CollideWith == null)
                {
                    BoxMovement box;
                    if (Trigger.CollideWith.TryGetComponent<BoxMovement>(out box))
                        box.Move(direction);

                    StartCoroutine(Move(direction));
                }
            }
        }
    }

    public IEnumerator Move(Directions direction)
    {
        Vector3 startPoint = transform.position;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Bottle bottle;
        if(!collision.gameObject.TryGetComponent<Bottle>(out bottle))
        collidesObj++;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Bottle bottle;
        if (!collision.gameObject.TryGetComponent<Bottle>(out bottle))
            collidesObj--;
    }

    public void FlipByDistance()
    {
        StartCoroutine(Flip());
    }

    private IEnumerator Flip()
    {
        float timer = 0f;
        float progress = 0f;
        var startRotation = sprite.gameObject.transform.rotation.eulerAngles;
        Vector3 targetRotation =  Vector3.zero;
        if (Mathf.Abs(sprite.gameObject.transform.rotation.eulerAngles.z - 180f) < 1)
            targetRotation = new Vector3(0,0,360f);
        else
            targetRotation = new Vector3(0, 0, 180f);

        while (timer < 0.5f)
        {
            timer += Time.deltaTime;
            progress = timer / 0.5f;
            sprite.gameObject.transform.rotation = Quaternion.Euler(Vector3.Lerp(startRotation, targetRotation ,progress));
            yield return null;
        }
        sprite.gameObject.transform.rotation = Quaternion.Euler(targetRotation);
    }
}
