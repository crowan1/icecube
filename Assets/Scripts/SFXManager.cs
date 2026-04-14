using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager instance;

    public AudioClip[] wallHitLow;
    public AudioClip[] wallHitMedium;
    public AudioClip[] wallHitHigh;
    public AudioClip[] gemCollectLow;
    public AudioClip[] gemCollectMedium;
    public AudioClip[] gemCollectHigh;
    public AudioClip[] victorySounds;
    public AudioClip[] finalVictorySounds;
    public AudioClip[] deathSounds;

    AudioSource audioSource;
    bool isMuted = false;

    public bool IsMuted() { return isMuted; }

    public void ToggleSFX()
    {
        isMuted = !isMuted;
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        audioSource = GetComponent<AudioSource>();
    }

    public void PlayWallHit()
    {
        int r = Random.Range(0, 3);
        if (r == 0) PlayRandom(wallHitLow);
        else if (r == 1) PlayRandom(wallHitMedium);
        else PlayRandom(wallHitHigh);
    }

    public void PlayGemCollect(int collected, int total)
    {
        float ratio = (float)collected / total;

        if (ratio <= 0.33f)
            PlayRandom(gemCollectLow);
        else if (ratio <= 0.66f)
            PlayRandom(gemCollectMedium);
        else
            PlayRandom(gemCollectHigh);
    }

    public void PlayVictory()
    {
        PlayRandom(victorySounds);
    }

    public void PlayFinalVictory()
    {
        PlayRandom(finalVictorySounds);
    }

    public void PlayDeath()
    {
        PlayRandom(deathSounds);
    }

    void PlayRandom(AudioClip[] clips)
    {
        if (isMuted || clips.Length == 0) return;
        AudioClip clip = clips[Random.Range(0, clips.Length)];
        audioSource.PlayOneShot(clip);
    }
}
