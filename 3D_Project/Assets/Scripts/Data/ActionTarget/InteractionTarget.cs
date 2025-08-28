using TMPro;
using UnityEngine;

public class InteractionTarget : MonoBehaviour
{
    [Header("Interaction ����")]
    public string actionName;
    public float interactionCooldown = 3f;

    private float lastInteractTIme;
    private bool playerInRange = false;

    [Header("UI �ȳ�")]
    public TextMeshProUGUI interactText; // ȭ�鿡 ��� �ؽ�Ʈ
    public GameObject pannel;

    private ItemGathering gatherSystem;


    private void Awake()
    {
        // Scene���� ItemGathering ���� ã��
        gatherSystem = FindObjectOfType<ItemGathering>();
        if (interactText != null)
        {
            pannel.SetActive(false);
        }
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
                interactText.text = $"{actionName} [Space]";
                pannel.SetActive(true);
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
                pannel.SetActive(false);
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
