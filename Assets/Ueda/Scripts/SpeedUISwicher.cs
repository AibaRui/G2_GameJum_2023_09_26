using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedUISwicher : MonoBehaviour
{
    [SerializeField] List<Sprite> _sprites;
    Image _myImage;
    private void Awake()
    {
        _myImage = GetComponent<Image>();
        //print(this.gameObject.name);
    }
    public void ChangeSprite(int index)
    {
        
        _myImage.sprite = _sprites[index];
    }
}
