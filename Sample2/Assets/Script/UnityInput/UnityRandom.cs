using UnityEngine;

public class UnityRandom : MonoBehaviour
{

    [ContextMenuItem("랜덤 값 호출", "MenuAttributesMethod")]
    public int rand;

    public void MenuAttributesMethod()
    {
        //유니티의 랜덤 Random.Range(최소, 최대)
        //최소 값 범위 포함
        //최대 값 포함 x (정수)

        //최소 값 범위 포함
        //최대 값 포함 o (실수)

        rand = Random.Range(0, 10);
        // 0 1 2 3 4 5 6 7 8 9
        // 이중에서 9보다 작은 값이 뽑힐 확률? 90%

    }
}
