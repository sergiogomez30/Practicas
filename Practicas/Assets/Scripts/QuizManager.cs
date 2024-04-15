using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    private int currentQuestion;

    public GameObject quizPanel;
    public GameObject resultsPanel;

    public TextMeshProUGUI questionTxt;
    public TextMeshProUGUI scoreTxt;

    private int numerOfQuestions;
    private int score;

    private float timer;
    public float changeTimer;
    [HideInInspector] public bool answered;

    private int questionCounter;
    public int maxQuestions;

    private void Start()
    {
        numerOfQuestions = QnA.Count;
        questionCounter = 0;
        maxQuestions = 3;
        answered = false;

        GenerateQuestion();
        
    }

    private void Update()
    {
        if (answered)
        {
            timer += Time.deltaTime;
            if (timer >= changeTimer)
            {
                GenerateQuestion();
            }
        }
    }

    void SetAnswers()
    {
        for(int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<Transform>().localScale = new Vector2(1f, 1f);

            if (QnA[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
                //print(options[i].GetComponentInChildren<TextMeshProUGUI>().text);
            }
        }
    }

    public void FinishedQuiz()
    {
        quizPanel.SetActive(false);
        resultsPanel.SetActive(true);
        scoreTxt.text = score + "/" + maxQuestions;
    }

    void GenerateQuestion()
    {
        questionCounter += 1;

        if (answered)
        {
            QnA.RemoveAt(currentQuestion);
            answered = false;
            timer = 0;
        }
        
        if (questionCounter <= maxQuestions && QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            questionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            //Debug.Log("Out of Questions");
            FinishedQuiz();
        }

    }

    public void Answered(string result)
    {
        answered = true;

        if (result == "correct")
        {
            score += 1;
        }
        else
        {
            for (int i = 0; i < options.Length; i++)
            {
                if (QnA[currentQuestion].CorrectAnswer == i + 1)
                {
                    options[i].GetComponent<Image>().color = Color.green;
                }
            }
        }
    }
}
