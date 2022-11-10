using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyHandler : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Button button;

    public void KeyClicked(string key)
    {
        gameManager.KeyInput(key, this);
    }

    public void DisableButton()
    {
        button.interactable = false;
    }

    public void ReEnableButton()
    {
        button.interactable = true;
    }

    public void DecrementGuess()
    {
        gameManager.DecrementGuess();
    }

    public void ShowResult()
    {
        gameManager.ShowResult();
    }
}
