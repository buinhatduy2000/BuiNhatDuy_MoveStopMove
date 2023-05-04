using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWeapon : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float bulletSpeed = 20f;
    [SerializeField] public GameObject father;

    private void Update()
    {
        _rb.velocity = transform.forward * bulletSpeed;
        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") && other.gameObject != father)
        {
            Destroy(this.gameObject);
        }
    }
}
