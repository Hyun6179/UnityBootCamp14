using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactRange = 2f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, interactRange))
            {
                ItemGathering gather = hit.collider.GetComponent<ItemGathering>();
                if (gather != null)
                {
                    gather.Interact("ChopTree"); // DropTableSOÀÇ actionName°ú ¸ÂÃã
                }
            }
        }
    }
}
