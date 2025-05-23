using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Start()
    {
        EventManager.OnBulletHit += OnBulletHit;
    }
    IEnumerator ShakeCoroutine()
    {
        Vector3 originalPosition = transform.localPosition;
        float shakeDuration = 0.1f;
        float shakeMagnitude = 0.07f;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            float x = Random.Range(-1f, 1f) * shakeMagnitude;
            float y = Random.Range(-1f, 1f) * shakeMagnitude;
            transform.localPosition = new Vector3(originalPosition.x + x, originalPosition.y + y, originalPosition.z);
            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
    }

    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }
    
    public void OnBulletHit(int x, int y, Bullet bullet)
    {
        Shake();
    }
}
