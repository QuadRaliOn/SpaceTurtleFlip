using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathBox : MonoBehaviour
{
    public UnityEvent FallDeath;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            FallDeath?.Invoke();
            GetComponent<Collider2D>().enabled = false;
        }
    }
}
