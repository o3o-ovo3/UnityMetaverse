using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvOnClick : MonoBehaviour
{
    public GameObject popup;

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
    }

    void OnMouseDown() {
        // PaperingUI 겹치지 않게
        // PaperingUI를 찾을 수 없다. --> 비활성화된 상태 --> 그럼 TvUI 띄워도 됨
        // PaperingUI를 찾을 수 있다. --> 이미 띄워져있는 상태 --> 그럼 TvUI 띄우면 안됨
        // if(popup.activeSelf == false) --> activeSelf는 활성화 상태인지, 비활성화 상태인지를 구분
        if(!GameObject.Find("PaperingUI"))
            popup.SetActive(true);
    }
}
