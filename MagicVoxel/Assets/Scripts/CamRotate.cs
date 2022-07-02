using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 마우스 입력에 따라 카메라를 회전
// 필요 속성: 현재 각도, 마우스 감도
public class CamRotate : MonoBehaviour
{
    // 현재 감도
    Vector3 angle;
    // 마우스 감도
    public float sensitivity = 200;
    
    // Start is called before the first frame update
    void Start()
    {
        // 시작할 때 현재 카메라의 각도를 적용
        angle.y = -Camera.main.transform.eulerAngles.x;
        angle.x = Camera.main.transform.eulerAngles.y;
        angle.z = Camera.main.transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 입력에 따라 카메라를 회전
        // 1. 사용자의 마우스 입력을 얻어와야 함
        // 마우스의 좌우 입력을 받아온다.
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        // 2. 방향이 필요함
        // 이동 공식에 대입해 각 속성별로 회전 값을 누적한다.
        angle.x += x*sensitivity*Time.deltaTime;
        angle.y += y*sensitivity*Time.deltaTime;
        
        // 3. 회전시킴
        // 카메라의 회전 값에 새로 만들어진 회전 값을 할당한다.
        transform.eulerAngles = new Vector3(-angle.y, angle.x, transform.eulerAngles.z);
    }
}
