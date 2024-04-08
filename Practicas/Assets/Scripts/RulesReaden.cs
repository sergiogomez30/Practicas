using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesReaden : MonoBehaviour
{
    public GameObject instruccionsPanel;
    public GameObject QuizPanel;

    public void startQuiz()
    {
        instruccionsPanel.SetActive(false);
        QuizPanel.SetActive(true);
    }
}
