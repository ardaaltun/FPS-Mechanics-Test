using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleScript : MonoBehaviour
{
    public Animator rifleAnimator;
    bool isScoped = false;
    public GameObject scope;
    public Camera mainCam;
    public GameObject scopeCamera;
    float normalZoom;
    public float scopeZoom = 15f;
    public AudioSource reloadSFX;
    // Start is called before the first frame update
    private void Start()
    {
        normalZoom = mainCam.fieldOfView;
    }
    private void OnEnable()
    {
        rifleAnimator.SetBool("reload", false);
        rifleAnimator.Play("sniperIdle", -1, 0f);
    }
    private void OnDisable()
    {
        rifleAnimator.Play("sniperIdle", -1, 0f);
    }
    // Update is called once per frame
    void Update()
    {
        
        rifleAnimator.SetBool("reload", gameObject.GetComponent<Gun>().isReloading);

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isScoped = !isScoped;
            rifleAnimator.SetBool("scoped", isScoped);
            StartCoroutine(onScope());
        }
        
         if (isScoped) StartCoroutine(onScope());
        else onUnscope();
        

        
    }
    
    IEnumerator onScope()
    {
        yield return new WaitForSeconds(.05f);
        scope.SetActive(true);
        scopeCamera.SetActive(false);
        mainCam.fieldOfView = scopeZoom;
    }

    void onUnscope() 
    {
        scope.SetActive(false);
        scopeCamera.SetActive(true);
        mainCam.fieldOfView = normalZoom;
    }

    void ReloadSFX()
    {
        reloadSFX.Play();
    }
}
