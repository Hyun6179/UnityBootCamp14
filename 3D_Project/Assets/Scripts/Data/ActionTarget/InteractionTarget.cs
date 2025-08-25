using System;
using UnityEngine;
using UnityEngine.UI;

public class InteractionTarget : MonoBehaviour
{
    [Header("Interaction 설정")]
    public string actionName;
    public float interactionCooldown = 3f;

    private float lastInteractTIme;
    private bool playerInRange = false;

    [Header("UI 안내")]
    public Text interactText; // 화면에 띄울 텍스트

    private ItemGathering gatherSystem;

    private void Awake()
    {
        // Scene에서 ItemGathering 참조 찾기
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
                interactText.text = $"{actionName} [Space]를 누르세요.";
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
