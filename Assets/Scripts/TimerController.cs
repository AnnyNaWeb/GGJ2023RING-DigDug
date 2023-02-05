using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI tempo;
    private float totalTime;
    private int acabaTempo;
    // Start is called before the first frame update
    void Start()
    {
        acabaTempo = 0;
        totalTime = 10;
    }

    // Update is called once per frame
    public void Update()
    {
        totalTime -= Time.deltaTime;
        var rest =   totalTime - acabaTempo;
        float minutes = (int)(rest / 60);
        float seconds = (int)(rest % 60);
        tempo.text = minutes.ToString() + " : " + seconds.ToString();

        if(totalTime <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }
}
