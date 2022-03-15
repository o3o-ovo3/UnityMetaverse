// 기존 방식 -> 포인터 (몸체)가 마우스를 따라다니게 한다. --> 초점이 안맞고 마우스 움직임과 차이가 있음
// 새로운 방식 -> 마우스가 있는 지점에 레이캐스트를 쏜다. --> 이 지점은 ScreenToPoint로 표현한다.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    private Camera MainCamera;

    public GameObject laser; // 레이저
    private LineRenderer lr; // 레이저의 라인렌더러 컴포넌트
    public GameObject dot; // 레이저가 다은 지점 표현

    void Start()
    {
        lr = laser.GetComponent<LineRenderer>();    
        lr.SetPosition(0, lr.transform.position);
        MainCamera = Camera.main;
    }

    void Update()
    {
        lr.enabled = false;
        dot.SetActive(false);

        RaycastHit hit;
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition); // 마우스 방향으로 레이를 쏜다
        if(Physics.Raycast(ray, out hit, 1000.0f))
        {
            if(hit.collider.tag == "UI")
            {
                transform.LookAt(hit.point); // 마우스가 가리키는 곳을 향해 몸체가 움직일 수 있도록 한다.
                lr.SetPosition(1, hit.point); // index 1 -> 꼬리
                lr.enabled = true; // 레이저 나오게
                dot.SetActive(true); // 닿은 점이 보이게

                // dot의 위치는 포인터의 끝점 (닿은 곳)
                dot.transform.position = hit.point;
            }
        }
        else lr.SetPosition(1, transform.forward*500);
    }
}
