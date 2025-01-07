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
            Debug.LogError("Target atanmad�! L�tfen bir hedef nesne belirtin.");
        }
    }

    void Update()
    {
        // Zoom kontrol�
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        // D�n�� kontrol�
        turnInput -= Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
    }

    private void LateUpdate()
    {
        // Target yoksa hatay� �nlemek i�in kontrol et
        if (target == null)
        {
            Debug.LogWarning("Target yok edildi veya null! Kamera hareket etmeyecek.");
            return; // E�er target yoksa sonraki i�lemleri yapma
        }

        // Kameran�n pozisyonunu ve d�n���n� ayarla
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up);
        transform.RotateAround(target.position, Vector3.up, turnInput);
    }

    // Target de�i�tirme veya s�f�rlama i�in bir yard�mc� metot
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        if (target == null)
        {
            Debug.LogWarning("Yeni bir target atanamad�. Target null olarak ayarland�.");
        }
    }
}
