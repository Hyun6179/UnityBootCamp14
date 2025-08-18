using UnityEngine;

[CreateAssetMenu(menuName = "Attack Strategy/Melee")]
public class MeleeAttack : ScriptableObject, IAttackStrategy
{
    public void Attack(GameObject target)
    {
        Debug.Log("[Melee Attack]" + target.name);
        var spriteRenderer = target.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red;
    }
}
