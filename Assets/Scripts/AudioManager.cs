using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip menuMusic;
    public AudioClip gameMusic;

    AudioSource audioSource;

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
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            PlayMusic(menuMusic);
        }
        else
        {
            PlayMusic(gameMusic);
        }
    }

    void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip == clip)
            return;

        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }

    void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
