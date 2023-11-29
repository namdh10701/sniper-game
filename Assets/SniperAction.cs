using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAction : MonoBehaviour
{
    HudEvent hudEvent;
    [SerializeField] Animator animator;
    [SerializeField] ScopeCamera scopeCamera;
    [SerializeField] GameObject scopedCrosshair;
    AmmunationManager ammunationManager;
    string scoped = "IsScoped";
    bool isScoped = false;
    bool isIdle = true;
    bool isInScopedPosition;
    [SerializeField] Blur blur;
    public bool IsIdle
    {
        get { return isIdle; }
        set { isIdle = value; }
    }
    private void Start()
    {
        ammunationManager = new AmmunationManager();
        hudEvent.AmmunationChanged.Invoke(ammunationManager.AmmunationInfo);
    }
    public void Init(HudEvent hudEvent)
    {
        this.hudEvent = hudEvent;
        hudEvent.ZoomSliderChanged.AddListener((amount) => OnZoomAdjust(amount));
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isIdle)
            {

                isScoped = !isScoped;
                blur.enabled = isScoped;
                animator.SetBool(scoped, isScoped);
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (isIdle)
            {
                if (ammunationManager.IsAbleToDraw(1))
                {
                    ammunationManager.Draw(1);
                    animator.SetTrigger("Fire");
                    animator.SetTrigger("Bolt");
                    hudEvent.AmmunationChanged.Invoke(ammunationManager.AmmunationInfo);

                    if (!ammunationManager.IsAbleToDraw(1))
                    {
                        animator.SetTrigger(ammunationManager.IsAbleToReload ? "Reload" : "ToIdle");
                    }
                    else
                    {
                        animator.SetTrigger("ToIdle");
                    }
                }
                else if (ammunationManager.IsAbleToReload)
                {
                    animator.SetTrigger("Reload");
                }
                isIdle = false;
            }
        }

        if (animator.GetAnimatorTransitionInfo(0).IsName("Scoped Fire -> Bolt action"))
        {
            isInScopedPosition = false;
            scopeCamera.OnZoomCancel();
            scopedCrosshair.SetActive(false);

            blur.enabled = false;
        }
    }

    public void OnIdleEnter()
    {
        isIdle = true;
        isInScopedPosition = false;
        scopeCamera.OnZoomCancel();
        scopedCrosshair.SetActive(false);

    }

    public void OnScopedEnter()
    {
        blur.enabled = true;
        isInScopedPosition = true;
        scopedCrosshair.SetActive(true);
        scopeCamera.OnZoomAdjust();
    }

    public void OnZoomAdjust(float amount)
    {
        if (amount == 0)
        {
            isScoped = false;
            blur.enabled = false;
            animator.SetBool(scoped, isScoped);
        }
        else
        {
            if (!isInScopedPosition)
            {
                isScoped = true;
                animator.SetBool(scoped, isScoped);
            }
            else
            {
                scopeCamera.OnZoomAdjust(amount);
            }
        }
    }

    public void OnMagInserted()
    {
        ammunationManager.Reload();
        hudEvent.AmmunationChanged.Invoke(ammunationManager.AmmunationInfo);
    }

}
