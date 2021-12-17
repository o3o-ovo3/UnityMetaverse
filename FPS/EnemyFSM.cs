using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 1. Enemy의 상태를 처리할 구조를 작성
// 대기, 이동, 공격, 피격, 죽음
public class EnemyFSM : MonoBehaviour
{
    enum EnemyState // 열거형 자료형
    {
        Idle,
        Move,
        Attack,
        Damage,
        Die
    };

    EnemyState m_state; // 상태를 관리
    CharacterController cc;

    // Animator Component
    Animator anim;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        m_state = EnemyState.Idle; // 초기값 설정 --> 대기 상태
        cc = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();

        while (Application.isPlaying)
        {
            yield return StartCoroutine(m_state.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        print("현재 상태 : " + m_state);
        // 목차 구성
        switch (m_state)
        {
            case EnemyState.Idle:
                // Idle();
                break;

            case EnemyState.Move:
                Move();
                break;

            case EnemyState.Attack:
                Attack();
                break;

            case EnemyState.Damage:
                // Damage();
                break;

            case EnemyState.Die:
                // Die();
                break;
        }
    }

    // 일정 시간이 지나면 상태를 Move로 전환
    // 필요 속성 : 대기 시간, 경과 시간
    public float idleDelayTime = 2;
    float currentTime = 0;
    private IEnumerator Idle()
    {
        yield return new WaitForSeconds(idleDelayTime);

        // 3. 상태룰 move로 전환
        m_state = EnemyState.Move;
        // 애니메이션의 상태도 Move로 전환
        anim.SetTrigger("Move");
        currentTime = 0;

    }

    // 타겟 방향으로 이동하고 싶다.
    // 필요 속성 : 이동 속도, 타겟
    public float speed = 5;
    public Transform target; // GameObject로 하지 않은 이유는 걔의 position만 필요하기 때문임
                             // Vector3로 하지 않은 이유는 참조 타입이 아니라서 계속 업데이트가 안되기 때문임, 얘는 됨

    // 공격 범위 안에 타겟이 들어오면 상태를 Attack으로 전환하고 싶다.
    // 필요 속성 : 공격 범위
    public float attackRange = 2;

    private IEnumerator Move()
    {
        // 타겟 방향으로 이동하고 싶다.
        // 1. 방향이 필요 --> 구한다.
        Vector3 dir = target.position - transform.position; // 벡터 화살표는 Target의 포지션 - 나의 포지션으로 구한다.
        float distance = dir.magnitude;

        // 공격범위 안에 타겟이 들어오면 상태를 Attack으로 전환
        if(distance < attackRange)
        {
            m_state = EnemyState.Attack;
            currentTime = attackDelayTime; // 바로 공격할 수 있도록 경과 시간 = 공격 시간으로
            yield break; // 코루틴 강제 종료 (일반 함수에서 return 과 같음)
        }
        dir.y = 0; // 타겟의 중심점이 위에 있어도 위로 올라가지 않도록
        dir.Normalize(); // 방향만 남게
        // 2. 이동하고 싶다.
        // P = P0 + vt
        cc.SimpleMove(dir * speed); // SimpleMove는 뭐하는 메소드, Time은 알아서 넣어줌

        // 이동하는 방향으로 회전하고 싶다.
        // transform.LookAt(target); // target 방향을 바라봄
        // transform.forward = dir; // 윗줄과 같음
        // 부드럽게 회전하도록 하자
        // transform.forward = Vector3.Lerp(transform.forward, dir, 10 * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(dir), 10 * Time.deltaTime); 
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange); // 공격 범위를 구체 형태로 표현해줌
    }

    // 1. 타겟이 공격 범위를 벗어나면 상태를 Move로 전환

