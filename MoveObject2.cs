// 사용자 입력에 따라 오브젝트 이동

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // 필요 속성 : 이동 속도
    public float speed = 5; // 접근 제한자를 public으로 주면 Unity 상에서 속성을 수정할 수 있다.

    // Update is called once per frame
    void Update()
    {
        // 사용자의 입력에 따라 상하좌우로 이동하고 싶다.
        // 1. 사용자의 입력에 따라
        float h = Input.GetAxis("Horizontal"); // 좌우
        float v = Input.GetAxis("Vertical"); // 상하

        // 2. 방향이 필요하다.
        Vector3 dir = Vector3.right * h + Vector3.up * v; // 아무것도 안 누르면 0, 오른쪽 또는 위는 1, 왼쪽 또는 아래 -1

        // 3. 이동하고 싶다.
        Vector3 p0 = transform.position; // 현재 나의 위치
        Vector3 vt = dir * speed * Time.deltaTime; // 방향 자리에 dir을 넣어준다.
        Vector3 p = p0 + vt; // 현재 나의 위치 + vector * delataTime = 내가 도달할 위치
        transform.position = p; // 나의 위치를 p로 업데이트

        if (Input.GetKeyDown("x")) // x를 누를 때 마다 속도를 5씩 올리기
            speed = speed + 5;
    }
}
