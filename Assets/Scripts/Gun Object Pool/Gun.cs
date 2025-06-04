using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform muzzle;
    [SerializeField] LayerMask HitableObjects;
    [SerializeField] GameObject bulletPrefab;

    [SerializeField] AmmoUIManager ammoUI;

    [Header("Gun Stats")]
    [SerializeField] int damage;

    [SerializeField] int magazineSize;
    [SerializeField] int maxAmmo;
    int _currentMagazineAmmo;
    int _currentAmmo;

    [SerializeField] float reloadTime;
    float _lastReloadTime;
    bool _reloading;

    [SerializeField] float fireRate;
    float _inBetweenShotsTime;
    float _lastShotTime;

    //Pool
    List<Bullet> _bulletPool = new List<Bullet>();

    [SerializeField] private AudioClip shoot;

    // Start is called before the first frame update
    void Start()
    {
        _inBetweenShotsTime = 1 / fireRate;
        _currentAmmo = maxAmmo;
        ReloadEmptyGun();

        //shoot = GetComponent<AudioSource>();
    }

    private void ReloadEmptyGun()
    {
        if(_currentAmmo >= magazineSize)
        {
            _currentMagazineAmmo = magazineSize;
            _currentAmmo -= magazineSize;
        }
        else
        {
            _currentMagazineAmmo = _currentAmmo;
            _currentAmmo = 0;
        }
        ammoUI.SetMagazineAmmoText(_currentMagazineAmmo);
        ammoUI.SetGeneralAmmoText(_currentAmmo);
    }
    // Update is called once per frame
    void Update()
    {
        if (_reloading)
        {
            Debug.Log("Reloading");
            if (Time.time - _lastReloadTime < reloadTime) return;
            ReloadEmptyGun();
            _reloading = false;
            Debug.Log("Click");
            return;
        }
        if (Input.GetMouseButton(0))
        {
            if (_currentMagazineAmmo <= 0) 
            {
                if (_currentAmmo <= 0)
                {
                    Debug.Log("No ammo");
                    return;
                }
                _lastReloadTime = Time.time;
                _reloading = true;
                return;
            }
            if (Time.time - _lastShotTime < _inBetweenShotsTime) return;
            Shoot();
        }
    }
    void Shoot()
    {
        _lastShotTime = Time.time;
        _currentMagazineAmmo--;
        Debug.Log("POW");

        //shoot.Play();
        AudioManager.Instance.SoundEffect(shoot);

        ammoUI.SetMagazineAmmoText(_currentMagazineAmmo);
        //RayShootMethod()
        BulletShootMethod();
    }
    private void BulletShootMethod()
    {
        if (TryGetBullet(out GameObject bulletfound))
        {
            bulletfound.gameObject.transform.position = muzzle.transform.position;
            bulletfound.gameObject.transform.rotation = muzzle.transform.rotation;
            bulletfound.gameObject.SetActive(true);
            return;
        }
        bulletfound = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
        bulletfound.GetComponent<Bullet>().gundamage = damage;
        _bulletPool.Add(bulletfound.GetComponent<Bullet>());
    }

    //private void RayShootMethod()
    //{
    // //Position, dir, hit
    //    if(Physics.Raycast(muzzle.position, muzzle.forward, out RaycastHit hit, 100, HitableObjects))
    //    {
    //        if (!hit.rigidbody)
    //        {
    //            Debug.Log("Missed");
    //            return;
    //        }
    //        if(hit.rigidbody.TryGetComponent(out EnemyMovement enemy))
    //        {
    //            enemy.RecieveDamage(damage);
    //        }
    //        Debug.Log(hit.rigidbody.name);
    //    }
    //}


    //private GameObject GetBullet()
    //{
    //    foreach(Bullet bullet in _bulletPool)
    //    {
    //        if(!bullet.gameObject.activeSelf) return bullet.gameObject;
    //    }
    //    GameObject bul = Instantiate(bulletPrefab, muzzle.transform.position, muzzle.transform.rotation);
    //    return bul;
    //}

    private bool TryGetBullet(out GameObject bulletfound)
    {
        foreach (Bullet bullet in _bulletPool)
        {
            if (bullet.gameObject.activeSelf) continue;
            bulletfound = bullet.gameObject;
            return true;
        }
        bulletfound = null;
        return false;
    }
}
