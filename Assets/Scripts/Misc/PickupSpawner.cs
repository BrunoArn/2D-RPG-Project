using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldCoinPrefab, healthGlobe, staminaGlobe;

    public void DropItems(){
        int randomNum = Random.Range(1,5);

        if(randomNum == 1) {
            Instantiate(healthGlobe,transform.position, Quaternion.identity);
        }

        if(randomNum == 2) {
            Instantiate(staminaGlobe,transform.position, Quaternion.identity);
        }

        if(randomNum == 3) {
            int randomAmountOfGold = Random.Range(1, 4);

            for ( int i = 0; i < randomAmountOfGold; i++) {
                Instantiate(goldCoinPrefab,transform.position, Quaternion.identity);
            }
        }


    }
}
