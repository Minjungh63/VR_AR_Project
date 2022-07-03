using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    // 복셀이 날아갈 속도 속성
    public float speed = 5;
    // 복셀을 제거할 시간
    public float destroyTime = 3.0f;
    // 경과 시간
    float currentTime;

    void onEnable()
    {
        currentTime = 0;
        // 랜덤한 방향을 찾음
        Vector3 direction = Random.insideUnitSphere;
        // 랜덤한 방향으로 날아가는 속도를 줌
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        // 제거 시간이 되면 복셀을 제거
        if(currentTime > destroyTime)
            Destroy(gameObject);
    }
}
