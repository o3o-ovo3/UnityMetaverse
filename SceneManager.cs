// 화면 전환 스크립트
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalIn : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(this.gameObject.name == "Portal" && other.gameObject.tag == "Player"){
            // 플레이어가 포탈에 접근하면
            Debug.Log("Enter");
            SceneManager.LoadScene("MainScene"); // MainScene으로 화면 전환
        } 
        else if(this.gameObject.name == "Portal1" && other.gameObject.tag == "Player"){
            Debug.Log("Enter");
            SceneManager.LoadScene("Apartment"); // Apartment로 화면 전환
        }
    }
}
