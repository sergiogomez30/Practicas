using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> listQuizManager;
    public GameObject[] buttons;
    
    [HideInInspector] public int activeQuizManager;

    private QuizManager scriptActualQuizManager;

    public GameObject levelPanel;
    public GameObject choicePanel;

    public TextMeshProUGUI levelTxt;
    private bool levelPanelActive;

    private int level;

    private float startLevelTimer;
    public float startLevelTime;

    void Start()
    {
        levelPanelActive = true;
        ChooseQuizManager();
    }

    void Update()
    {
        if (levelPanelActive)
        {
            startLevelTimer += Time.deltaTime;

            if (startLevelTimer >= startLevelTime)
            {
                levelPanel.SetActive(false);
                choicePanel.SetActive(true);
                levelPanelActive = false;
            }
        }
        
    }

    public void ChooseQuizManager()
    {
        activeQuizManager = Random.Range(0, listQuizManager.Count);
        print(activeQuizManager);
        listQuizManager[activeQuizManager].SetActive(true);
        scriptActualQuizManager = listQuizManager[activeQuizManager].GetComponent<QuizManager>();
        level++;

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].GetComponent<OnMouseScaleQuiz>().scriptQuizManager = scriptActualQuizManager;
            buttons[i].GetComponent<AnswerScript>().scriptQuizManager = scriptActualQuizManager;
        }

        StartNextLevel();
    }

    public void removeQuizManager()
    {
        listQuizManager.RemoveAt(activeQuizManager);
        ChooseQuizManager();
    }

    private void StartNextLevel()
    {
        levelPanel.SetActive(true);
        levelTxt.text = "Nivel " + level.ToString();
        startLevelTimer = 0;
        levelPanelActive = true;
    }
}
