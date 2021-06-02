using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class BulletManager : Singleton<BulletManager>
{
    public GameObject bullet;
    public GameObject grenade;
    public int amount = 0;

    private List<List<GameObject>> generalPool = new List<List<GameObject>>();

    private List<GameObject> bullets = new List<GameObject>();
    private List<GameObject> grenades = new List<GameObject>();

    void Awake()
    {
        AddPoolsInPool();
        AddBulletsInPool();
    }

   public GameObject BulletAwake(Vector3 pos, Quaternion rot, int ammoNum)
    {
        foreach (var item in generalPool[ammoNum])
        {
            if (!item.activeInHierarchy)
            {
                item.transform.position = pos;
                item.transform.rotation = rot;
                item.transform.SetParent(null);
                item.SetActive(true);
                BulletForce bulletForce = item.GetComponent<BulletForce>();
                bulletForce.OnBulletHit += ReturnToPool;
                bulletForce.CustomStart();
                return item;
            }
        }

        var instance = Instantiate(bullet, pos, rot);
        bullets.Add(instance);
        return instance;
    } 


    void ReturnToPool(BulletForce bullet)
    {
        bullet.gameObject.SetActive(false);
        Rigidbody rig = bullet.gameObject.GetComponent<Rigidbody>();
        bullet.OnBulletHit -= ReturnToPool;
        rig.velocity = Vector3.zero;
        bullet.transform.SetParent(transform);
    }


    void AddPoolsInPool()
    {
        generalPool.Add(bullets);
        generalPool.Add(grenades);
    }
    void AddBulletsInPool()
    {
        if (bullet != null)
        {
            for (int i = 0; i < amount; i++)
            {
                var instance = Instantiate(bullet);
                instance.transform.SetParent(transform);
                instance.SetActive(false);
                bullets.Add(instance);
            }
        }

        if (grenade != null)
        {
            for (int i = 0; i < amount; i++)
            {
                var instance = Instantiate(grenade);
                instance.transform.SetParent(transform);
                instance.SetActive(false);
                grenades.Add(instance);
            }
        }
    }
}
