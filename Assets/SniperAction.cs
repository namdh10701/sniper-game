using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperAction : MonoBehaviour
{
    [SerializeField] Animator animator;

    string scoped = "IsScoped";
    bool isScoped = false;
    bool isIdle = true;

    public bool IsIdle
    {
        get { return isIdle; }
        set { isIdle = value; }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (isIdle)
            {
                isScoped = !isScoped;
                animator.SetBool(scoped, isScoped);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (isIdle)
            {
                animator.SetTrigger("Fire");
                isIdle = false;
            }
        }
    }

    public void OnIdleEnter()
    {
        isIdle = true;
    }


}
