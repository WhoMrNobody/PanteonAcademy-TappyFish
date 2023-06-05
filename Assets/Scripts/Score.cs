using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TMP_Text _panelScore;
    [SerializeField] TMP_Text _panelHighScore;
    [SerializeField] GameObject _newRecord;
    int _score;
    int _highScore;
    TMP_Text _scoreTextMeshPro;

    // Start is called before the first frame update
    void Start()
    {
        _score = 0;
        _scoreTextMeshPro= GetComponent<TMP_Text>();
        _scoreTextMeshPro.text = _score.ToString();
        _panelHighScore.text = _score.ToString();

        _highScore = PlayerPrefs.GetInt("highscore");
        _panelHighScore.text = _highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scored()
    {
        _score++;
        _scoreTextMeshPro.text = _score.ToString();
        _panelHighScore.text = _score.ToString();

        if (_score > _highScore)
        {
            _highScore= _score;
            _panelHighScore.text = _highScore.ToString();
            PlayerPrefs.SetInt("highscore", _highScore);
            _newRecord.SetActive(true);
        }
    }

    public int GetScore()
    {
        return _score;
    }
}
