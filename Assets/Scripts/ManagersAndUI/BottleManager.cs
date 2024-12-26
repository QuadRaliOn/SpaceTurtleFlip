using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BottleManager : MonoBehaviour
{
    [SerializeField] private int bottlesLeft = 4;

    public UnityEvent AllBottlesColleced;

    public void CollectBottle()
    {
        bottlesLeft-=1;
        if (bottlesLeft < 1)
        {
            AllBottlesColleced?.Invoke();
        }
    }
}
