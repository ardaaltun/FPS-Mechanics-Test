using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleShotgunScript : MonoBehaviour
{
    public Animator doubleShotgunAnimator;
    public AudioSource reloadSFX;
    // Start is called before the first frame update
    void Start()
    {
        doubleShotgunAnimator.keepAnimatorControllerStateOnDisable = true;
    }
    private void OnEnable()
    {
        doubleShotgunAnimator.SetBool("reload", false);
        doubleShotgunAnimator.Play("doubleShotgunIdle", -1, 0f);

    }
    private void OnDisable()
    {
        doubleShotgunAnimator.Play("doubleShotgunIdle", -1, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        doubleShotgunAnimator.SetBool("reload", gameObject.GetComponent<Gun>().isReloading);
    }

    public void ReloadSFX()
    {
        reloadSFX.Play();
    }
}
