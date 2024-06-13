using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����ȭ ������ Ŭ���� ����, ��� ��ũ�� �����͸� ����
[System.Serializable]
public class BGScrollData
{
    public Renderer RenderForScroll; // ��ũ���� ������
    public float Speed; // ��ũ�� �ӵ�
    public float OffsetX; // �ؽ�ó ������ X ��ǥ
}

public class BGScroller : MonoBehaviour
{
    [SerializeField]
    BGScrollData[] ScrollDatas; // ���� ��ũ�� �����͸� �迭�� ����

    void Start()
    {

    }

    void Update()
    {
        UpdateScroll(); // �� �����Ӹ��� ��ũ�� ������Ʈ
    }

    // ��ũ�� ������Ʈ �޼���
    void UpdateScroll()
    {
        for (int i = 0; i < ScrollDatas.Length; i++) // ��� ��ũ�� �����Ϳ� ����
        {
            SetTextureOffset(ScrollDatas[i]); // �ؽ�ó ������ ����
        }
    }

    // �ؽ�ó ������ ���� �޼���
    void SetTextureOffset(BGScrollData scrollData)
    {
        scrollData.OffsetX += (float)(scrollData.Speed) * Time.deltaTime; // �ӵ��� ���� ������ ����
        if (scrollData.OffsetX > 1)
            scrollData.OffsetX = scrollData.OffsetX % 1.0f; // �������� 1�� �ʰ��ϸ� �ٽ� 0����

        Vector2 Offset = new Vector2(scrollData.OffsetX, 0); // ���ο� ������ ���� ����

        scrollData.RenderForScroll.material.SetTextureOffset("_MainTex", Offset); // �������� ���� �ؽ�ó ������ ����
    }
}
