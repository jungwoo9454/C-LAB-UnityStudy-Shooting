using System.Collections.Generic;
using UnityEngine;

public class EnemyMng : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] List<Enemy> enemies;

    float createEnemyTime = 0;

    void Update()
    {
        createEnemyTime += Time.deltaTime;
        if (createEnemyTime >= 1.0f)
        {
            createEnemyTime = 0;

            Vector2 v = Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0.0f, 1.0f), 1.1f, 0));

            CreateEnemy(v);
        }
    }

    public void CreateEnemy(Vector2 position)
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i].gameObject.activeSelf == false)
            {
                enemies[i].Create(position);
                return;
            }
        }

        Enemy obj = Instantiate(enemy).GetComponent<Enemy>();
        enemies.Add(obj);
        obj.Create(position);
        obj.transform.parent = transform;

    }
}
