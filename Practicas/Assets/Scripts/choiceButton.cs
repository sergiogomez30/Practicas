using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class choiceButton : MonoBehaviour
{
    public GameObject choicePanel;
    public GameObject QuizPanel;

    public void playerChosen()
    {
        choicePanel.SetActive(false);
        QuizPanel.SetActive(true);
    }
}
