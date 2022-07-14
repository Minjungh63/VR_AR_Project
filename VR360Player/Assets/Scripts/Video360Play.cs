using UnityEngine;
using UnityEngine.Video; // VideoPlayer 기능을 이용하기 위한 네임스페이스
// 비디오 플레이어를 통해 360 스피어에 영상을 재생
// 두 가지 서로 다른 영상을 교체하며 재생

public class Video360Play : MonoBehaviour
{
    VideoPlayer vp; // 비디오 플레이어 컴포넌트
    public VideoClip[] vcList; // 다수의 비디오 클립을 배열로 만들어 관리
    int curVCidx; // 현재 재생중인 클립 번호를 저장

    // Start is called before the first frame update
    void Start()
    {
        vp = GetComponent<VideoPlayer>();
        vp.clip = vcList[0];
        curVCidx=0;
        vp.Stop();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftBracket)){ // 왼쪽 대괄호 입력시
            SwapVideoClip(false);
        }
        else if(Input.GetKeyDown(KeyCode.RightBracket)){ // 오른쪽 대괄호 입력시
            SwapVideoClip(true);
        }
    }
    public void SwapVideoClip(bool isNext){
        int setVCnum = curVCidx;
        vp.Stop();
        if(isNext){
            setVCnum = (setVCnum+1)%vcList.Length;
        }
        else{
            setVCnum=((setVCnum-1)+vcList.Length)%vcList.Length;
        }
        vp.clip=vcList[setVCnum];
        vp.Play();
        curVCidx = setVCnum;
    }
    public void SetVideoPlay(int num){
        if(curVCidx != num){
            vp.Stop();
            vp.clip = vcList[num];
            curVCidx = num;
            vp.Play();
        }
    }
}

