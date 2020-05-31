using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : BaseController
{
    Stat _stat;

    public override void Init()
    {
        _stat = gameObject.GetComponent<Stat>();

        if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
            Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
    }

    protected override void UpdateIdle()
    {
        Debug.Log("Monster UpdateIdle");
    }

    protected override void UpdateMoving()
    {
        Debug.Log("Monster UpdateMoving");
    }

    protected override void UpdateSkill()
    {
        Debug.Log("Monster UpdateSkill");
    }

    void OnHitEvent()
    {
        Debug.Log("Monster OnHitEvent");
    }

    void EndHitEvent()
    {
        Debug.Log("Monster EndHitEvent");

        //if (_stopSkill)
        //{
        //    State = Define.State.Idle;
        //}
        //else
        //{
        //    State = Define.State.Skill;
        //}
    }
}
