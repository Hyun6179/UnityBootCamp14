using UnityEngine;

public class DMouseRaycaster : MonoBehaviour
{
    private Camera cam;
    public float distance = 10.0f;
    public LayerMask layerMask;
    
    
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, distance, layerMask))
            {
                // 트리거 체크
                var trigger = hit.collider.GetComponent<DTrigger>();

                if (trigger != null )
                {
                    trigger.OnDTriggerEnter();
                }
            }
        }
    }
}
