using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuessManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] strings;

    private int currentString;
    private List<string> currentGuess = new List<string>();
    private string selectedString;

    private void Awake()
    {
        currentString = 0;
    }

    public void InputString(string input, int position)
    {
        strings[position].text = input;
    }

    public void DecrementString(int position)
    {
        strings[position].text = "";
    }

    public bool CanAddKeyInput()
    {
        return currentString < strings.Length;
    }

    public int GetCurrentString()
    {
        return currentString;
    }

    public void ShowResult()
    {
        int i = 0;
        foreach(string s in currentGuess)
        {
            Debug.Log(currentGuess[i]);
            i++;
        };
    }
}
