using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    private AudioSource soundSource;
    private AudioSource musicSource;

    [Header("Music Source")]
    [SerializeField] private AudioClip menuMusic;
    [SerializeField] private AudioClip gameMusic;
    private void Awake()
    {
        soundSource = GetComponent<AudioSource>();
        musicSource = transform.GetChild(0).GetComponent<AudioSource>();

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        //Xóa trùng lặp
        else if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        LoadVolumes();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name.Contains("Menu"))
        {
            PlayMenuMusic();
        }
        else if(scene.name.Contains("Game"))
        {
            PlayGameMusic();
        }
    }    
    public void PlaySound(AudioClip _sound)
    {
        soundSource.PlayOneShot(_sound);
    }
    public void ChangeSoundVolume(float _change)
    {
        ChangeSourceVolume(1, "soundVolume", _change, soundSource);
    }
    private void ChangeSourceVolume(float baseVolume, string volumeName, float change, AudioSource audioSource)
    {
        float currentVolume = PlayerPrefs.GetFloat(volumeName, 1);
        currentVolume += change;
        if (currentVolume > 1)
        {
            currentVolume = 0;
        }
        else if (currentVolume < 0)
        {
            currentVolume = 1;
        }
        float finalVolume = currentVolume * baseVolume;
        audioSource.volume = finalVolume;

        PlayerPrefs.SetFloat(volumeName, currentVolume);
    }
    public void ChangeMusicVolume(float _change)
    {
        ChangeSourceVolume(0.3f, "musicVolume", _change, musicSource);
    }
    private void LoadVolumes()
    {
        float soundVolume = PlayerPrefs.GetFloat("soundVolume", 1);
        float musicVolume = PlayerPrefs.GetFloat("musicVolume", 1);

        soundSource.volume = soundVolume * 1f;   
        musicSource.volume = musicVolume * 0.3f;
    }    
    public void PlayMenuMusic()
    {
        if(musicSource != menuMusic)
        {
            musicSource.clip = menuMusic;
            musicSource.loop = true;
            musicSource.Play();
        }    
    }
    public void PlayGameMusic()
    {
        if(musicSource != gameMusic)
        {
            musicSource.clip = gameMusic;
            musicSource.loop = true;
            musicSource.Play();
        }    
    }
}
