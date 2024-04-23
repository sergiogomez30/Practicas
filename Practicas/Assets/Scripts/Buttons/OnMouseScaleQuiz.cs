using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseScaleQuiz : MonoBehaviour
{
    [HideInInspector] public QuizManager scriptQuizManager;

    public void PointerEnter()
    {
        if (!scriptQuizManager.answered)
        {
            transform.localScale = new Vector2(1.1f, 1.1f);
        }
    }

    public void PointerExit()
    {
        if (!scriptQuizManager.answered)
        {
            transform.localScale = new Vector2(1f, 1f);
        }
    }
}
