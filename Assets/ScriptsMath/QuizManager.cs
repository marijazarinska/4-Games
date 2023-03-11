using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int CurrentQuestion;

    public GameObject Quizpanel;
    public GameObject GOPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions = 0;
    public int score;

    private void Start ()
    {
        totalQuestions = QnA.Count;
        GOPanel.SetActive(false);
        generateQuestion();

    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

     void GameOver()
    {
        Quizpanel.SetActive(false);
        GOPanel.SetActive(true);
        ScoreTxt.text = score + "/" + totalQuestions;
    }


    public void correct()
    {
        score += 1;
        QnA.RemoveAt(CurrentQuestion);
        //generateQuestion();

        StartCoroutine(waitForNext());
    }

    public void wrong()
    {
        QnA.RemoveAt(CurrentQuestion);
        StartCoroutine(waitForNext());
    }
   
    IEnumerator waitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
       
    }

    void SetAnswers()
    {

        for (int i=0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswersScript>().startColor;
            options[i].GetComponent<AnswersScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[CurrentQuestion].Answers[i];
            if (QnA[CurrentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswersScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        

        if (QnA.Count > 0)
        {
            CurrentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[CurrentQuestion].Questions;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }

        
    }

}
