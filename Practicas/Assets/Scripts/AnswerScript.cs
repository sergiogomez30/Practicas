using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    [HideInInspector] public bool isCorrect;
    public QuizManager quizManager;

    public Color startColor;

    private void Start()
    {
        //startColor = GetComponent<Image>().color;
    }

    public void Answer()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            //Debug.Log("Correct Answer");
            quizManager.Answered("correct");
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            //Debug.Log("Wrong Answer");
            quizManager.Answered("incorrect");
        }

    }
}


















/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    [HideInInspector] public bool isCorrect;
    public QuizManager quizManager;

    public Color startColor;

    public float timer;
    public float changeTimer;

    private bool answered;

    private void Start()
    {
        timer = 0;
        changeTimer = 5;
        answered = false;
        startColor = GetComponent<Image>().color;
    }

    private void Update()
    {
        AnswerColor();
    }

    public void AnswerColor()
    {
        answered = true;

        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;
            Debug.Log("Correct Answer");
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            Debug.Log("Wrong Answer");

        }
    }

    public void Answer()
    {
        if (answered)
        {
            timer += Time.deltaTime;
        }

        if (timer >= changeTimer)
        {
            if (isCorrect)
            {
                quizManager.Answered("correct");
            }
            else quizManager.Answered("incorrect");

            timer = 0;
            answered = false;
            RestartButtonColor();
        }

    }

    public void RestartButtonColor()
    {
        GetComponent<Image>().color = startColor;
    }

}*/

