using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button2 : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] public Image fadeImage;
    public float fadeDuration = 2.0f;
    //[SerializeField] Button button;
    [SerializeField] Button button2;
    [SerializeField] AudioSource _audio;
    int count = 0;
    private void Start()
    {
        count++;
        if(count != 1)canvas.enabled = true;
        //button.onClick.AddListener(OnButtonClick);
        button2.onClick.AddListener(OnButtonClick2);
    }
    //private void OnButtonClick()
    //{
    //    _audio.Play();
    //    StartCoroutine(ToTitleScene());
    //}
    private void OnButtonClick2()
    {
        _audio.Play();
        StartCoroutine(ToGameScene());
    }
    //private IEnumerator ToTitleScene()
    //{
    //    float timer = 0;//フェードアウトさせる
    //    while (timer < fadeDuration)
    //    {
    //        float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
    //        fadeImage.color = new Color(0, 0, 0, alpha);
    //        timer += Time.deltaTime;
    //        yield return null;
    //    }

    //    SceneManager.LoadScene("Title");
    //}
    private IEnumerator ToGameScene()
    {
        float timer = 0;
        while (timer < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
            fadeImage.color = new Color(0, 0, 0, alpha);
            timer += Time.deltaTime;
            yield return null;
        }
        canvas.enabled = false;
        SceneManager.LoadScene("InGameTest");
    }

}
