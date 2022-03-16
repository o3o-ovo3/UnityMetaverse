// Raycast 사용 시 특정 컴포넌트를 통과하고 싶을 때
// 컴포넌트에 IsTrigger 속성을 on 한다.
                                                          // 이 API가 trigger를 무시하는 역할을 한다.
Physics.Raycast(ray, out hit, 1000.0f, _LayerMask.value, QueryTriggerInteraction.Ignore)
