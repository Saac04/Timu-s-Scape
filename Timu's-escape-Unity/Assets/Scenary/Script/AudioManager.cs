using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource pauseMusicSource;
    [SerializeField] AudioMixer audioMixer; // Public AudioMixer
    public AudioClip musicClip;
    public AudioClip pauseMusic;

    public float waitTime = 0.8f; // Wait for 0.8 seconds
    public float targetVolume = 1.0f; // Target volume level
    public float fadeDuration = 3.0f; // Time in seconds to reach the target volume

    private float initialVolume;
    private float fadeSpeed;
    private Coroutine fadeCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        if (musicSource == null || musicClip == null)
        {
            Debug.LogError("AudioManager: MusicSource or MusicClip is not assigned.");
            return;
        }

        initialVolume = musicSource.volume;
        fadeSpeed = (targetVolume - initialVolume) / fadeDuration;

        StartWaiting();
    }

    void StartWaiting()
    {
        fadeCoroutine = StartCoroutine(WaitBeforePlayingMusic());
    }

    IEnumerator WaitBeforePlayingMusic()
    {
        yield return new WaitForSecondsRealtime(waitTime);
        PlayMusic();
    }

    void PlayMusic()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
        fadeCoroutine = StartCoroutine(FadeInMusic());
    }

    IEnumerator FadeInMusic()
    {
        while (musicSource.volume < targetVolume)
        {
            musicSource.volume += fadeSpeed * Time.deltaTime;
            // Ensure volume does not exceed targetVolume
            musicSource.volume = Mathf.Min(musicSource.volume, targetVolume);
            yield return null;
        }
    }

    // Ensure coroutine stops if AudioManager is disabled or destroyed
    void OnDisable()
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);
    }

    void OnDestroy()
    {
        if (fadeCoroutine != null)
            StopCoroutine(fadeCoroutine);
    }

    // Play the pause music and stop the current music
    public void PlayPauseMusic()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
            fadeCoroutine = null;
        }

        musicSource.Stop();
        audioMixer.SetFloat("lava", -80f); // Effectively mute
        pauseMusicSource.clip = pauseMusic;
        pauseMusicSource.Play();
    }

    // Resume the original music and stop the pause music
    public void ResumeMusic()
    {
        if (fadeCoroutine != null)
        {
            StopCoroutine(fadeCoroutine);
            fadeCoroutine = null;
        }

        pauseMusicSource.Stop();
        PlayMusic();
                audioMixer.SetFloat("lava", -34f); // Effectively mute
    }

    // AudioMixer Methods
    public void SetMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
    }

    public void MuteMasterVolume(bool mute)
    {
        if (mute)
            audioMixer.SetFloat("MasterVolume", -80f); // Effectively mute
        else
            audioMixer.SetFloat("MasterVolume", Mathf.Log10(targetVolume) * 20);
    }

    public void MuteMusicVolume(bool mute)
    {
        if (mute)
            audioMixer.SetFloat("lava", -80f); // Effectively mute
        else
            audioMixer.SetFloat("MusicVolume", Mathf.Log10(targetVolume) * 20);
    }

    public void MuteSFXVolume(bool mute)
    {
        if (mute)
            audioMixer.SetFloat("SFXVolume", -80f); // Effectively mute
        else
            audioMixer.SetFloat("SFXVolume", Mathf.Log10(targetVolume) * 20);
    }
}
