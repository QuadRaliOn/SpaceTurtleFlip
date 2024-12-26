using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Bottle : MonoBehaviour
{
    [SerializeField] private float destroyTime;
    [SerializeField] private float levitateSpeed;
    [SerializeField] private float amplitude = 0.5f;
    [SerializeField] private AnimationCurve sizeOnDestoy;
    [SerializeField] Transform bottleSprite;
      
    public UnityEvent OnBottleCollected;
    public UnityEvent OnBottleDestroyed;

    private void Awake()
    {
        //StartCoroutine(Levitate());    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) 
        {
            OnBottleCollected.Invoke();
            StartCoroutine(DestroyBottle());
        }
        else if (collision.gameObject.CompareTag("Moveable"))
        {
            OnBottleDestroyed.Invoke();
            StartCoroutine(DestroyBottle());
        }
    }

    private IEnumerator DestroyBottle()
    {
        var startedSize = bottleSprite.localScale;
        float timer = 0;
        float progress = 0;
        while (timer < destroyTime)
        {
            timer += Time.deltaTime;
            progress = timer / destroyTime;
            bottleSprite.localScale = Vector3.LerpUnclamped(startedSize,Vector3.zero,sizeOnDestoy.Evaluate(progress));
            yield return null;
        }
        Destroy(gameObject);
        yield return null;
    }

    /*private IEnumerator Levitate()
    {
        float timer = 0;
        var startPos = transform.position;

        while (gameObject.activeInHierarchy)
        {
            timer += Time.deltaTime;
            transform.position = startPos + 
                new Vector3(0, amplitude * Mathf.Sin(timer * levitateSpeed),0);
            yield return null;
        }
    }*/
}
