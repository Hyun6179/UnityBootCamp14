using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    public GameObject hpbar;
    int hp;

    private void OnParticleCollision(GameObject other)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        hpbar = GameObject.FindGameObjectsWithTag("HpBar");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
