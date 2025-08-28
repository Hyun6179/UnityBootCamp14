using TMPro;
using UnityEngine;

public class InteractionTarget : MonoBehaviour
{
    [Header("Interaction 설정")]
    public string actionName;
    public float interactionCooldown = 3f;

    private float lastInteractTIme;
    private bool playerInRange = false;

    [Header("UI 안내")]
    public TextMeshProUGUI interactText; // 화면에 띄울 텍스트
    public GameObject pannel;

    private ItemGathering gatherSystem;


    private void Awake()
    {
        // Scene에서 ItemGathering 참조 찾기
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
