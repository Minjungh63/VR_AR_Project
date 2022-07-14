using UnityEngine;
using UnityEngine.Video; // VideoPlayer 기능을 사용하기 위한 네임스페이스
// VideoPlayer 컴포넌트 제어 코드
public class VideoFrame : MonoBehaviour{
    // VideoPlayer 컴포넌트
    VideoPlayer vp;

    void Start(){
        // 현재 오브젝트의 비디오 플레이어 컴포넌트 정보를 가지고 온다.
        vp = GetComponent<VideoPlayer>();
        // 자동 재생되는 것을 막는다.
        vp.Stop();
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.S)){
            vp.Stop();
        }
        if(Input.GetKeyDown("space")){
            if(vp.isPlaying){
                vp.Pause();
            }else{
                vp.Play();
            }
        }
    }
    public void CheckVideoFrame(bool Checker){
        if(Checker){
            if(!vp.isPlaying){
                vp.Play();
            }
        }else{
            vp.Stop();
        }
    }
}