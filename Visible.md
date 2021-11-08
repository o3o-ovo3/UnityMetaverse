### [오브젝트를 화면에서 감추는 두가지 방법]

1. 오브젝트의 화면 표시 금지

   - 오브젝트.renderer.enabled = false; 메소드 활용
   - 오브젝트를 아예 화면에 그리지 않도록 하는 방법

   ```csharp
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   
   public class Visb : MonoBehaviour
   {
       public GameObject cube;
       // Use this for initialization
       void Start () {
   
       }
   		
   		// n 키를 누르면 사라지기, m 키를 누르면 나타나기
       // Update is called once per frame
       void Update () {
           if(Input.GetKeyDown("n"))
           {
               cube.GetComponent<Renderer>().enabled = false;
           }
           else if(Input.GetKeyDown("m"))
           {
               cube.GetComponent<Renderer>().enabled = true;
           }
       }
   }
   ```

   <br/>

   

2. 오브젝트 비활성화

   - 오브젝트.SetActive(false); 메소드 이용
   - Inspector에서 오브젝트 이름 옆에 있는 체크박스를 해제하는 것과 같이 화면에서 일시적으로 사라지게 하는 것
