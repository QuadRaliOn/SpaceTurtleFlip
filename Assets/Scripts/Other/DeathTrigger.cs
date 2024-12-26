using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DeathTrigger : MonoBehaviour
{
    public UnityEvent Death;

    [SerializeField] bool IsUpperTrigger;
    [SerializeField] GravityChanger gravityChanger;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Moveable") 
            && ((IsUpperTrigger && gravityChanger.IsNormalGravity)
            || (!IsUpperTrigger && !gravityChanger.IsNormalGravity)))
        {
            Death?.Invoke();
        }    
    }
}
