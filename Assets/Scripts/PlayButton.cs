using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadGameScene2()
    {
        SceneManager.LoadScene("GameScene2");
    }

    public void LoadGameScene3()
    {
        SceneManager.LoadScene("GameScene3");
    }
}
