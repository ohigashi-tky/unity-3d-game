using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Enemy2;
    public Transform EnemyPlace1;
    public Transform EnemyPlace2;

    float TimeCount;

    // Start is called before the first frame update
    void Start()
    {
        TimeCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        TimeCount += Time.deltaTime;
        if (TimeCount > 2)
        {
            Instantiate(Enemy1, EnemyPlace1.position, Quaternion.Euler(0, 180, 0));
            Instantiate(Enemy2, EnemyPlace2.position, Quaternion.Euler(0, 180, 0));
            TimeCount = 0;
        }
    }
}
