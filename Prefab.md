## [특정 GameObject를 다른 프로젝트 / 다른 씬에 Import]

1. FBXExporter를 이용
    1. Window 창 → Package Manager → Unity Registry → FBXExporter 을 Install
    2. 원하는 GameObject 마우스 오른쪽 버튼 클릭 → Export To FBX
    3. Export된 fbx 파일을 다른 프로젝트에 import
    
    \* 이 경우 GameObject에 설정된 Texture, Script, Animation은 같이 딸려오지 않기 때문에 후에 설정이 필요
    
2. UnityPackage로 추출
    1. Project의 Asset에서 마우스 오른쪽 버튼 클릭 → Export Package
    2. 추출된 Package를 원하는 프로젝트에 import
    
    \* 이 경우도 원하는 만큼 잘 작동하지 않는 것 같다.
    
3. 해당 프로젝트의 Assets 폴더를 다른 이름으로 바꾸어 Import하려는 프로젝트에 추가
    1. 예를 들어, 애니메이션 등이 지정되어 있는 아바타를 다른 프로젝트에 넣고 싶으면
    2. 아바타가 있는 프로젝트의 Assets 폴더를 avatAssets로 이름을 바꾸고
    3. 원하는 프로젝트에 폴더 추가
    4. avatAssets 안에 있는 Scene을 켜서 아바타 오브젝트를 복사하고
    5. 원하는 Scene에 붙여 넣기하면 끝!
    
🖍 참고 )
- 다른 씬에 GameObject를 옮기는 방법
  - Hierarchy에서 원하는 GameObject를 드래그해서 프로젝트로 당기기 → Prefab 형식으로 추출할 수 있음
  - 이 방법이 다른 씬이 아니라 다른 프로젝트에도 통하는지는 잘 모르겠음 ! 
