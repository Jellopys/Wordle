using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GuessManager[] guessContainers;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject errorWindow;
    [SerializeField] private GameObject correctGuessContainer;
    [SerializeField] private WordList wordList;

    private List<KeyHandler> buttons = new List<KeyHandler>();
    private List<string> currentGuess = new List<string>();

    private string selectedString;
    private int currentRow;
    public int inputCount;
    private bool gameEnded;
    public string guessedWord;

    public string currentWord;

    void Awake()
    {
        currentRow = 0;
        currentWord = wordList.GetChosenWord();
        correctGuessContainer.GetComponent<GuessManager>().SetCorrectGuess(currentWord);
    }

    public void KeyInput(string input, KeyHandler button)
    {
        if (inputCount > 4 || gameEnded == true)
            return;

        buttons.Add(button);
        guessContainers[currentRow].InputString(input, inputCount);
        currentGuess.Add(input);
        inputCount++;
    }

    public void DecrementInput()
    {
        inputCount--;
        if (inputCount < 0)
        {
            inputCount = 0;
            return;
        }

        if (buttons.Count > 0) 
            buttons.RemoveAt(inputCount);
        
        currentGuess.RemoveAt(inputCount);
        guessContainers[currentRow].DecrementString(inputCount);
    }

    public void CheckSubmit()
    {
        if (inputCount < 5) return; // Check if 5 inputs are made
        if (!CheckWordExistInWordlist()) return; // Check if the word even exists
        
        int correctLetters = 0;

        for (int i = 0; i < 5; i++ )
        {
            if (!currentWord.ToLower().Contains(currentGuess[i].ToLower())) // Does the word contain the letter
            {
                buttons[i].ColorButton(false); // Color button darker
                guessContainers[currentRow].ColorMarkLetter(2, i);
                continue;
            }

            if (currentGuess[i].ToLower() == currentWord.Substring(i, 1).ToLower()) // Letter exist in the right order
            {
                guessContainers[currentRow].ColorMarkLetter(0, i);
                buttons[i].ColorButton(true); // Color button green
                correctLetters++;
                continue;
            }
            else // Letter exist but in the wrong order
            {
                guessContainers[currentRow].ColorMarkLetter(1, i); 
                buttons[i].ColorButton(true); // Color button green
                continue;
            }
        }

        if (correctLetters == 5) // WIN 
        {
            restartButton.SetActive(true);
            gameEnded = true;
        }

        CheckGameOver();
        NewRow();
    }

    private bool CheckWordExistInWordlist()
    {
        guessedWord = string.Join("", currentGuess);

        if (!wordList.CheckForWord(guessedWord.ToLower())) // Check if the word exists
        {
            if (!errorWindow.GetComponent<Animation>().isPlaying)
            {
                errorWindow.GetComponent<Animation>().Play();
            }
            return false;
        }
        return true;
    }

    private void NewRow()
    {
        inputCount = 0;
        currentGuess.Clear();
        buttons.Clear();
    }

    private void CheckGameOver()
    {
        currentRow++;
        if (currentRow < 6) return;
        // LOSE
        correctGuessContainer.SetActive(true);
        restartButton.SetActive(true);
        gameEnded = true;
    }
}
