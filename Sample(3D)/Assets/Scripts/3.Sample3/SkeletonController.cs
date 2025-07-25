using UnityEngine;
//버튼의 OnClick에 등록할 기능

public class SkeletonController : MonoBehaviour
{
    public GameObject skeleton;
    //public void 메소드명()

    public float time;
    public float score;

    public void OnLbuttonEnter()
    {
        skeleton.transform.Translate(1, 0, 0);
    }

    public void OnRbuttonEnter()
    {
        skeleton.transform.Translate(-1, 0, 0); 
    }

    public void Update()
    {
        time += Time.deltaTime;
        score += time * 100;
        //
    }



}
