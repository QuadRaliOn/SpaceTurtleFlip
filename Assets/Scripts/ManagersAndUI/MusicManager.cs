using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioSource OST;
    [SerializeField] private AudioSource bottleCollected;
    [SerializeField] private AudioSource bottleDestroyed;
    [SerializeField] private AudioSource changeGravity;
    [SerializeField] private AudioSource deathByFallOf;
    [SerializeField] private AudioSource deathByBox;

    private void Awake()
    {
        OST.Play();
    }

    public void CollectBottle()
    {
        bottleCollected.pitch = Random.Range(0.85f, 1.15f);
        bottleCollected.Play();
    }

    public void DestroyBottle()
    {
        bottleDestroyed.pitch = Random.Range(0.85f, 1.15f); 
        bottleDestroyed.Play();
    }

    public void ChangeGravity()
    {
        changeGravity.pitch = Random.Range(0.85f, 1.15f);
        changeGravity.Play();
    }

    public void DeathByFallOf()
    {
        deathByFallOf.pitch = Random.Range(0.85f, 1.15f);
        deathByFallOf.Play();
    }

    public void DeathByBox()
    {
        deathByBox.pitch = Random.Range(0.85f, 1.15f);
        deathByBox.Play();
    }
}
