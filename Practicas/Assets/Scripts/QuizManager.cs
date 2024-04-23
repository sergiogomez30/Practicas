using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public List<StarQuestion> starQuestionList;
    public GameObject[] options;
    private int currentQuestion;

    public GameObject quizPanel;
    public GameObject resultsPanel;

    public TextMeshProUGUI questionTxt;
    public TextMeshProUGUI scoreTxt;

    private int numerOfQuestions;
    private int score;

    private float answerTimer;
    public float changeTimer;
    [HideInInspector] public bool answered;

    private int questionCounter;
    public int maxQuestions;

    private int starQuestionCounter;
    public int starMaxQuestions;

    private float finishedQuizTimer;
    public float changeQuizManagerTimer;
    [HideInInspector] public bool finishedQuiz;

    public GameManager scriptGameManager;

    private void Start()
    {
        numerOfQuestions = QnA.Count;
        questionCounter = 0;
        maxQuestions = 4;
        questionCounter = 0;
        starMaxQuestions = 2;
        answered = false;
        finishedQuiz = false;

        GenerateQuestion();
        
    }

    private void Update()
    {
        if (answered)
        {
            answerTimer += Time.deltaTime;
            if (answerTimer >= changeTimer)
            {
                if(questionCounter <= maxQuestions && QnA.Count > 0)
                {
                    GenerateQuestion();
                }
                else
                {
                    GenerateStarQuestion();
                }
            }
        }

        if (finishedQuiz)
        {
            finishedQuizTimer += Time.deltaTime;
            if(finishedQuizTimer >= changeQuizManagerTimer)
            {
                changeQuizManager();
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

    void SetStarAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].GetComponentInChildren<TextMeshProUGUI>().text = starQuestionList[currentQuestion].starAnswers[i];
            options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;
            options[i].GetComponent<Transform>().localScale = new Vector2(1f, 1f);

            if (starQuestionList[currentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    public void FinishedQuiz()
    {
        GenerateStarQuestion();
    }

    public void FinishedStarQuiz()
    {
        quizPanel.SetActive(false);
        resultsPanel.SetActive(true);
        scoreTxt.text = "Puntuacion:\n" + score + "/" + (maxQuestions + starMaxQuestions);
        finishedQuiz = true;
    }

    private void changeQuizManager()
    {
        scriptGameManager.removeQuizManager();
        resultsPanel.SetActive(false);
        gameObject.SetActive(false);
    }

    void GenerateQuestion()
    {
        questionCounter += 1;

        if (answered)
        {
            QnA.RemoveAt(currentQuestion);
            answered = false;
            answerTimer = 0;
        }
        
        if (questionCounter <= maxQuestions && QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            questionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            FinishedQuiz();
        }

    }

    void GenerateStarQuestion()
    {
        starQuestionCounter += 1;

        if (answered)
        {
            starQuestionList.RemoveAt(currentQuestion);
            answered = false;
            answerTimer = 0;
        }

        if (starQuestionCounter <= starMaxQuestions && starQuestionList.Count > 0)
        {
            currentQuestion = Random.Range(0, starQuestionList.Count);

            questionTxt.text = starQuestionList[currentQuestion].starQuestion;
            SetStarAnswers();
        }
        else
        {
            FinishedStarQuiz();
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
                if(questionCounter <= maxQuestions && QnA.Count > 0)
                {
                    if (QnA[currentQuestion].CorrectAnswer == i + 1)
                    {
                        options[i].GetComponent<Image>().color = Color.green;
                    }
                }
                else
                {
                    if (starQuestionList[currentQuestion].CorrectAnswer == i + 1)
                    {
                        options[i].GetComponent<Image>().color = Color.green;
                    }
                }
            }
        }
    }
}
