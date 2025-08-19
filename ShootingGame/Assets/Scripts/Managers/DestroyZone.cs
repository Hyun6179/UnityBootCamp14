using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Contains("Bullet"))
        {
            other.gameObject.SetActive(false);
        }
        else
            Destroy(other.gameObject); // »ó´ë¹æ ÆÄ±«
    }
}
