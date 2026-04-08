using System.Collections.Generic;
using UnityEngine;

public class BulletMng : MonoBehaviour
{
    int[] n = new int[10];
    // 오브젝트 풀링(Object pool)
    [SerializeField] List<Bullet> bulletlist;
    [SerializeField] GameObject bulletprefab;

    // 1. List 알아보기 + 배열 Length, List Count인지 생각해보기
    // 2. 싱글톤 패턴 알아보기

    public void CreateBullet(Vector2 position)
    {
        for (int i = 0; i < bulletlist.Count; i++)
        {
            if (bulletlist[i].gameObject.activeSelf == false)
            {
                bulletlist[i].Create(position);
                return;
            }
        }

        // 클래스 =(인스턴스)> 객체
        //GameObject obj = Instantiate(bulletprefab);
        //Bullet bullet = obj.GetComponent<Bullet>();

        Bullet bullet = Instantiate(bulletprefab).GetComponent<Bullet>();
        bullet.Create(position);
        bulletlist.Add(bullet);

        bullet.transform.parent = transform;
    }
}
