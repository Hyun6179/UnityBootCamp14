using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Sample : MonoBehaviour
{
    public Button Button;
    public event UnityAction OnDrawEnter;
    public Text congrate;
    public Text result;

    private int rand;
    private bool pass7 = false;
    private bool pass8 = false;
    private bool pass9 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        OnDrawEnter += GetRandomNum;
        OnDrawEnter += Debug_OnDraw;
        OnDrawEnter += Congrate;
        Button.onClick.AddListener(OnDrawEnter);
    }

    private void GetRandomNum()
    {
        rand = Random.Range(1, 11);
        if (rand == 7 && pass7) { GetRandomNum(); }
        if (rand == 8 && pass8) { GetRandomNum(); }
        if (rand == 9 && pass9) { GetRandomNum(); }
    }
    private void Debug_OnDraw()
    {
        string[] itemList = { "","stick", "rock", "leaf", "web", "sword", "bow", "wand", "skill_dash", "skill_heal", "skill_superJump" };
        result.text = $"{itemList[rand]}¿ª »πµÊ«ﬂΩ¿¥œ¥Ÿ.";
        Debug.Log($"{rand}π¯ æ∆¿Ã≈€ \n{itemList[rand]}¿ª »πµÊ«ﬂΩ¿¥œ¥Ÿ.");
        if (itemList[rand] is "skill_dash")      pass7 = true;
        if (itemList[rand] is "skill_heal")      pass8 = true ;
        if (itemList[rand] is "skill_superJump") pass9 = true ;
    }

    private void Congrate()
    {
        if      (rand < 5) { congrate.text = "≥Î∏ª µÓ±ﬁ æ∆¿Ã≈€ »πµÊ!"; }
        else if (rand < 8) { congrate.text = "∑πæÓ µÓ±ﬁ æ∆¿Ã≈€ »πµÊ!"; }
        else               { congrate.text = "√‡«œ«’¥œ¥Ÿ! ¿Ø¥œ≈© µÓ±ﬁ æ∆¿Ã≈€ »πµÊ!"; }
    }
}
