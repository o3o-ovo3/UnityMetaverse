// transform.LookAt() : 오브젝트의 바라보는 방향을 타겟을 향하도록 바꿔주는 메소드

// 원하는 것 : 특정 오브젝트 (플레이어)가 타겟 오브젝트(레이저)를 바라볼 수 있게 방향을 바꾸고 싶다.
// 주의할 점 : 그냥 LookAt을 사용하면 y축도 같이 움직여서 플레이어가 하늘을 쳐다본다. --> y축은 사용하지 않고 x, z 축만 바꿀 수 있도록 한다.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour
{
    public GameObject Player;
    public GameObject Laser;
    Vector3 PlayerRot;
    
    void Update()
    {
      // 레이저 쏘는 방향으로 플레이어의 방향을 바꾸기 위함 --> x, z 축만 사용
                                                            // 플레이어 자신의 y축 사용
      PlayerRot = new Vector3(Laser.transform.position.x, Player.transform.position.y, Laser.transform.position.z);
      Player.transform.LookAt(PlayerRot);
    }
}
