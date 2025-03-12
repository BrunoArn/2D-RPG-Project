using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldCoinPrefab;

    public void DropItems(){
        Instantiate(goldCoinPrefab,transform.position, Quaternion.identity);
    }
}
