using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private void OnCollisionStay(Collision collision)
    {
        if(Input.GetKeyDown(KeyCode.Space)) // 상호작용 Space키
        {
            int count = 0;
            if (collision.gameObject.CompareTag("Tree")) // 상호작용 대상이 
            {
                while (count < 3)
                {
                    Debug.Log("나무 흔드는 중...");
                    count++;
                }
                // 나뭇잎, 나뭇가지, 돈, 아이템 랜덤드랍
            }
            else
                return;
        }
    }
}
