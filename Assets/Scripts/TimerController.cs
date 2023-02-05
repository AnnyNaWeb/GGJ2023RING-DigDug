using System;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI tempo;
    private float totalTime;
    private int acabaTempo;
    // Start is called before the first frame update
    void Start()
    {
        acabaTempo = 0;
        totalTime = 40;
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        var rest =   totalTime - acabaTempo;
        float minutes = (int)(rest / 60);
        float seconds = (int)(rest % 60);
        tempo.text = minutes.ToString() + " : " + seconds.ToString();
    }
}
