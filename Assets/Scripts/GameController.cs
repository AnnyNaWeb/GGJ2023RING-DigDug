using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public  GameObject timer;
    
    
    public void Start()
    {
        timer.SetActive(false);
    }

    public void Update()
    {
        if(PlayerControllerBackUp.caiu)
        {
            timer.SetActive(true);
        }
    }
}
