using UnityEngine;

public class BoxRotate : MonoBehaviour
{
    public Vector3 pos;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(pos * Time.deltaTime);
        //Time.deltaTime은 이전 프레임부터 현재 프레임까지 걸린 시간
        //Update에서의 보정 값으로 활용됩니다.

        //transform.rotate(voctor3 pos);
        //해당 죄표만큼 게임 오브젝트를 회전
    }
}
