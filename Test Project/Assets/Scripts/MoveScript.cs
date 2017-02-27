using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    // Поле скорости движения
    public Vector2 speed = new Vector2(10, 10);

    // Направление движения
    public Vector2 direction = new Vector2(-1,0);
    // Инициализация вектора перемещения
    private Vector2 movement;

    /*void Start()
    {

    }*/

    // Update is called once per frame
    void Update()
    {
        //Перемещение
        movement = new Vector2(
            speed.x * direction.x,
            speed.y * direction.y);
    }
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = movement;
    }
}
