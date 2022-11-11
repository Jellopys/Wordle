using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyHandler : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Button button;
    [SerializeField] private Image img;
    [SerializeField] private Color colorGreen;

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

    public void SubmitGuess()
    {
        gameManager.CheckResult();
    }

    public void ColorButton()
    {
        if (img == null)
            return;
        
        img.color = colorGreen;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
