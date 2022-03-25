// GetChild 메소드를 사용하지 않고 자식 전부 가져오기

foreach (Transform child in transform) // Transform 대신 GameObject 등 사용해도 됨
{ // foreach를 돌면서 자식 전부를 찾아줌
    Debug.Log(child.transform.name);
}
