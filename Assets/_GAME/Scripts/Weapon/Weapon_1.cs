using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_1 : GameUnit
{
    [SerializeField]
    private Rigidbody _rb;

    [SerializeField]
    private float bulletSpeed = 20f;

    [SerializeField]
    public GameObject father;

    public void OnInit() { }

    private void Update()
    {
        _rb.velocity = transform.forward * bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") && other.gameObject != father)
        {
            //SimplePool.Despawn(this);
        }
    }
}
