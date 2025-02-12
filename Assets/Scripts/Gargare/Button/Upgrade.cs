


using TMPro;
using UnityEngine;

public class Upgrade:MonoBehaviour
{
    [SerializeField] private PowerBar powerBar;
    public TMP_Text text;
    protected int amount;


    public void UpdateUI(int amount, int level)
    {
        this.amount = amount;
        text.text = amount.ToString();
        powerBar.ChangeImage(level);
    }
}

