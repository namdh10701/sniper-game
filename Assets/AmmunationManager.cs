using TMPro;
using UnityEngine;

public class AmmunationManager
{
    int clipAmount = 3;
    public AmmunationInformation AmmunationInfo { get; private set; }

    public AmmunationManager()
    {
        AmmunationInfo = new AmmunationInformation();
        AmmunationInfo.SavingAmount = 3;
        AmmunationInfo.CurrentClipAmount = clipAmount;
    }
    public void Draw(int amount)
    {
        AmmunationInfo.CurrentClipAmount -= amount;
    }

    public void Reload()
    {
        AmmunationInfo.CurrentClipAmount = Mathf.Min(clipAmount, AmmunationInfo.SavingAmount);
        AmmunationInfo.SavingAmount = Mathf.Max(AmmunationInfo.SavingAmount - clipAmount, 0);
    }

    public bool IsAbleToDraw(int drawAmount)
    {
        return AmmunationInfo.CurrentClipAmount >= drawAmount;
    }

    public bool IsAbleToReload => AmmunationInfo.SavingAmount > 0;
}