using TMPro;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public TMP_Text hpText;

    public void UpdateHP(float current, float max)
    {
        hpText.text = $"HP : {current}/{max}";
    }
}
