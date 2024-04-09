using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMouseScale : MonoBehaviour
{
    private QuizManager scriptQuizManager;

    private void Start()
    {
        scriptQuizManager = GameObject.Find("QuizManager").GetComponent<QuizManager>();
    }
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
