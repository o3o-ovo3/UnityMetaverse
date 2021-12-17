using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 사용자가 발사 버튼을 누르면 총을 발사하고 싶다.
// 필요 속성 : 총구(카메라) --> 이게 FPS 게임의 조준점
public class PlayerFire : MonoBehaviour
{
    // 필요 속성 : 파편 이펙트
    public GameObject bulletEffectFactory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 사용자가 발사 버튼을 누르면 총을 발사하고 싶다.
        // 1. 사용자가 발사 버튼을 눌렀으니까
        if (Input.GetButtonDown("Fire1"))
        {
            // 2. 총을 발사하고 싶다.
            // -1) Ray 가 필요하다.
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward); // Ray의 인자값으로는 시선의 시작점, Ray가 향하는 방향
            RaycastHit hitInfo;

            // 내가 맞추고 싶은 녀석만 맞추도록 하고싶다.
            int layer = gameObject.layer; // 자기자신의 layer를 가져옴
            layer = 1 << layer; // 비트 연산자 사용 layer의 개수만큼 밀어둔다.

            // -2) Ray를 던져야 한다.                      //거리  // 검출하고 싶은레이어 --> ~를 넣으면 걔만 빼고!
            bool result = Physics.Raycast(ray, out hitInfo, 100, ~layer); // 던져서 부딪혔는지 검출

            // -3) Ray가 닿은 지점에 파편을 튀게하고싶다.
            if (result)
            {
                // 파편을 공장에서 만든다.
                GameObject bulletEffect = Instantiate(bulletEffectFactory);

                // 파편을 위치시킨다.
                bulletEffect.transform.position = hitInfo.point;

                // 부딪힌 녀석이 Enemy이면 피격 알림을 준다.
                // 이름, 태그, 레이어를 통해서 판별할 수 있다.
                // EnemyFSM 스크립트 컴포넌트를 EnemyFSM이라는 클래스에 담아옴
                EnemyFSM enemy = hitInfo.transform.GetComponent<EnemyFSM>();

                if (enemy) // enemy가 null이 아니면
                {
                    enemy.OnDamageProcess(); // 함수 호출
                }
            }
        }
    }
}
