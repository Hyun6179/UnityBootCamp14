using UnityEngine;


public class Obstacle : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        //선생님이 주신 미션
        /*
         * Obstacle 스크립트를 만들어서 장애물을 구현하세요.

        조건1)  장애물의 태그는 "obstacle"
            	장애물과 트리거 충돌 할 경우 플레이어의 speed가 1 감소
            	장애물 제거
         */
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("충돌 발생!");
            gameObject.SetActive(false);
        }
    }
}
