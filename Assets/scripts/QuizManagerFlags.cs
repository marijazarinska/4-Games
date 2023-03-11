using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuizManagerFlags : MonoBehaviour
{
    public List<QuestionsAndAnswersFlags> QnA;
    public GameObject[] options;
    public int CurrentQuestion;

    public GameObject Quizpanel;
    public GameObject GoPanel;

    public Text QuestionTxt;
    public Text ScoreTxt;

    int totalQuestions = 0;
    public int score;

    private void Start()
    {
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        generateQuestion();

    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    void GameOver()
    {
        Quizpanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreTxt.text =  score + "/" + totalQuestions;
    }

    public void correct()
    {
        score += 1;
        QnA.RemoveAt(CurrentQuestion);
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
   
            for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Image>().sprite = QnA[CurrentQuestion].Answers[i];
            if (QnA[CurrentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
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
