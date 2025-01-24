using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    [SerializeField] private GameObject[] gasObjects;

    private void OnEnable()
    {
        // 모든 가스 아이템 비활성
        foreach (var gasObject in gasObjects)
        {
            gasObject.SetActive(false);
        }
    }
    
    // 플레이어 차량이 도로에 진입하면 다음 도로를 생성
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.SpawnRoad(transform.position + new Vector3(0, 0, 10));
        }
    }

    // 플레이어 차량이 도로를 벗어나면 해당 도로를 제거
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.DestroyRoad(gameObject);
        }
    }

    // 랜덤으로 가스 아이템을 표시
    public void SpawnGas()
    {
        int index = Random.Range(0, gasObjects.Length);
        gasObjects[index].SetActive(true);
    }
}
