// 오브젝트를 이동하는 방법
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    void Update()
    {
        // 물체를 오른쪽으로 계속 이동하게 하고 싶다.
        transform.Translate(Vector3.right * 5 * Time.deltaTime);

        // 물체를 위로 계속 이동하게 하고 싶다. 
        transform.Translate(Vector3.up * 5 * Time.deltaTime);

        // 위의 두 코드를 합치면 대각선 위로 움직이게 된다.
        // transform.Translate(Vector3.right * 5 * Time.deltaTime + Vector3.up * 5 * Time.deltaTime); // 이거와 같다
        // Translate은 방향을 바꾸는 역할을 한다.
        // transform의 컴포넌트에
    }
}
