using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public Transform EnemyPlace1;
    public Transform EnemyPlace2;

    double TimeCount;

    // Start is called before the first frame update
    void Start()
    {
        TimeCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount += Time.deltaTime;
        if (TimeCount > 1)
        {
            Vector3 randomOffset1 = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
            Vector3 randomOffset2 = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));

            Instantiate(Enemy1, EnemyPlace1.position + randomOffset1, Quaternion.Euler(0, 180, 0));
            Instantiate(Enemy2, EnemyPlace2.position + randomOffset2, Quaternion.Euler(0, 180, 0));

            TimeCount = 0;
        }
    }
}
