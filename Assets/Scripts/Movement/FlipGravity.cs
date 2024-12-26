using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipGravity : MonoBehaviour
{
    [SerializeField] GravityChanger gravityChanger;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gravityChanger.OnGravityFlip += Flip;
    }

    public void Flip()
    {
        rb.gravityScale *= -1;
    }
}
