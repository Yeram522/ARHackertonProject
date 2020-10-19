using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class GhostHandler : MonoBehaviour
{

    //생성할 유령 오브젝트
    public GameObject Ghost_1;
    public GameObject Ghost_2;
    public GameObject Ghost_3;
    public GameObject Ghost_4;

    //값만 받아 쓰기 때문에  privqte으로 함.
    private GameObject Jongmyo;
    private int Ghosttrigger;
    private void Start()
    {
        //placeThePalace 스크립트의 변수 가져오기
        PlaceThePalace hitCount = GameObject.Find("hitCount").GetComponent<PlaceThePalace>();
        PlaceThePalace spawnPrefab = GameObject.Find("spawnPrefab").GetComponent<PlaceThePalace>();
        Ghosttrigger = hitCount.hitCount;
        Jongmyo = spawnPrefab.spawnPrefab;
        Jongmyo.position = new Vector3(0, 0, 0);

        //palace의 위치 값 받아오기
        Jongmyo.position.x = spawnPrefab.position.x;

    }
    void Update()
    {
        if (Ghosttrigger==0)
        {
            return;
        }

        

    }
}
