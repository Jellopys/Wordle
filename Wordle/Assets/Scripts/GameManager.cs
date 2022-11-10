using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public string[] wordList;
    public string currentWord;

    [SerializeField] private GuessManager[] guessContainers;
    private List<KeyHandler> buttons = new List<KeyHandler>();

    private int currentString;
    public List<string> currentGuess = new List<string>();
    private string selectedString;

    private int currentContainer;

    void Awake()
    {
        currentContainer = 0;
        currentWord = wordList[Random.Range(0, wordList.Length - 1)];
        // TODO: Choose a word
    }

    public void KeyInput(string input, KeyHandler button)
    {
        if (currentString > 4)
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
        guessContainers[currentContainer].ShowResult();

        // TODO: Should not be able to check result if all 5 keys has not been input

        for (int i = 0; i < 5; i++ )
        {

            if (!currentWord.ToLower().Contains(currentGuess[i].ToLower())) // Does the word contain the letter
                continue;

            if (currentGuess[i].ToLower() == currentWord.Substring(i, 1).ToLower())
            {
                Debug.Log(currentGuess[i] + " exists in and is in the right order.");
                // TODO: Mark key green
            }
            else
            {
                Debug.Log(currentGuess[i] + " exists but in the wrong order.");
                // TODO: Mark key yellow
            }
        }

        // TODO: CHECK THE RESULT and compare to the chosen word

        // TODO: color the nodes
        // TODO: Go to next guess Row
        // TODO: Disable and enable the correct keys
    }
}
