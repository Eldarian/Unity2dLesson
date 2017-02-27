using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour {

	//Скорость движения
	public Vector2 speed = new Vector2(50, 50);
		
	// Направление движения
	private Vector2 movement;
	
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Извлекаем информацию осей
		float inputX = Input.GetAxis ("Horizontal"); 
		float inputY = Input.GetAxis ("Vertical"); 
		//Движение в каждом направлении
		movement = new Vector2 (
			speed.x * inputX,
			speed.y * inputY);

        // Стрельба
        bool shoot = Input.GetButtonDown("Fire1");
        shoot |= Input.GetButtonDown("Fire2");
        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                // Ложь, так как игрок не враг
                weapon.Attack(false);
            }
        }

	}
	void FixedUpdate()	{
        GetComponent<Rigidbody2D>().velocity = movement;
	}
}

