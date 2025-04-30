using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;
    private AudioSource audioSource;

    void Start()
    {
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f); // default to 0.5
        SetVolume(savedVolume);
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume); // Save volume
    }

    public float GetVolume()
    {
        return audioSource.volume;
    }
}
