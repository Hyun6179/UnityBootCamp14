using UnityEngine;
using UnityEngine.UI;

public class InterPlayer : MonoBehaviour
{
    // 인스펙터 내에서 접근 가능 (내부 데이터 연결 목적) : SerializeField : private
    // 외부에서 접근 불가 (함부로 값 쓰지 말라는 용도) : private
    [SerializeField] private ScriptableObject attackObject1;
    [SerializeField] private ScriptableObject attackObject2;
    [SerializeField] private ScriptableObject attackObject3;

    private IAttackStrategy strategy1;
    private IAttackStrategy strategy2;
    private IAttackStrategy strategy3;

    public GameObject target;
    public Button Melee;
    public Button Caste;
    public Button Range;

    private void Awake()
    {
        strategy1 = attackObject1 as IAttackStrategy;
        strategy2 = attackObject2 as IAttackStrategy;
        strategy3 = attackObject3 as IAttackStrategy;

        if ( strategy1 == null || strategy2 == null || strategy3 == null)
        {
            Debug.LogError("공격 기능이 완전히 구현되지 않았습니다!");
        }
       
    }

    private void Update()
    {
        Melee.interactable = false;
        Caste.interactable = false;
        Range.interactable = false;

        float distance = Vector2.Distance(transform.position, target.transform.position);
        if      ( distance <= 1) Melee.interactable = true;
        else if ( distance < 3)  Range.interactable = true;
        else                     Caste.interactable = true;
    }

    public void ActionPerformed(GameObject target)
    {
        if (Melee.interactable == true) strategy1?.Attack(target);
        if (Caste.interactable == true) strategy2?.Attack(target);
        if (Range.interactable == true) strategy3?.Attack(target);
        // Nullable<T> or T? 는 Value에 대한 null 허용을 위한 도구
    }

}
