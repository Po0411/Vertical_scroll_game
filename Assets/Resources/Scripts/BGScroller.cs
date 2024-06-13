using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 직렬화 가능한 클래스 선언, 배경 스크롤 데이터를 저장
[System.Serializable]
public class BGScrollData
{
    public Renderer RenderForScroll; // 스크롤할 렌더러
    public float Speed; // 스크롤 속도
    public float OffsetX; // 텍스처 오프셋 X 좌표
}

public class BGScroller : MonoBehaviour
{
    [SerializeField]
    BGScrollData[] ScrollDatas; // 여러 스크롤 데이터를 배열로 저장

    void Start()
    {

    }

    void Update()
    {
        UpdateScroll(); // 매 프레임마다 스크롤 업데이트
    }

    // 스크롤 업데이트 메서드
    void UpdateScroll()
    {
        for (int i = 0; i < ScrollDatas.Length; i++) // 모든 스크롤 데이터에 대해
        {
            SetTextureOffset(ScrollDatas[i]); // 텍스처 오프셋 설정
        }
    }

    // 텍스처 오프셋 설정 메서드
    void SetTextureOffset(BGScrollData scrollData)
    {
        scrollData.OffsetX += (float)(scrollData.Speed) * Time.deltaTime; // 속도에 따라 오프셋 증가
        if (scrollData.OffsetX > 1)
            scrollData.OffsetX = scrollData.OffsetX % 1.0f; // 오프셋이 1을 초과하면 다시 0으로

        Vector2 Offset = new Vector2(scrollData.OffsetX, 0); // 새로운 오프셋 벡터 생성

        scrollData.RenderForScroll.material.SetTextureOffset("_MainTex", Offset); // 렌더러의 메인 텍스처 오프셋 설정
    }
}
