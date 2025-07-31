using System;
using UnityEngine;
using UnityEngine.Events;



public class Sample : MonoBehaviour
{
    public enum Job
    {
        None,
        KNIGHT,
        MAGE,
        ROGUE
    }

    [Serializable]
    public class PlayerStat
    {
        public string Class;
        public int HP;
        public int MP;
        public int atk;
        public int def;
        public int spd;
        public int range;
    }

    public PlayerStat ps;

    public UnityEvent UnityEvent;

    private void Update()
    {
        UnityEvent.Invoke();
    }

    public void OnJobChoice()
    {
        Job job = Job.None;
        switch (job)
        {
            case Job.KNIGHT:
                ps.HP = 100;
                ps.MP = 20;
                ps.atk = 20;
                ps.def = 30;
                break;
            case Job.MAGE:
                ps.HP = 50;
                ps.MP = 50;
                ps.atk = 30;
                ps.def = 10;
                break;
            case Job.ROGUE:
                ps.HP = 75;
                ps.MP = 30;
                ps.atk = 25;
                ps.def = 25;
                break;


        }
    }






}
