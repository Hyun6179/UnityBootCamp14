using UnityEngine;

[CreateAssetMenu(menuName = "Attack Strategy/Ranged")]
public class RangedAttack : ScriptableObject, IAttackStrategy

{
    public void Attack(GameObject target)
    {
        Debug.Log("[Ranged Attack]" + target.name);
        var spriteRenderer = target.GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.blue;
    }
}
