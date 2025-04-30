public static class AudioSettingsManager
{
    public static float SFXVolume
    {
        get => UnityEngine.PlayerPrefs.GetFloat("SFXVolume", 1f); // Default to full volume
        set
        {
            UnityEngine.PlayerPrefs.SetFloat("SFXVolume", value);
            UnityEngine.PlayerPrefs.Save();
        }
    }
}
