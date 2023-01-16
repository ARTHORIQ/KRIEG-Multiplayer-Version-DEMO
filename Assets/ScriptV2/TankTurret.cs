using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(ObjectPool))]
public class TankTurret : MonoBehaviour
{
    public TankTurretData tankTurretData;

    public List<Transform> turretBarrels;
    public GameObject bulletPrefab;
    public float reloadDelay = 1;

    private bool canShoot = true;
    private Collider2D[] tankColliders;
    public float currentDelay = 0;
    private ObjectPool bulletPool;

    [SerializeField]
    private int bulletPoolCount = 10;
    public UnityEvent onShoot, onCantShoot;
    public UnityEvent<float> onReloading;


    private void Awake()
    {
        tankColliders = GetComponentsInParent<Collider2D>();
        bulletPool = GetComponent<ObjectPool>();
    }

    private void Start()
    {
        bulletPool.Initialize(tankTurretData.bulletPrefab, bulletPoolCount);
        onReloading?.Invoke(currentDelay);
    }

    private void Update()
    {
        if (canShoot == false)
        {
            currentDelay -= Time.deltaTime;
            onReloading?.Invoke(currentDelay);
            if (currentDelay <= 0)
            {
                canShoot = true;
            }
        }
    }

    public void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = tankTurretData.reloadDelay;

            foreach (var barrel in turretBarrels)
            {
                //GameObject bullet = Instantiate(bulletPrefab);
                GameObject bullet = bulletPool.CreateObject();
                bullet.transform.position = barrel.position;
                bullet.transform.localRotation = barrel.rotation;
                bullet.GetComponent<TankBullet>().Initialize(tankTurretData.bulletData);

                foreach (var collider in tankColliders)
                {
                    Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), collider);
                }
            }
            onShoot?.Invoke();
            onReloading?.Invoke(currentDelay);
        }
        else
        {
            onCantShoot?.Invoke();
        }
    }
}