    // 2. 일정 시간에 한번씩 공격하고 싶다.
    // 필요 속성 : 공격 대기 시간
    float attackDelayTime = 2;
    private void Attack()
    {
        //  일정시간에 한번씩 공격하고 싶다.
        currentTime += Time.deltaTime;
        if (currentTime > attackDelayTime)
        {
            currentTime = 0;
            print("공격!!!!!!");
            anim.SetTrigger("Attack");
        }

        float distance = Vector3.Distance(transform.position, target.position);    // 둘사이의 거리 구할때 -말고 다른방법
        if (distance > attackRange)
        {
            m_state = EnemyState.Move;
            anim.SetTrigger("Move");
        }
    }


    // 일정 시간이 지나면 상태를 Idle로 전환
    public float damageDelayTime = 2;

    // Damage 함수를 코루틴을 만들고 싶다.
    private IEnumerator Damage() // 코루틴이 리턴해줘야하는 타입 IEnumerator
    {
        // 1. 상태를 Damage로 전환
        m_state = EnemyState.Damage;

        // 2. 애니메이션 Damage 상태로 전환
        anim.SetTrigger("Damage");

        // 3. 잠시 기다리기
        yield return new WaitForSeconds(damageDelayTime); // 여기서 잠깐(damageDelayTime 만큼) 기다렸다가 다음 줄을 실행 --> 아래 코드와 똑같아짐 
        
        // 4. 기다린 다음 상태를 Idle로 전환
        m_state = EnemyState.Idle;
        /*
        currentTime += Time.deltaTime;
        if(currentTime > damageDelayTime)
        {
            currentTime = 0;
            m_state = EnemyState.Idle;
        }
        */
    } // 자동으로 코루틴 종료

    // 어떤 상태에서든 피격 상태로 전환될 수 있기 때문에 이벤트 형식으로 --> 어디선가에서는 호출이 되어야함 (PlayerFire)
    // 피격 당했을 때 호출되는 함수
    // HP 를 갖도록 하고싶다.
    int hp = 3;
    // 만약 hp 가 0 이하면 죽이고
    // 그렇지 않으면 상태를 Idle로 전환 (Damage에서 Idle로)
    public void OnDamageProcess()
    {
        // 이미 상태가 Die 이면 호출되지 않도록 하자 --> 죽었는데 또 쏘지 말라 이거야~!
        if(m_state == EnemyState.Die)
        {
            return;
        }
        hp--;
        currentTime = 0;

        StopAllCoroutines();
        // StopCoroutine("Damage");

        if (hp <= 0)
        {
            StartCoroutine("Die"); // 함수 실행이 아니라 코루틴을 등록 --> 별도의 (병렬로 동작하는) 루틴이 발생 --> 각자의 흐름대로 계속 가는거야
            print("205"); // 윗줄 실행되자마자 바로 찍힘, Enemy가 사라지고 난 후가 아니라 바로 동작 --> 병렬로 동작되고 있기 때문에
        }
        else
        {

            // 코루틴 시작(등록)
            // StartCoroutine(Damage());//
            StartCoroutine("Damage"); // 결과는 같음
        }
    }

    // 아래로 계속 내려가다가 안보이면 제거시켜주자
    // 필요 속성 : 죽을 때 속도, 사라질 위치
    public float dieSpeed = 0.5f;
    public float dieYPosition = -2;
    private IEnumerator Die()  
    {
        m_state = EnemyState.Die;
        anim.SetTrigger("Die");
        // 충돌체 정지시키자
        cc.enabled = false; // CharacterController를 꺼버림

        yield return new WaitForSeconds(2);
        while (transform.position.y > dieYPosition)
        {
            transform.position += Vector3.down * dieSpeed * Time.deltaTime;
            yield return null; // deltaTime 만큼 (1/60초) 기다려줌 // WaitForEndOfFrame() 이거랑 같음ㄴ
        }
        Destroy(gameObject);
        /*
        // 일정 시간 기다렸다가
        currentTime += Time.deltaTime;
        if(currentTime > 2)
        {
            // 아래로 가라앉도록 하자
            // P = P0 + vt
            transform.position += Vector3.down * dieSpeed * Time.deltaTime;
            if (transform.position.y < dieYPosition)
            {
                Destroy(gameObject);
            }
        }
        */
    }
}
