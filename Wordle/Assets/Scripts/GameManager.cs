using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GuessManager[] guessContainers;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private WordList wordListNew;
    private List<KeyHandler> buttons = new List<KeyHandler>();
    private List<string> currentGuess = new List<string>();
    private string selectedString;
    private int currentContainer;
    private int currentString;
    private bool hasWon;

    public string[] wordList;
    public string currentWord;

    void Awake()
    {
        currentContainer = 0;
        currentWord = wordList[Random.Range(0, wordList.Length)];
    }

    public void KeyInput(string input, KeyHandler button)
    {
        if (currentString > 4 || hasWon == true)
            return;

        buttons.Add(button);
        guessContainers[currentContainer].InputString(input, currentString);
        currentGuess.Add(input);
        currentString++;
    }

    public void DecrementGuess()
    {
        currentString--;

        if (currentString < 0)
        {
            currentString = 0;
            return;
        }

        currentGuess.RemoveAt(currentString);

        guessContainers[currentContainer].DecrementString(currentString);
        buttons[currentString].ReEnableButton();

        if (buttons.Count > 0)
        {
            buttons.RemoveAt(currentString);
        }
    }

    public void CheckResult()
    {
        if (currentString < 5)
        {
            // TODO: give feedback to player that you need to type in a whole word.
            return;
        }
        int correctLetters = 0;

        guessContainers[currentContainer].ShowResult();

        for (int i = 0; i < 5; i++ )
        {

            if (!currentWord.ToLower().Contains(currentGuess[i].ToLower())) // Does the word contain the letter
            {
                buttons[i].DisableButton();
                guessContainers[currentContainer].ColorMarkLetter(2, i);
                continue;
            }

            if (currentGuess[i].ToLower() == currentWord.Substring(i, 1).ToLower()) // Letter exist in the right order
            {
                guessContainers[currentContainer].ColorMarkLetter(0, i);
                buttons[i].ColorButton();
                correctLetters++;
                continue;
            }
            else // Letter exist but in the wrong order
            {
                guessContainers[currentContainer].ColorMarkLetter(1, i); 
                buttons[i].ColorButton();
                continue;
            }
        }

        if (correctLetters == 5)
        {
            restartButton.SetActive(true);
            Debug.Log("win");
            hasWon = true;
        }

        currentContainer++;
        currentString = 0;
        currentGuess.Clear();
        buttons.Clear();
    }
}
