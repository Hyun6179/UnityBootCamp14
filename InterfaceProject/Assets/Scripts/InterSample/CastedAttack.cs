using UnityEngine;

[CreateAssetMenu(menuName = "Attack Strategy/Casted")]
public class CastedAttack : ScriptableObject, IAttackStrategy
{
    public void Attack(GameObject target)
    {
        int count = 0;
        while (count < 5)
        {
            Debug.Log("캐스팅중...");
            count++;
        }
        Debug.Log("[Casted Attack]" + target.name);
        var spriteRenderer = target.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.yellow;
        count = 0;
    }
}
