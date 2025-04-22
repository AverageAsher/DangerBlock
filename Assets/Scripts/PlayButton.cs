using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Call this function from the button's OnClick event
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}
