using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip soundToPlay;
    private AudioSource audioSource;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
    public void LoadStart()
    {

        StartSound();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(0);
    }
   public void Quit()
    {
        Application.Quit();
        
    }

    public void StartSound()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = soundToPlay;
        audioSource.Play();
        StartCoroutine(WaitForSoundToFinish());
    }

    private IEnumerator WaitForSoundToFinish()
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }

        StartGame();
    }

    public void StartAgain()
    {
        SceneManager.LoadScene(1);
    }


}
