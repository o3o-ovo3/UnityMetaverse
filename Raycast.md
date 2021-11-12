# Unity 3D - 특정 오브젝트 클릭 이벤트 (Raycast)

+) 참고

## Raycast

- 레이캐스트는 광선을 쏘는 것을 의미한다.
- 광선에 충돌되는 콜라이더에 대한 거리, 위치 등 자세한 정보를 RaycastHit 으로 반환한다.
    - 충돌되는 콜라이더를 반환
    - 따라서 오브젝트에 콜라이더가 존재해야 한다.
    
- 대표적인 레이캐스트 함수
    1. Physics.Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo)
        
        → 시작점 (origin)과 방향(direction)으로 레이를 쏘는 함수
        
        → 시작점과 방향으로 모든 충돌체에 대해 레이를 쏜다.
        
        → 충돌이 되면 true를 반환하고 RaycastHit로 충돌정보를 넘긴다.
        
    2. Physics.Raycast(Vector3 origin, Vector3 direction, out RaycastHit hitInfo, float maxDistance)
        
        → 시작점과 방향으로 최대거리(maxDistance) 만큼 레이를 쏘는 함수
        
        → 최대거리 안에서 충돌이 되면 true를 반환하고 RaycastHit로 충돌정보를 넘겨준다.
        

## Raycast를 이용하여 특정 오브젝트 클릭 시 이벤트 발생 스크립트

```csharp
// TV 오브젝트를 클릭하면 UI 팝업창이 뜨는 스크립트

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvOnClick : MonoBehaviour
{
    // 클릭 이벤트로 생성될 객체
    public GameObject popup;

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false); // 초기화 시 팝업창이 안 보이게 비활성화
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼 눌렀을 때
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();

            if(true == (Physics.Raycast(ray.origin, ray.direction * 10, out hit)))
            {
                popup.SetActive(true);
            }
        }
    }
}
```
