using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour {
    //Всего хитпойнтов
    public int hp = 1;
    //Враг или игрок?
    public bool isEnemy = true;
    //Наносим урон и проверяем, уничтожен ли враг
    public void Damage (int damageCount)
    {
        hp -= damageCount;

        if (hp<=0)
        {
            Destroy(gameObject);
        }
    }
	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Это выстрел?
        ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript>();
        if (shot != null)
        {
            //Избегаем дружественного огня
            if (shot.isEnemyShot != isEnemy)
            {
                Damage(shot.damage);
                //Уничтожаем пулю
                Destroy(shot.gameObject);
            }
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
