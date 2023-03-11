using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionsData : MonoBehaviour
{
   //varijabli
    public Questions questions;
    [SerializeField] private Text _questiontext;
    
    void Start()
    {
     
        AskQuestion();
    }
    

    //postavuva se random prasanje 
    public void AskQuestion()
    {
        if (CountValidQuestions() == 0)   //ako nemame dostapni prasanja vrakjame se na glavnoto meni, pocetoko na igrata
        {
            _questiontext.text = string.Empty;
            ClearQuestion();
            SceneManager.LoadScene("MainMenu");
            return;
        }
        var randomIndex = 0;
        do
        {
            randomIndex = UnityEngine.Random.Range(0, questions.questionsList.Count); //prikazuvat se prasanja se dodeka ima, t.e random index e ednakvo na brojot na prasanjata
        } while (questions.questionsList[randomIndex].questioned == true); //selektira random prasanje so ne e pominalo, ne e odgovarano, mine gi site prasanja

        questions.currentQuestion = randomIndex;  //prasanjeto so se prikazuva 
        questions.questionsList[questions.currentQuestion].questioned = true; //ukazuvame na prasanjeto so veke e postaveno
        _questiontext.text = questions.questionsList[questions.currentQuestion].question;
    }

    public void ClearQuestion()  //vrtenje na site prasanja
    {
        foreach (var question in questions.questionsList)
        {
            question.questioned = false;
        }
    }


    //broe gi site prasanja so se uste ne se postaveni
    private int CountValidQuestions()
    {
        int validQuestions = 0;

        foreach (var question in questions.questionsList)  //mineme niz site prasanja 
        {
            if (question.questioned == false) //ako ne e postaveno prasanjeto 
                validQuestions++;

        }
        Debug.Log(message: "Questions left: " + validQuestions);  //pokazuva ni kolku prasanja ostanuvat
        return validQuestions;
    }

    
}
    

