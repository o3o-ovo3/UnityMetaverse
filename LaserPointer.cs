// 레이저 포인터 만들기
// Pointer, Laser, Dot 필요

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    private LineRenderer lr;
    private float speed = 3f;

    public GameObject laser;
    public GameObject dot;

    float mx;
    float my;
    // public GameObject point;

    // Start is called before the first frame update
    void Start()
    {
        dot.SetActive(false);
        lr = laser.GetComponent<LineRenderer>();    
        lr.SetPosition(0, lr.transform.position);
        // point.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        lr.enabled = false;
        dot.SetActive(false);

        // lr.SetPosition(0, transform.position+ new Vector3(0, 0.5f, 0));
        lr.SetPosition(0, lr.transform.position);
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider.tag == "UI")
            {
                lr.enabled = true;
                lr.SetPosition(1, hit.point); // index 1 -> 꼬리
                dot.SetActive(true);

                // dot의 위치는 포인터의 끝점 (닿은 곳)
                dot.transform.position = hit.point;
                // dot를 부딪힌 오브젝트가 바라보고 있는 방향으로 회전
                // Vector3 dir = hit.collider.transform.position - dot.transform.position;
                Vector3 dir = hit.collider.gameObject.transform.forward;
                dir.y = 0f;
                Quaternion rot = Quaternion.LookRotation(dir.normalized);
                dot.transform.rotation = rot;
                

                // 2번
                // dot.transform.localEulerAngles = new Vector3(0, hit.collider.transform.localEulerAngles.y, 0);
            }
        }
        else lr.SetPosition(1, transform.forward*500);

        transform.Rotate(0f, Input.GetAxis("Mouse X") * speed, 0f, Space.World);
        transform.Rotate(-Input.GetAxis("Mouse Y") * speed, 0f, 0f, Space.World);
    }
}
