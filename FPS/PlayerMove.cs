    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    // 1. 사용자의 입력에 따라 앞뒤좌우로 이동하고 싶다.
    // 필요 속성 : 이동 속도, CharacterController 라는 컴포넌트

    // 2. 중력이 적용되도록 하고싶다.
    // 필요 속성 : 중력, 수직 속도 성분

    // 3. 사용자가 점프버튼을 누르면 점프를 하고 싶다.
    // 필요 속성 : 점프 파워
    // - Mission : 2단 점프까지만 하고 싶다.
    // 필요 속성 : 현재 점프 갯수, 최대 점프 갯수

    public class PlayerMove : MonoBehaviour
    {
        // 필요 속성 : 이동 속도, CharacterController 라는 컴포넌트
        public float speed = 5;
        CharacterController cc; // 물리적 처리

        // 필요 속성 : 중력, 수직 속도 성분
        public float gravity = -20; // 그냥 20으로 하면 하늘로 날아감
        float yVelocity = 0;

        // 필요 속성 : 점프 파워
        public float jumpPower = 10;
        // 필요 속성 : 현재 점프 갯수, 최대 점프 갯수
        int jumpCount = 0;
        public int maxJumpCount = 2;

        // Start is called before the first frame update
        void Start()
        {
            // 객체의 메모리를 미리 참조해놓고 계속 사용한다. (캐싱기법)
            cc = GetComponent<CharacterController>();
        }

        // Update is called once per frame
        void Update()
        {
            // 사용자의 입력에 따라 앞뒤좌우로 이동하고 싶다.
            // 1. 사용자의 입력에 따라
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            // 2. 방향이 필요
            Vector3 dir = new Vector3(h, 0, v); // y 방향에 값이 없어서 중력이 적용되지 않음 --> 밑에 v에 대한 값에 중력에 대한 내용이 추가되어야 함
            // 카메라가 향하는 방향으로 변환
            dir = Camera.main.transform.TransformDirection(dir); // 씬에서 메인 카메라를 찾아주고 카메라가 보는 방향으로의 dir방향으로 변환해줘
            // 즉, dir이 앞으로 였다면, 카메라의 방향에서(앞으로) 라는 뜻

            // v = v0 + at --> 여기서 a가 중력 가속도
            
            // 바닥에 닿아있을 때 수직 속도를 0으로 해야한다. --> yVelocity가 누적되지 않게 하기 위해
            // if(cc.isGrounded) // isGrounded -> 바닥에 닿아있는가
            if(cc.collisionFlags == CollisionFlags.Below) // 윗줄과 같은 말
            {
                yVelocity = 0;
                jumpCount = 0;
            }

            // 3. 사용자가 점프 버튼을 누르면 점프하고 싶다.
            if (Input.GetButtonDown("Jump")) {
                // - Mission : 2단 점프까지만 하고 싶다.
                if (jumpCount < maxJumpCount)
                {
                    jumpCount++;
                    yVelocity = jumpPower;
                }
            }

            yVelocity += gravity * Time.deltaTime;
            dir.y = yVelocity;

            // 3. 이동하고 싶다. P = P0 + vt , P = P0 까지는 cc가 해줌 (캐릭터 충돌 처리까지)
            cc.Move(dir * speed * Time.deltaTime);
        }
    }
