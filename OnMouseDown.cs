// 벽을 클릭하면 UI 창이 뜨는 스크립트
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOnClick : MonoBehaviour
{
    public GameObject popup;
    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
    }    
    
    void OnMouseDown() {
        // TvUI랑 겹치지 않게
        // TvUI를 찾을 수 없다. --> 비활성화된 상태 --> 그럼 PaperingUI 띄워도 됨
        // TvUI를 찾을 수 있다. --> 이미 띄워져있는 상태 --> 그럼 PaperingUI 띄우면 안됨
        if(!GameObject.Find("Canvas (1)")){ 
            popup.SetActive(true);
        }
    }
}
