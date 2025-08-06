using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemy_prefab;
    public int size = 10;

    [HideInInspector]
    public List<GameObject> pool;

    private void Start()
    {
        pool = new List<GameObject>();

        for (int i = 0; i < size; i++)
        {
            var enemy = Instantiate(enemy_prefab);
            enemy.transform.parent = transform;

            enemy.SetActive(false);

            //enemy.GetComponent<Enemy>().SetEnemyPool(this);

            pool.Add(enemy);
        }

    }


    public GameObject GetEnemy()
    {
        foreach (var enemy in pool)
        {
            if(!enemy.activeInHierarchy)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }

        var new_enemy = Instantiate(enemy_prefab);
        new_enemy.transform.parent = transform;
        //new_enemy.GetComponent<Enemy>().SetEnemyPool(this);
        pool.Add(new_enemy);
        return new_enemy;
    }
}
