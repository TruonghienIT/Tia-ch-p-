using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float thoiGianChoPhepVeDich = 30f;
    public bool ketThucGame = false;
    private static GameManager instance;
    public GameObject gameOverObject;
    public GameObject timeGameObject;
    [SerializeField] private float thoiGianKhiQuaCheckPoint = 30f;
    public GameObject gameWinObject;
    public bool winGame = false;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject gameManagerObject = new GameObject("GameObject");
                    instance = gameManagerObject.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }
    private void Update()
    {
        if (!ketThucGame)
        {
            thoiGianChoPhepVeDich -= Time.deltaTime;
            if (thoiGianChoPhepVeDich <= 0)
            {
                timeGameObject.SetActive(false);
                gameOverObject.SetActive(true);
                KetThucGame();
            }    
        }
        if (winGame)
        {
            timeGameObject.SetActive(false);
            gameWinObject.SetActive(true);
        }
    }
    public void KetThucGame()
    {
        ketThucGame = true;
    } 
    public void QuaCheckPoint()
    {
        if(!ketThucGame)
        {
            thoiGianChoPhepVeDich = thoiGianKhiQuaCheckPoint; 
        }
    }
    public void QuaCheckPointWin()
    {
        if (!ketThucGame)
        {
            winGame = true;
        }
    }
}
