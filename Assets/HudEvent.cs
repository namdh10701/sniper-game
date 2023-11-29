using UnityEngine.Events;

public class HudEvent
{
    public UnityEvent<float> ZoomSliderChanged;
    public UnityEvent ReloadButtonClicked;
    public UnityEvent FireButtonClicked;
    public UnityEvent<AmmunationInformation> AmmunationChanged;
    public HudEvent()
    {
        ZoomSliderChanged = new UnityEvent<float>();
        ReloadButtonClicked = new UnityEvent();
        FireButtonClicked = new UnityEvent();
        AmmunationChanged = new UnityEvent<AmmunationInformation>();
    }
}