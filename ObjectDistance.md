# Unity 3D - 오브젝트 간 거리를 계산하는 방법 3가지

1. Vector3.Distance
    - 정확한 거리를 계산해 반환한다.
    - Vector3.sqrMagnitude 보다 속도가 느리다.
    
2. Vector3.magnitude
    - Vetor3.Distance와 성능과 기능이 동일하다.
    - 3축 사이의 정확한 거리를 계산해 Vector3 타입으로 반환한다.
    
3. Vector3.sqrMagnitude
    - 위의 두 방식과는 다르게, 제곱 값을 루트 계산 없이 그대로 반환한다.
    - 정확한 거리는 측정할 수 없다.
        - 두 벡터 사이에 무엇이 더 크고 작은 지 판단하기 위한 용도
        - 대략적인 거리를 파악하기 위해 사용


### 📑Reference
https://arainablog.tistory.com/214
