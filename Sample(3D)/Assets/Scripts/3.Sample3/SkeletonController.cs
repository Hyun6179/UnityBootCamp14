using UnityEngine;
//��ư�� OnClick�� ����� ���

public class SkeletonController : MonoBehaviour
{
    public GameObject skeleton;
    //public void �޼ҵ��()

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
