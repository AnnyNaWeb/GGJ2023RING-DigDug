using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float fadeOutTime = 1f;
    private CanvasGroup canvasGroup;

    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Update()
    {
        if (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / fadeOutTime;
        }
        else
        {
            // Aqui você pode adicionar ações adicionais a serem executadas após o fade out ser concluído
        }
    }
}
