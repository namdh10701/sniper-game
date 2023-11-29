using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Hud hud;
    [SerializeField] SniperAction sniperAction;

    private void Awake()
    {
        HudEvent hudEvent = new HudEvent();
        hud.Init(hudEvent);
        sniperAction.Init(hudEvent);
    }
}