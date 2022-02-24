## Unity 3D - 씬 전환 후 원하는 위치에 Player 놓기

1. 빈 오브젝트로 Target 만들기
2. 어떤 씬에서 전환 되었느냐에 따라 Player의 위치를 바꾸기 (즉, 여러개 중 원하는 Target 선택) 
    - 이전 씬에 대한 정보를 받아오기 → 여러 씬을 계속 돌아다니는 Object에 정보를 저장 (DontDestroyOnLoad가 되어있는 객체)
    - 어떤 문에서 나왔냐에 따라 위치 조정하기
      - 씬 전환 때마다 Player에 씬에 대한 정보 저장 → Player에 붙인 스크립트
      ``` C#
      void Update(){
        // 씬에 대한 정보 저장
        string newScene = SceneManager.GetActiveScene().name;

        if(thisScene != newScene){
            prevScene = thisScene;
            thisScene = newScene;   
        }
        
				// 이전 씬을 판별하여 Player의 위치 조정
        void Update(){
        // 씬 전환
        string newScene = SceneManager.GetActiveScene().name;

        if(thisScene != newScene){
            prevScene = thisScene;
            thisScene = newScene;  
						
						// 원하는 조건이 되었을 경우
            if(prevScene == "Apartment" && thisScene == "MainScene")
            { // 타겟 포지션으로 이동
                GameObject target = GameObject.Find("TargetPosition");
                this.transform.position = target.transform.position;
            }
        }
    }
    }
