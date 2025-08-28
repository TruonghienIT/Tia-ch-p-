using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] private float tocDoXe = 100f;
    [SerializeField] private float lucReXe = 100f;
    [SerializeField] private float lucPhanh = 50f;

    [SerializeField] private GameObject hieuUngPhanhDuong;
    [SerializeField] private GameObject hieuUngPhanhCo;

    private float dauVaoDiChuyen;
    private float dauVaoRe;
    private Rigidbody rb;

    private string currentSurfaceTag = ""; // Tag của mặt đất đang va chạm

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        dauVaoDiChuyen = Input.GetAxis("Vertical");
        DiChuyenXe();

        dauVaoRe = Input.GetAxis("Horizontal");
        ReXe();

        if (Input.GetKey(KeyCode.Space) && dauVaoDiChuyen > 0)
        {
            PhanhXe();
        }
        else
        {
            // Nếu không phanh thì tắt hiệu ứng
            hieuUngPhanhDuong.SetActive(false);
            hieuUngPhanhCo.SetActive(false);
        }
    }

    public void DiChuyenXe()
    {
        rb.AddRelativeForce(Vector3.forward * dauVaoDiChuyen * tocDoXe);
    }

    public void ReXe()
    {
        Quaternion re = Quaternion.Euler(Vector3.up * dauVaoRe * lucReXe * Time.deltaTime);
        rb.MoveRotation(rb.rotation * re);
    }

    public void PhanhXe()
    {
        if (rb.velocity.magnitude > 0.1f)
        {
            rb.AddRelativeForce(-Vector3.forward * lucPhanh);

            // Bật hiệu ứng tương ứng với bề mặt
            if (currentSurfaceTag == "Ground")
            {
                hieuUngPhanhDuong.SetActive(true);
                hieuUngPhanhCo.SetActive(false);
            }
            else if (currentSurfaceTag == "Grass")
            {
                hieuUngPhanhDuong.SetActive(false);
                hieuUngPhanhCo.SetActive(true);
            }
            else
            {
                hieuUngPhanhDuong.SetActive(false);
                hieuUngPhanhCo.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Ghi nhận tag mặt đất hiện tại
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Grass"))
        {
            currentSurfaceTag = collision.gameObject.tag;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Rời khỏi mặt đất -> xóa tag hiện tại
        if (collision.gameObject.CompareTag(currentSurfaceTag))
        {
            currentSurfaceTag = "";
        }
    }
}
