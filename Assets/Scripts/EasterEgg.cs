using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public GameObject baobaAnny;

    public void Start()
    {
        baobaAnny.SetActive(false);
    }

    public void AnnyEasterEgg()
    {
        baobaAnny.SetActive(true);
    }
}
