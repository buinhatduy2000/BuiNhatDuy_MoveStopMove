using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] protected float characterMoveSpeed;
    [SerializeField] protected float attackRange;
    [SerializeField] protected Animator anim;
    [SerializeField] private string currentAnim;
    [SerializeField] protected Rigidbody _rb;
    [SerializeField] private GameObject attackRangeObject;

    public StateMachine<Character> StateMachine { get; protected set; }

    public IdleState IdleState;
    public RunState RunState;
    public AttackState AttackState;
    public DeadState DeadState;

    public virtual void Start()
    {
        ChangeAnimation("idle");
        UpdateAttackRangeObject();
    }

    private void UpdateAttackRangeObject()
    {
        if (attackRangeObject != null)
        {
            attackRangeObject.transform.localScale = new Vector3(attackRange, 0, attackRange);
        }
    }

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

    #region State Functions

    #region Idle State
    public virtual void OnEnterIdleState()
    {
       
    }
    public virtual void OnExecuteIdleState()
    {

    }
    public virtual void OnExitIdleState()
    {

    }
    #endregion

    #region Run State
    public virtual void OnEnterRunState()
    {
       
    }
    public virtual void OnExecuteRunState()
    {
        
    }
    public virtual void OnExitRunState()
    {

    }
    #endregion

    #region Attack State
    public virtual void OnEnterAttackState()
    {
        
    }
    public virtual void OnExecuteAttackState()
    {

    }
    public virtual void OnExitAttackState()
    {

    }
    #endregion

    #region Dead State
    public virtual void OnEnterDeadState()
    {
        
    }
    public virtual void OnExecuteDeadState()
    {

    }
    public virtual void OnExitDeadState()
    {

    }
    #endregion

    #endregion
}
