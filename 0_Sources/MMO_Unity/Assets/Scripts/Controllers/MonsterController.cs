using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : BaseController
{
    Stat _stat;

    [SerializeField]
    float _scanRange = 10;

    [SerializeField]
    float _attackRange = 2;

    public override void Init()
    {
        _stat = gameObject.GetComponent<Stat>();

        if (gameObject.GetComponentInChildren<UI_HPBar>() == null)
            Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
    }

    protected override void UpdateIdle()
    {
        // TODO : 매니저가 생기면 옮기자
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
            return;

        float distance = (player.transform.position - transform.position).magnitude;
        if (distance <= _scanRange)
        {
            _lockTartget = player;
            State = Define.State.Moving;
            return;
        }
    }

    protected override void UpdateMoving()
    {
        // 플레이어가 사정거리 안이면 공격
        if (_lockTartget != null)
        {
            _destPos = _lockTartget.transform.position;
            float distance = (_destPos - transform.position).magnitude;
            if (distance <= _attackRange)
            {
                NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
                nma.SetDestination(transform.position);

                State = Define.State.Skill;
                return;
            }
        }

        // 이동
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            State = Define.State.Idle;
        }
        else
        {
            NavMeshAgent nma = gameObject.GetOrAddComponent<NavMeshAgent>();
            nma.SetDestination(_destPos);
            nma.speed = _stat.MoveSpeed;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10.0f * Time.deltaTime);
        }
    }

    protected override void UpdateSkill()
    {
        if (_lockTartget != null)
        {
            Vector3 dir = _lockTartget.transform.position - transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
        }
    }

    void OnHitEvent()
    {
        if (_lockTartget != null)
        {
            Stat targetStat = _lockTartget.GetComponent<Stat>();
            int damage = Mathf.Abs(_stat.Attack - targetStat.Defence);
            targetStat.Hp -= damage;

            if (targetStat.Hp <= 0)
            {
                GameObject.Destroy(targetStat.gameObject);
            }
        }
    }

    void EndHitEvent()
    {
        Stat targetStat = _lockTartget.GetComponent<Stat>();
        if (targetStat.Hp > 0)
        {
            float distance = (_lockTartget.transform.position - transform.position).magnitude;
            if (distance <= _attackRange)
                State = Define.State.Skill;
            else
                State = Define.State.Moving;
        }
        else
            State = Define.State.Idle;
    }
}
