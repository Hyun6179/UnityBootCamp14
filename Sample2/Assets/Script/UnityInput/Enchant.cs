using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class Enchant : MonoBehaviour
{
    public GameObject trigger;
    public Vector3 movement;
    Vector3 stay;

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

    private void Start()
    {
        movement = trigger.transform.position;
        stay = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (movement.x != stay.x)
        {
            LevelUp();
        }
    }

    private void LateUpdate()
    {
        enchant.text = $"강화 수치 {level}";
    }


}
