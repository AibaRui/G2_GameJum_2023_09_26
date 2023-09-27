using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUISwicher : MonoBehaviour
{
    [SerializeField] Sprite[] _sprites;
    Image _myImage;
    private void Awake()
    {
        _myImage = GetComponent<Image>();
    }
    public void ChangeSprite(int index)
    {
        _myImage.sprite = _sprites[index];
    }
}
