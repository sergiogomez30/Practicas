using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulesReaden : MonoBehaviour
{
    public GameObject instruccionsPanel;
    public GameObject choicePanel;

    public void startQuiz()
    {
        instruccionsPanel.SetActive(false);
        choicePanel.SetActive(true);
    }
}
