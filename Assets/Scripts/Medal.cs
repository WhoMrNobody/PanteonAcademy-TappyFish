using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    [SerializeField] Sprite _metalMedal, _bronzeMedal, _silverMedal, _goldMedal;
    Image _img;
    // Start is called before the first frame update
    void Start()
    {
        _img= GetComponent<Image>();

        int gameScore = GameManager.gameScore;

        if(gameScore > 0 && gameScore <= 1 )
        {
            _img.sprite = _metalMedal;
        }
        else if( gameScore > 1 && gameScore <= 2)
        {
            _img.sprite= _bronzeMedal;
        }
        else if( gameScore > 2 && gameScore <= 3 )
        {
            _img.sprite=_silverMedal;
        }
        else if(gameScore > 3)
        {
            _img.sprite = _goldMedal;
        }
    }

}
