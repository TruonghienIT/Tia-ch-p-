using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject menuGameUi;
    [SerializeField] private GameObject setttingVolumeUi;
    private int currentIndex = 0;

    void Start()
    {
        menuGameUi.SetActive(true);
        setttingVolumeUi.SetActive(false);
        HighlightButton(currentIndex);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            currentIndex++;
            if (currentIndex >= buttons.Length) currentIndex = 0;
            HighlightButton(currentIndex);
        }

                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            currentIndex--;
            if (currentIndex < 0) currentIndex = buttons.Length - 1;
            HighlightButton(currentIndex);
        }

        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Space))
        {
            buttons[currentIndex].onClick.Invoke();
        }
    }
    void HighlightButton(int index)
    {
        buttons[index].Select();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void OptionCar()
    {
        SceneManager.LoadScene("OptionCar");
    }
    public void QuitGame()
    {
        Application.Quit(); 
    }
    public void SettingVolume()
    {
        menuGameUi.SetActive(false);
        setttingVolumeUi.SetActive(true);
    }    
    public void SoundVolume()
    {
        SoundManager.instance.ChangeSoundVolume(0.2f);
    }    
    public void MusicVolume()
    {
        SoundManager.instance.ChangeMusicVolume(0.2f);
    }    
    public void ExitSettingVolume()
    {
        menuGameUi.SetActive(true);
        setttingVolumeUi.SetActive(false);
    }    
}
