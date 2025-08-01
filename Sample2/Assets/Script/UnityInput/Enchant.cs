using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Enchant : MonoBehaviour
{
    public Text enchant;

    public int level;

    public int rand;

    public void LevelUp()
    {
        if (level < 10)
        {
            rand = Random.Range(0, 10);

            if(rand < 10 - level)
            {
                level++;
            }

        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LevelUp();
        }
    }

    private void LateUpdate()
    {
        enchant.text = $"강화 수치 {level}";
    }


}
