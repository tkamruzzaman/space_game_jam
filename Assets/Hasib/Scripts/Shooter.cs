using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;

    int shootAmount = 5;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (shootAmount > 0)
            {
                Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);
                shootAmount--;
            }
            else
            {
                //GameOver
                Debug.Log("Lost");
            }
        }
    }
}
    