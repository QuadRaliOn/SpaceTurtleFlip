using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject CollideWith { get; set; }
    public List<GameObject> CollideWiths;

    public void Awake()
    {
        CollideWiths = new List<GameObject>();
        CollideWith = null;    
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        CollideWith = collision.gameObject;
        CollideWiths.Add(collision.gameObject);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CollideWith = null;
        CollideWiths.Remove(collision.gameObject);
    }
}
