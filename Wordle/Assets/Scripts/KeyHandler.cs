using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KeyHandler : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Button button;
    [SerializeField] private Image img;
    [SerializeField] private Color colorGreen;
    [SerializeField] private Color colorDark;

    public void KeyClicked(string key)
    {
        gameManager.KeyInput(key, this);
    }

    // public void ColorButtonDark()
    // {
    //     img.color = colorDark;
    // }

    public void ReEnableButton()
    {
        button.interactable = true;
    }

    public void DecrementGuess()
    {
        gameManager.DecrementInput();
    }

    public void SubmitGuess()
    {
        gameManager.CheckSubmit();
    }

    public void ColorButton(bool doesExist)
    {
        if (img == null)
            return;
        
        img.color = doesExist ? colorGreen : colorDark;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
