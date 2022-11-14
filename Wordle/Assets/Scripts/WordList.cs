using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordList : MonoBehaviour
{
    [SerializeField] private TextAsset textFile;
    HashSet<string> wordList = new HashSet<string>();

    public bool CheckForWord(string word)
    {        
        return wordList.Contains(word);
    }

    public string GetChosenWord()
    {
        var content = textFile.text.Split("\r\n"); // return + newline

        foreach (string s in content)
        {
            wordList.Add(s.ToLower());
        }

        return content[Random.Range(0, content.Length)];
    }
}
