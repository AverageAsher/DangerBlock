using UnityEngine;
using UnityEngine.UI;

public class PlaySoundOnClick : MonoBehaviour
{
    public AudioClip clickSound;

    void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(PlayClickSound);
        }
    }

    void PlayClickSound()
    {
        AudioManager.Instance?.PlaySound(clickSound);
    }
}
