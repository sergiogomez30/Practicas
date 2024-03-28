using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect;
    public QuizManager quizManager;

    private void Start()
    {
        isCorrect = false;
    }

    public void Answer()
    {
        if (isCorrect)
        {
            Debug.Log("Correct Answer");
            quizManager.Answered();
        }
        else
        {
            Debug.Log("Wrong Answer");
            quizManager.Answered();
        }
    }
}
