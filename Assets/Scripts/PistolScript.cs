using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    public Animator pistolAnimator;
    public AudioSource reloadSFX;
    // Start is called before the first frame update
    void Start()
    {
        pistolAnimator.keepAnimatorControllerStateOnDisable = true;
    }
    private void OnEnable()
    {
        pistolAnimator.SetBool("reload", false);
        pistolAnimator.Play("pistolIdle", -1, 0f);

    }
    private void OnDisable()
    {
        pistolAnimator.Play("pistolIdle", -1, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        pistolAnimator.SetBool("reload", gameObject.GetComponent<Gun>().isReloading);
    }

    public void ReloadSFX()
    {
        reloadSFX.Play();
    }
}
