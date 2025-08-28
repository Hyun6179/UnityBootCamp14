using UnityEngine;
using UnityEngine.InputSystem; // XR Input System 사용

public class Extinguisher : MonoBehaviour
{
    public ParticleSystem sprayEffect;   // 분사 이펙트
    public Transform nozzle;             // 분사 위치
    private bool isSpraying = false;

    public InputActionProperty triggerAction; // XR 컨트롤러 Trigger 입력

    void Update()
    {
        // 트리거 값 읽기 (0~1)
        float triggerValue = triggerAction.action.ReadValue<float>();

        if (triggerValue > 0.1f && !isSpraying)
        {
            StartSpray();
        }
        else if (triggerValue <= 0.1f && isSpraying)
        {
            StopSpray();
        }
    }

    void StartSpray()
    {
        isSpraying = true;
        sprayEffect.Play();
    }

    void StopSpray()
    {
        isSpraying = false;
        sprayEffect.Stop();
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Fire"))
        {
            Destroy(other.gameObject); // 불 끄기 (임시)
        }
    }
}
