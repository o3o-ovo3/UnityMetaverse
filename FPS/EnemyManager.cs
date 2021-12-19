using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//  랜덤시간에 한 번씩 랜덤한 위치에서 적이 생성되도록 하고싶다.
//  필요속성 : 랜덤시간 간격, spawn 될 위치들
public class EnemyManager : MonoBehaviour
{
    //  필요속성 : 랜덤시간 간격, spawn 될 위치들
    public float minTime = 0.5f;
    public float maxTime = 3.5f;
    float createTime = 0;

    public Transform[] spawnPoints;
    public GameObject enemyFactory;
    void Start()
    {
        //  랜덤시간에 한 번씩 랜덤한 위치에서 적이 생성되도록 하고싶다.
        //  1. 랜덤한 시간을 구해야 한다.
        createTime = Random.Range(minTime, maxTime);

        Invoke("CreateEnemy", createTime);  //자신이 설정한 시간만큼 함수 시작 시간을 지연
    }

    void CreateEnemy()
    {
        //  2. 랜덤 시간이 됐으니까
        //  3. 랜덤한 위치
        int index = Random.Range(0, spawnPoints.Length);
        Vector3 pos = spawnPoints[index].position;
        //  4. 적이 생성되도록 하고 싶다.
        GameObject enemy = Instantiate(enemyFactory);
        enemy.transform.position = pos;

        //  재귀호출
        createTime = Random.Range(minTime, maxTime);

        Invoke("CreateEnemy", createTime);  //자신이 설정한 시간만큼 함수 시작 시간을 지연
    }
}
