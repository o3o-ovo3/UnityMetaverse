1. 오브젝트 위치 이동
    
    ```csharp
    void Update()
        {
            // 물체를 오른쪽으로 계속 이동하게 하고 싶다.
            transform.Translate(Vector3.right * 5 * Time.deltaTime);
    
            // 물체를 위로 계속 이동하게 하고 싶다. -> 위의 코드와 합치면 대각선 위로 움직이게 된다.
            transform.Translate(Vector3.up * 5 * Time.deltaTime);
    
            // 즉,
            // transform.Translate(Vector3.right * 5 * Time.deltaTime + Vector3.up * 5 * Time.deltaTime); // 이거와 같다
            // Translate은 방향을 바꾸는 역할을 한다.
            // transform의 컴포넌트에
    		}
    ```
    
2. 위의 코드에서 P = P0 + vt 공식을 적용해서 다시 생각해보기
    
    ```csharp
    void Update()
        {
            // P (position) = P0 + vt 등속 운동.. --> 요기서 v가 vector t는 deltaTime
            Vector3 p0 = transform.position; // 현재 나의 위치
            Vector3 vt = Vector3.right * 5 * Time.deltaTime;
            Vector3 p = p0 + vt; // 현재 나의 위치 + vector * delataTime = 내가 도달할 위치
            transform.position = p; // 나의 위치를 p로 업데이트
    		}
    ```
    
3. 사용자 입력을 받아서 움직이기
    
    ```csharp
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    // 사용자의 입력에 따라 상하좌우로 이동하고 싶다.
    public class PlayerMove : MonoBehaviour
    {
        // 필요 속성 : 이동 속도
        public float speed = 5;// 접근 제한자를 public으로 주면 Unity 상에서 속성을 수정할 수 있다.
    
        void Update()
        {
            // 사용자의 입력에 따라 상하좌우로 이동하고 싶다.
            // 1. 사용자의 입력에 따라
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
    
            // 2. 방향이 필요하다.
            Vector3 dir = Vector3.right * h + Vector3.up * v; // 아무것도 안 누르면 0, 오른쪽 또는 위 키를 눌렀으면 1, 왼쪽 또는 아래 키를 눌렀으면 -1
    
            // 3. 이동하고 싶다.
            Vector3 p0 = transform.position; // 현재 나의 위치
            Vector3 vt = dir * speed * Time.deltaTime; // 방향 자리에 dir을 넣어준다.
            Vector3 p = p0 + vt; // 현재 나의 위치 + vector * delataTime = 내가 도달할 위치
            transform.position = p; // 나의 위치를 p로 업데이트
        }
    }
    ```
