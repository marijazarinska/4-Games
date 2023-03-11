using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Result : MonoBehaviour
{

    public Questions questions;
    public GameObject correctSprite;
    public GameObject incorrectSprite;

    public Scores scores;

    public Button trueButton;
    public Button falseButton;

    public UnityEvent onNextQuestion;

    void Start()
    {
        correctSprite.SetActive(false);
        incorrectSprite.SetActive(false);
    }

    public void ShowResult(bool answer)
    {
        correctSprite.SetActive(questions.questionsList[questions.currentQuestion].isTrue == answer);// ako momentalnoto prasanje e tocno aktivira se correctSprite
        incorrectSprite.SetActive(questions.questionsList[questions.currentQuestion].isTrue != answer); //ako e netocno se aktivira incorrectSprite


        //od skriptata scores, istanca kon funkciite
        if(questions.questionsList[questions.currentQuestion].isTrue == answer)  //ako e tocno prasanjeto povikuvame ja addscore
        {
            scores.AddScore();
        }
        else  //ako ne e tocno DeductScore
        {
            scores.DeductScore();
        }

        //koga ke se prikaze rezultato se prekinuva/ zapira interakcijata  na kopcinjata
        trueButton.interactable = false;
        falseButton.interactable = false;

        StartCoroutine(ShowResult());
    }

    private IEnumerator ShowResult()
    {
        yield return new WaitForSeconds(1.0f); // da se prikaze 1 sekunda tocno/netocno

        correctSprite.SetActive(false);   //posle taa edna sekunda se deaktivirat correct i incorrect Sprite
        incorrectSprite.SetActive(false);

        trueButton.interactable = true; //kopcinjata se aktivirat
        falseButton.interactable = true;

        //poikuvame ja funkcijata onNextQuestion
        onNextQuestion.Invoke();
    }

    
}
