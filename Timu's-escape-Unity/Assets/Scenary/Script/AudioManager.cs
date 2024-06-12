using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    public AudioClip musicClip;
    public float waitTime = 0.8f; // Wait for 0.5 seconds
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
}
    