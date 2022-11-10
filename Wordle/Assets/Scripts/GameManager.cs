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
            for (int j = 0; j < 5; j++)
            {
                Debug.Log("Checking each substring of the Word");
                if (currentGuess[i].ToLower() == currentWord.Substring(j, 1).ToLower())
                {
                    // TODO: Mark key green
                    Debug.Log(currentGuess[i] + " exists in the word and is in the right place.");
                }
                else if (currentWord.ToLower().Contains(currentGuess[i].ToLower()))
                {
                    // TODO: Mark key yellow
                    Debug.Log(currentGuess[i] + " exists in the word but is in the wrong place.");
                }
            }
        }

        // TODO: CHECK THE RESULT and compare to the chosen word

        // TODO: color the nodes
        // TODO: Go to next guess Row
        // TODO: Disable and enable the correct keys
    }
}
