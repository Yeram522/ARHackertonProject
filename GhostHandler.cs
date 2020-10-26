using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GhostHandler : MonoBehaviour
{
    public Transform Ghost_1;
    public Transform Ghost_2;
    public Transform Ghost_3;
    public Transform Ghost_4;

    private List<Transform> GhostList = new List<Transform>();
    private bool ghostHandlerTrigger;
    private bool sponCalcularTrigger=false;
    private bool sponGhostTrigger = false;
    private Pose BasicghostPosition; //종묘 positon값 받기
    private void Start()
    {
        PlaceThePalace GhosthandlerTrigger = GameObject.Find("GhostTrigger").GetComponent<PlaceThePalace>();
        ghostHandlerTrigger = GhosthandlerTrigger.GhostTrigger;
    }

    void Setting(bool Ghosthandlertrigger)
    {
        if(Ghosthandlertrigger == false)
        {
            return;
        }
        //placeThePalace 스크립트의 변수 가져오기
        PlaceThePalace placeThePalace = GameObject.Find("spawnPrefabPose").GetComponent<PlaceThePalace>();
        BasicghostPosition = placeThePalace.m_spawnprefabPose;
        //palace의 위치 값 받아오기
        Ghost_1.position = BasicghostPosition.position;
        Ghost_2.position = BasicghostPosition.position;
        Ghost_3.position = BasicghostPosition.position;
        Ghost_4.position = BasicghostPosition.position;

        //정보들을 리스트(인덱스붙이려고 넣음)에 담기
        GhostList.Add(Ghost_1); //list index=0
        GhostList.Add(Ghost_2); //list index=1
        GhostList.Add(Ghost_3); //list index=2
        GhostList.Add(Ghost_4); //list index=3

        sponCalcularTrigger = true;
        sponGhostTrigger = true;

    }

    void sponCalcular(bool sponCalcularTrigger)//스폰 위치 계산 후 재정의
    {
        if (sponCalcularTrigger == false)
        {
            return;
        }

        foreach (Transform ghost in GhostList)
        {
            //idx와 swap은 계속 리스트가 도니까 초기화 해줘야함.
            int idx = GhostList.IndexOf(ghost);
            Vector3 swap = BasicghostPosition.position;

            //계산
            switch (idx)
            {
                case 0:
                    swap.x = 0.075f * (idx +2);
                    break;
                case 1:
                    swap.x = 0.075f * idx;
                    break;
                case 2:
                    swap.x = 0.075f * (idx-3);
                    break;
                case 3:
                    swap.x = 0.075f * (idx-5);
                    break;
            }   

            //계산값 대입
            ghost.position = swap;
        }
        sponCalcularTrigger = false;
    }
    void SpawnGhost(bool sponGhostTrigger) //move
    {
        if (sponGhostTrigger == false)
        {
            return;
        }
        float speed = 0.005f;
        //switch문을 통한 각각 유령제어
        foreach (Transform ghost in GhostList)
        {
            Vector3 targetpose = ghost.position;
            targetpose.y = 10f;
            ghost.position = Vector3.MoveTowards(ghost.position, targetpose, speed);
        }

    }
    void Update()
    {
        Setting(ghostHandlerTrigger);
        sponCalcular(sponCalcularTrigger);
        SpawnGhost(sponGhostTrigger); //move
    }
}
