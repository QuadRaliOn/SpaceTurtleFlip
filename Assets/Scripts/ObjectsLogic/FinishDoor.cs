using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishDoor : MonoBehaviour
{
    [SerializeField] GameObject SpriteOpened;
    [SerializeField] GameObject SpriteClosed;

    public UnityEvent LevelEnded;

    private bool isDoorOpened = false;

    public void OpenDoor()
    {
        SpriteClosed.SetActive(false);
        SpriteOpened.SetActive(true);
        isDoorOpened = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isDoorOpened)
            LevelEnded?.Invoke();
    }
}
