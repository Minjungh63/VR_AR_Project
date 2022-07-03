using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    // 복셀 공장
    public GameObject voxelFactory;

    // 오브젝트 풀의 크기
    public int voxelPoolSize = 20;

    // 오브젝트 풀
    public static List<GameObject> voxelPool = new List<GameObject>();

    // 생성 시간
    public float createTime = 0.1f;

    // 경과 시간
    float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < voxelPoolSize; i++)
        {
            // 복셀 공장에서 복셀 생성
            GameObject voxel = Instantiate(voxelFactory);

            // 복셀 비활성화
            voxel.SetActive(false);

            // 복셀을 오브젝트 풀에 담기
            voxelPool.Add (voxel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // currentTime에 경과 시간 저장
        currentTime += Time.deltaTime;

        // 생성 시간이 되면
        if (currentTime > createTime)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo = new RaycastHit();

            // 마우스의 위치가 바닥 위에 위치해 있다면
            if (Physics.Raycast(ray, out hitInfo))
            {
                // 만약 오브젝트 풀에 복셀이 있다면
                if (voxelPool.Count > 0)
                {
                    // 복셀을 생성했을 때만 경과 시간을 초기화해준다.
                    currentTime = 0;

                    // 오브젝트 풀에서 복셀을 하나 가져옴
                    GameObject voxel = voxelPool[0];

                    // 복셀을 활성화
                    voxel.SetActive(true);

                    // 복셀을 배치
                    voxel.transform.position = hitInfo.point;

                    // 오브젝트 풀에서 복셀을 제거
                    voxelPool.RemoveAt(0);
                }
            }
        }
    }
}
