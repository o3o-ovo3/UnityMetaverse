using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자의 입력에 따라 물체를 회전하고 싶다.
// 필요 속성 : 회전 속도, 

public class CamRotate : MonoBehaviour
{
    // 필요 속성 : 회전 속도
    [SerializeField] // dll 형태로 컴파일되어서 유니티에 올려지는데
                     // 이렇게 하면 private 이어도 editor에 보여진다.
                     // 실행중에 속성이 수정되어도 스크립트 상에서 변경되지 않는다.
    private float rotSpeed = 200; // 사용자가 수정할 수 있도록 public

    // 내부적으로 각도가 -가 될 때 360도를 더해버리기 때문에 이 문제를 해결하기 위해
    // 직접 각도를 가지고 있는다.
    float mx;
    float my;

    private void Awake()
    {
        // 라이프 사이클 최상단으로 Start 전에 실행됨
        // 메모리에 적재되는 순간임
        // 리소스 로드를 여기서 해야함
    }

    // Start is called before the first frame update
    void Start()
    {
        // 활동을 하기 위해 태어나기 직전의 순간 -> 필요한 리소스는 이미 준비되어있어야함 (Awake에서)
    }

    // Update is called once per frame
    void Update()
    {
        // 사용자의 입력에 따라 물체를 회전하고 싶다.
        // 1. 사용자의 입력에 따라
        float h = Input.GetAxis("Mouse X"); // 움직일 때는 Horizontal , 마우스로 입력 받을 때는 Mouse X
        float v = Input.GetAxis("Mouse Y"); // 수직에 대한 마우스 입력
        mx += h * rotSpeed * Time.deltaTime;
        my += v * rotSpeed * Time.deltaTime; // 각도를 저장

        // 360도 넹글 돌아버리는 걸 원치 않으면 경계를 설정해버린다
        my = Mathf.Clamp(my, -90, 90); // my값이 -60에서 60 안으로 잘려버림

        // 2. 방향이 필요
        // Vector3 dir = new Vector3(h, v); // 상하좌우 회전만 하니까 x, y만 입력한다.
        // Vector3 dir = new Vector3(v, h, 0); // 마우스의 좌우 값, 즉 x 값이 회전축 y축에 해당해야하기 때문에
        // Vector3 dir = new Vector3(-v, h, 0); // 마우스가 위로 가면 위를 보게 하고 싶어서
        Vector3 dir = new Vector3(-my, mx, 0); // 마우스가 위로 가면 위를 보게 하고 싶어서

        // 3. 물체를 회전하고 싶다.
        // Transform 컴포넌트에 접근해야 회전을 시킬 수 있다.
        //             P = P0                 v                t    
        // transform.eulerAngles += dir * rotSpeed * Time.deltaTime; // 오일러 앵글 -> P = P0 + vt // 오일러에 직접 누적했더니 각도가 빙글 돌아버림
        transform.eulerAngles = dir; // 누적된 값을 내가 갖고 오일러에 대입만 해줌 --> 이렇게 하면 360도 빙글빙글 돌 수 있다. -> 위에서 Clamp로 잘라서 진짜로 돌진 않음
    }
}
