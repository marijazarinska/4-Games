using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scores : MonoBehaviour
{

    public Text scoreText;
    private int _currentScore;
    void Start()
    {
        _currentScore = 0;
        scoreText.text = _currentScore.ToString();
    }
    public void AddScore()
    {
        _currentScore += 5;
        scoreText.text = _currentScore.ToString();
    }

    public void DeductScore()
    {
        _currentScore = _currentScore > 0 ? _currentScore - 5 : 0; //ako e pogolem skoro od 0 a prasanje netocno namaluva se skoro
        scoreText.text = _currentScore.ToString(); 
    }
   
}
