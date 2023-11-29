using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Hud : MonoBehaviour
{ 
    [SerializeField] TextMeshProUGUI currentAmmo;
    private HudEvent hudEvent;

   
    public void Init(HudEvent hudEvent)
    {
        this.hudEvent = hudEvent;
        hudEvent.AmmunationChanged.AddListener((ammunationInfo) => OnAmmunationChanged(ammunationInfo));
    }

    private void OnAmmunationChanged(AmmunationInformation ammunationInfo)
    {
        currentAmmo.text = $"Ammo: {ammunationInfo.CurrentClipAmount} / {ammunationInfo.SavingAmount}";
    }

    public void OnZoomSliderValueChanged(Single s)
    {
        hudEvent.ZoomSliderChanged.Invoke(s);
    }
}
