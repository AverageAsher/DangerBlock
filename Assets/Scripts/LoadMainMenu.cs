using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainMenu : MonoBehaviour
{
    // Call this function from the button's OnClick event
    public void LoadGameScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}