using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M4Script : MonoBehaviour
{
    public Animator m4Animator;
    public AudioSource reloadSFX;
    // Start is called before the first frame update
    void Start()
    {
        m4Animator.keepAnimatorControllerStateOnDisable = true;
    }
    private void OnEnable()
    {
        m4Animator.SetBool("reload", false);
        m4Animator.Play("m4Idle", -1, 0f);

    }
    private void OnDisable()
    {
        m4Animator.Play("m4Idle", -1, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        m4Animator.SetBool("reload", gameObject.GetComponent<Gun>().isReloading);
    }

    public void ReloadSFX()
    {
        reloadSFX.Play();
    }
}
