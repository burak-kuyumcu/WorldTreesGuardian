using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;

    private float currentZoom = 10f;

    public float minZoom = 7f;
    public float maxZoom = 18f;
    public float zoomSpeed = 3f;

    public float turnInput = 0f;
    public float turnSpeed = 50f;

    void Start()
    {
        if (target == null)
        {
            Debug.LogError("Target atanmadý! Lütfen bir hedef nesne belirtin.");
        }
    }

    void Update()
    {
        // Zoom kontrolü
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // Dönüþ kontrolü
        turnInput -= Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        // Target yoksa hatayý önlemek için kontrol et
        if (target == null)
        {
            Debug.LogWarning("Target yok edildi veya null! Kamera hareket etmeyecek.");
            return; // Eðer target yoksa sonraki iþlemleri yapma
        }

        // Kameranýn pozisyonunu ve dönüþünü ayarla
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up);
        transform.RotateAround(target.position, Vector3.up, turnInput);
    }

    // Target deðiþtirme veya sýfýrlama için bir yardýmcý metot
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        if (target == null)
        {
            Debug.LogWarning("Yeni bir target atanamadý. Target null olarak ayarlandý.");
        }
    }
}
