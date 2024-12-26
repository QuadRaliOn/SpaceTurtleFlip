using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GravityChanger : MonoBehaviour
{
    [SerializeField] private float ReloadTime;

    public event Action OnGravityFlip;
    public UnityEvent OnGravityChange;
    public bool IsNormalGravity = true;
    private Rigidbody2D player;

    private void Awake()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject.GetComponent<Rigidbody2D>();    
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(player.velocity.y) < 0.1f) 
        {
            IsNormalGravity = !IsNormalGravity;
            OnGravityFlip();
            OnGravityChange?.Invoke();
        }
    }
}
