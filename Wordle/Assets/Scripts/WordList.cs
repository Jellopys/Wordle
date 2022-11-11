using System.Collections.Generic;
using UnityEngine;

public class WordList : MonoBehaviour
{
    [SerializeField] private TextAsset textFile;

    private string chosenWord;
    HashSet<string> wordList;

    public bool CheckForWord(string word)
    {
        return wordList.Contains(word);
    }

    public string GetChosenWord() => chosenWord;

    private void Awake()
    {
        ChooseWord();
    }

    private void ChooseWord()
    {
        var content = textFile.text.Split("\n");
        chosenWord = content[Random.Range(0, content.Length)];
    }
}
