using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//atributi
[CreateAssetMenu]
[System.Serializable]
public class Questions : ScriptableObject
{
    [System.Serializable]
    public class QuestionData   //sodrze poveke polinja
    {
        public string question = string.Empty;
        public bool isTrue = false;
        public bool questioned = false; //ne dozvoluva dve prasanja da se povtorat
    }

    public int currentQuestion = 0;
    public List<QuestionData> questionsList;

    public void AddQuestion()
    {
        questionsList.Add(item: new QuestionData());
    }
}
