using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float characterMoveSpeed;
    [SerializeField] protected float attackRange;
    [SerializeField] protected Animator anim;
    [SerializeField] private string currentAnim;
    [SerializeField] protected Rigidbody _rb;
    [SerializeField] private LineRenderer rangeCircle;
    [SerializeField] private LayerMask characterLayer;

    public virtual void Start()
    {
        ChangeAnimation("idle");
        UpdateRangeCircle();
    }

    public virtual void Update()
    {
        //IsCharacterInRange();
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
}
