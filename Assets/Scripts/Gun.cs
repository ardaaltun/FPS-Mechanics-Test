using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    #region Variables
    public int damage = 20;
    public int range = 100;

    public Camera fpsCam;
    public ParticleSystem muzzle;
    public GameObject impact;
    public GameObject impactBloody;
    public float nextTimeToFire = 0f;
    public float fireRate = 0.1f;
    public bool isAuto = false;
    public bool isReloading = false;
    public AudioSource shootingSFX;
    public AudioSource emptySFX;
    public Text ammoText;
    public bool isEmpty;
    //AMMO
    public int maxAmmo;
    public int magazineSize;
    public int currentAmmo;
    public float reloadTime;
    public ParticleSystem shellParticle = null;

    #endregion
    private void Start()
    {
        currentAmmo = magazineSize;
    }

    private void OnEnable()
    {
        isReloading = false;
    }
   
    void Update()
    {
        //ammo UI
        
        //If the gun is empty
        if (isEmpty && Input.GetKey(KeyCode.Mouse0))
            emptySFX.Play();
        //Check if the magazine is empty
        if (maxAmmo <= 0 && currentAmmo <= 0)
        {
            isEmpty = true;
            //Debug.Log("NO AMMO");
            return;
        }
        
        //If reloading the gun, simply return nothing and jump to the next frame.
        if (isReloading)
        return;

        //Auto Reload when there is no bullet left in the magazine
        if (currentAmmo <= 0 && maxAmmo > 0 && !isReloading)
        {
            StartCoroutine(Reload());
            return;
        }

        //AUTO GUNS
        if (isAuto && Input.GetKey(KeyCode.Mouse0) && Time.time >=  nextTimeToFire && (currentAmmo > 0 || maxAmmo > 0))
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
            
        }

        //SINGLE SHOT GUNS
        if (!isAuto && Input.GetKeyDown(KeyCode.Mouse0) && (currentAmmo > 0 || maxAmmo > 0))
        {
            Shoot();
            
        }
                                                              //check if magazine is already full      //if we have bullets to load      //if we already loaded all the bullets (like 12/12 or 9/9)
        //Reload by R Key                                              
        if (Input.GetKeyDown(KeyCode.E) && !isReloading &&     currentAmmo != magazineSize                    && maxAmmo > 0               && currentAmmo != maxAmmo)
        {
            StartCoroutine(Reload());
            return;
        }
        
        ammoText.text = currentAmmo + "/" + maxAmmo;
    }
    IEnumerator Reload()
    {
        int add = magazineSize - currentAmmo;
        //Debug.Log(add + " " + magazineSize + " " + maxAmmo);
        isReloading = true;
        //Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);

        //If the current ammo goes out by itself without us pressing E to reload, this if statement will work
        if (currentAmmo <= 0 && maxAmmo >= magazineSize)
        {
            Debug.Log("1. durum");
            currentAmmo = magazineSize;
        }
        else if (currentAmmo <= 0 && maxAmmo < magazineSize)
        {
            Debug.Log("2. durum");
            currentAmmo = maxAmmo;
        }

        
        //If we press R key to reload

        //If maxAmmo - add > magSize this will run
        else if (currentAmmo > 0 && maxAmmo >= magazineSize && magazineSize <= maxAmmo - add)
        {
            Debug.Log("3. durum");
            //currentAmmo += add;
            //maxAmmo -= add;
            currentAmmo = magazineSize;
        }

        //if maxAmmo - add < magSize this will run because that means when we reload, our mag will be full and the remaining bullet count will be less and it doesn't make sense (i.e. 12/4, it has to bee 12/12) 
        else if (currentAmmo > 0 && maxAmmo >= magazineSize && magazineSize > maxAmmo - add)
        {
            Debug.Log("4. durum");
            currentAmmo = magazineSize;
            
        }

        //basically it means our maxAmmo is less than magSize, so we just load all the remaining bullets to the magazine like from 7/11 to 11/11 when pressed R key.
        else if (currentAmmo > 0 && maxAmmo < magazineSize)
        {
            Debug.Log("5. durum");
            currentAmmo = maxAmmo;
            
        }

        isReloading = false;
        isEmpty = false;
        
    }
    private void Shoot()
    {
        
        RaycastHit hit;
        muzzle.Play();
        shootingSFX.Play();

        
        currentAmmo--;
        maxAmmo--;

        //instantiate empty bullet
        if (shellParticle != null)
            shellParticle.Emit(1);

        //then:
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            //instantiate bullethole
            if(hit.transform.tag == "Enemy")
            {
                GameObject bloodyTemp = Instantiate(impactBloody, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(bloodyTemp, 0.2f);
                
            }
            else if(hit.collider.isTrigger)
            {
                GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
                foreach (GameObject enemy in enemies)
                {
                    enemy.GetComponent<Target>().Jump();
                    
                }
                    
            }
            else
            {
                GameObject impactTemp = Instantiate(impact, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactTemp, 0.2f);
            }

            
                
            Target target = hit.transform.GetComponent<Target>();
            
            if (target != null)
                target.TakeDamage(damage);
            //Debug.Log(hit.transform.name);
        }
    }
}
