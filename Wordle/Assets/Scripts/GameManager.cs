using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GuessManager[] guessContainers;
    private List<KeyHandler> buttons = new List<KeyHandler>();

    private int currentString;
    private List<string> currentGuess = new List<string>();
    private string selectedString;

    private int currentContainer;

    void Start()
    {
        currentContainer = 0;
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

        guessContainers[currentContainer].DecrementString(currentString);
        buttons[currentString].ReEnableButton();

        if (buttons.Count > 0)
        {
            buttons.RemoveAt(currentString);
        }
    }

    public void ShowResult()
    {
        guessContainers[currentContainer].ShowResult();
    }
}
