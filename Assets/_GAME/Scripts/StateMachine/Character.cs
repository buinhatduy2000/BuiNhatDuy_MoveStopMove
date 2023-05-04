using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField] protected GameObject weaponPrefabs;
    [SerializeField] protected Transform shootPoint;
    [SerializeField] protected float attackCooldown = 1.0f;
    [Header("Character properties")]
    [SerializeField] protected float characterMoveSpeed;
    [SerializeField] protected float attackRange;
    [SerializeField] protected Animator anim;
    [SerializeField] private string currentAnim;
    [SerializeField] protected Rigidbody _rb;
    [SerializeField] private LineRenderer rangeCircle;
    [SerializeField] private LayerMask characterLayer;

    private float timeUntilNextAttack;

    public virtual void Start()
    {
        ChangeAnimation("idle");
        UpdateRangeCircle();
    }

    public virtual void Update()
    {
        if (timeUntilNextAttack > 0)
            timeUntilNextAttack -= Time.deltaTime;
    }
    protected bool IsCharacterInAttackRange()
    {
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, attackRange, characterLayer);

        return collidersInRange.Any(collider => collider.CompareTag("Enemy") && collider.gameObject != this.gameObject);
    }

    #region Draw Attack Range
    private void UpdateRangeCircle()
    {
        if (rangeCircle != null)
        {
            int segments = 50;
            float radius = attackRange;
            rangeCircle.positionCount = segments + 1;

            float angle = 360f / segments;
            for (int i = 0; i < segments + 1; i++)
            {
                float rad = Mathf.Deg2Rad * (i * angle);
                float x = radius * Mathf.Cos(rad);
                float z = radius * Mathf.Sin(rad);
                rangeCircle.SetPosition(i, new Vector3(x, 0, z));
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
    #endregion

    #region Animator function
    protected void ChangeAnimation(string animName)
    {
        if (currentAnim != animName)
        {
            anim.SetTrigger(animName);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }
    #endregion

    #region Character Attack
    protected void Attack()
    {
        if (timeUntilNextAttack > 0) return;

        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, attackRange, characterLayer);
        Collider nearestEnemy = null;
        float minDistance = float.MaxValue;

        foreach (Collider collider in collidersInRange)
        {
            if (collider.CompareTag("Enemy") && collider.gameObject != this.gameObject)
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestEnemy = collider;
                }
            }
        }

        if (nearestEnemy != null)
        {
            Vector3 targetDirection = (nearestEnemy.transform.position - transform.position).normalized;
            float step = characterMoveSpeed * Time.deltaTime;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
            transform.rotation = Quaternion.LookRotation(newDirection);

            if (Vector3.Angle(transform.forward, targetDirection) <= 1.0f)
            {
                GameObject bullet = Instantiate(weaponPrefabs, shootPoint.position, transform.rotation);
                bullet.GetComponent<BaseWeapon>().father = this.gameObject;
                timeUntilNextAttack = attackCooldown;
            }
        }
    }
    #endregion
}
