using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameUi : MonoBehaviour
{
    public TextMeshProUGUI textTime;
    private void Update()
    {
        HienThiThoiGianGame();
    }
    public void HienThiThoiGianGame()
    {
        textTime.SetText(Mathf.FloorToInt(GameManager.Instance.thoiGianChoPhepVeDich).ToString());
    }
    public void ChoiLai()
    {
        SceneManager.LoadScene("Game");
    }
    public void VeMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
