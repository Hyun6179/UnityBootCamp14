using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractionTarget : MonoBehaviour
{
    [Header("Interaction ����")]
    public string actionName;
    public float interactionCooldown = 3f;

    private float lastInteractTIme;
    private bool playerInRange = false;

    [Header("UI �ȳ�")]
    public Text interactText; // ȭ�鿡 ��� �ؽ�Ʈ

    private ItemGathering gatherSystem;

    private void Awake()
    {
        // Scene���� ItemGathering ���� ã��
        gatherSystem = FindObjectOfType<ItemGathering>();
        if (interactText != null)
            interactText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.Space))
        {
            TryInteract();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (interactText != null)
            {
                interactText.text = $"{actionName} [Space]�� ��������.";
                interactText.gameObject.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (interactText != null)
            {
                interactText.gameObject.SetActive(false);
            }
        }
    }

    private void TryInteract()
    {
        if (Time.time - lastInteractTIme < interactionCooldown)
            return;

        gatherSystem?.Interact(actionName);
        lastInteractTIme = Time.time;
    }
}
