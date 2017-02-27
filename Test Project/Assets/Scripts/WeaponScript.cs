using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

    //1 - Переменные дизайнера

    // Префаб снаряда для стрельбы
    public Transform shotPrefab;

    // Время перезарядки в секундах

    public float shootingRate = 0.25f;

    //2 - Перезарядка

    private float shootCooldown;

	// Use this for initialization
	void Start () {
        shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
	}

    //3 - Стрельба из другого скрипта

    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;

            // Создание нового выстрела
            var shotTransform = Instantiate(shotPrefab) as Transform;
            // Определение положения
            shotTransform.position = transform.position;
            // Свойство врага
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot !=null)
            {
                shot.isEnemyShot = isEnemy;
            }
            // Задание выстрела самонаводящимся
            MoveScript move = shotTransform.gameObject.GetComponent<MoveScript>();
            if (move !=null)
            {
                move.direction = this.transform.right; // в двумерном пространстве выстрел производится справа от спрайта
            }
     
        }
    }
    // Готово ли оружие выпустить снаряд?
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}
