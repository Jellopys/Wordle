using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GuessManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] strings;
    [SerializeField] private Image[] colorBox;

    [SerializeField] private Color colorGreen;
    [SerializeField] private Color colorYellow;
    [SerializeField] private Color colorDark;
    [SerializeField] private Color[] boxColors;

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
        colorBox[position].GetComponent<Animation>().Play();
    }

    public void DecrementString(int position)
    {
        strings[position].text = "";
        colorBox[position].GetComponent<Animation>().Play();
    }

    public bool CanAddKeyInput()
    {
        return currentString < strings.Length;
    }

    public int GetCurrentString()
    {
        return currentString;
    }

    public void ColorMarkLetter(int color, int i) // 0 = GREEN, 1 = YELLOW, 2 = DARK
    {
        colorBox[i].color = boxColors[color];

        // TODO: ANIMATION ON THE BOX
    }

    public void SetCorrectGuess(string s)
    {
        for (int i = 0; i < 5; i++)
        {
            strings[i].text = s.Substring(i,1).ToUpper();
        }
    }
}
