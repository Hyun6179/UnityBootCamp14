using UnityEngine;
using UnityEngine.InputSystem; // XR Input System ���

public class Extinguisher : MonoBehaviour
{
    public ParticleSystem sprayEffect;   // �л� ����Ʈ
    public Transform nozzle;             // �л� ��ġ
    private bool isSpraying = false;

    public InputActionProperty triggerAction; // XR ��Ʈ�ѷ� Trigger �Է�

    void Update()
    {
        // Ʈ���� �� �б� (0~1)
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
            Destroy(other.gameObject); // �� ���� (�ӽ�)
        }
    }
}
