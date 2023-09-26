using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using DG.Tweening;
using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] Image _fadeImage ;
    [SerializeField] float _fadeTime ;
    static SceneController instance;
    public static SceneController Instance =>instance;
    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public async void FadeAndNextScene(string nextSnene)
    {
        _fadeImage.gameObject.SetActive(true);
        await _fadeImage.DOFade(1, _fadeTime).SetEase(Ease.InSine);
        await SceneManager.LoadSceneAsync(nextSnene);
        await _fadeImage.DOFade(0, _fadeTime).SetEase(Ease.InSine);
        _fadeImage.gameObject.SetActive(false);
    }
}
