// LayerMask를 사용하여 특정 Layer에만 Raycast 사용하기

LayerMask layerMask;

void Start()
{
  layerMask = LayerMask.NameToLayer("UI"); // Raycast의 대상인 Layer
}

void Update()
{
  RaycastHit hit;
  if(Physics.Raycast(ray, out hit, 100.0f, layerMask)) // 해당 Layer를 가진 오브젝트들에 대해서만 Raycasting 진행
  {
    // 기능 구현
  }
}

// reference : https://ansohxxn.github.io/unitydocs/layermask/
