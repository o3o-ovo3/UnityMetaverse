using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateAvatar : MonoBehaviour
{
    string      avatarGender;
    string      avatarName;
    GameObject  avatarManager;
    public GameObject  avatar;

    // 씬 이동 저장을 위한 변수
    public string prevScene;
    public string thisScene;

    /*
    void Awake()
    {
        //다른 스크립트 파일의 변수 접근 법
        // GameObject.Find("다른 스크립트 파일이 들어있는 오브젝트")
        avatarManager = GameObject.Find("GameObject");
        avatarGender = avatarManager.GetComponent<ChangeScene>().genderButton;
        avatarName = avatarManager.GetComponent<ChangeScene>().name;
        Debug.Log(avatarName);
        GameObject childName = transform.Find("Name").gameObject;
        childName.GetComponent<TextMesh>().text = avatarName;
        childName.GetComponent<TextMesh>().characterSize = .5f;
    }

    // Update is called once per frame
    void Start()
    {
        if (avatarGender == "Male")
        {
            Debug.Log("여자 캐릭터를 가린다");
            avatar.SetActive(false);
        }
        else if (avatarGender == "Female")
        {
            Debug.Log("남자 캐릭터를 가린다");
            avatar.SetActive(true);
        }

    }*/
    
    void Update(){
        // 씬 전환
        string newScene = SceneManager.GetActiveScene().name;

        if(thisScene != newScene){
            prevScene = thisScene;
            thisScene = newScene;
         
            if(prevScene == "Apartment" && thisScene == "MainScene")
            {
                GameObject target = GameObject.Find("TargetPosition1");
                this.transform.position = target.transform.position;
            }
            else if(prevScene == "40Apartment" && thisScene == "MainScene")
            {
                GameObject target = GameObject.Find("TargetPosition2");
                this.transform.position = target.transform.position;
            }
            /*
            else if(prevScene == "LoginScene" && thisScene == "MainScene"){
                GameObject target = GameObject.Find("StartPoint");
                this.transform.position = target.transform.position;
            }
            */
            else {
                if(thisScene != "LoginScene"){
                    GameObject target = GameObject.Find("StartPoint");
                    this.transform.position = target.transform.position;
                }
            }
        }
    }
}
