using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XuLyVaCham : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CheckPoint")
        {
            GameManager.Instance.QuaCheckPoint();
        }
        if(other.gameObject.tag == "CheckPointWin")
        {
            GameManager.Instance.QuaCheckPointWin();
        }
    }
}
