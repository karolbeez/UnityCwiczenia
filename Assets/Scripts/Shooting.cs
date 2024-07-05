using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Bullet pocisk;
    private GameManagerScript _waveCheck;
    public float wave = 1;
    public float fireRate = 0.5F;
    public float bulletForce = 10f;
    private float _nextFire = 0.0F;
    
    
    
    
    // wrzuc bullet dmg do bullet cs
    public void setWeaponStat(float newfireRate, float newbulletForce, float newdamage)
    {
        fireRate = newfireRate;
        bulletForce = newbulletForce;
        pocisk.gameObject.GetComponent<Bullet>().damage = newdamage;

    }
    
    
    
    
    void Update()
    {
        
        
        
        
        if (Input.GetButton("Fire1") && Time.time > _nextFire)
        {
            Shoot();
        }
    }
    
    
    
    
    
    
// Instancjonowanie posicku

#region Shoot
    void Shoot()
    {   
        
        _nextFire = Time.time + fireRate;
        
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

    }
    #endregion
}
