using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class akScript : MonoBehaviour
{
    public Animator akAnimator;
    public AudioSource reloadSFX;
    // Start is called before the first frame update
    void Start()
    {
        akAnimator.keepAnimatorControllerStateOnDisable = true;
    }
    private void OnEnable()
    {
        akAnimator.SetBool("reload", false);
        akAnimator.Play("akIdle", -1, 0f);

    }
    private void OnDisable()
    {
        akAnimator.Play("akIdle", -1, 0f);
    }
    // Update is called once per frame
    void Update()
    {
       akAnimator.SetBool("reload", gameObject.GetComponent<Gun>().isReloading);
    }

    public void ReloadSFX()
    {
        reloadSFX.Play();
    }
}
