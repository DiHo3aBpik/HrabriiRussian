using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f;          // Скорость движения NPC
    public float distance = 5.0f;       // Расстояние, на которое NPC будет двигаться влево и вправо
    public int maxHP = 100;             // Максимальное здоровье NPC
    private int currentHP;              // Текущее здоровье NPC

    private Vector3 startPosition;      // Начальная позиция NPC
    private bool movingRight = true;


    void Start()
    {
        startPosition = transform.position;  
        currentHP = maxHP;

    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Проверяем направление движения
        if (movingRight)
        {
            // Двигаем NPC вправо
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            // Проверяем, достигли ли мы правой границы
            if (transform.position.x >= startPosition.x + distance)
            {
                movingRight = false;  // Меняем направление на левое
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }
        else
        {
            // Двигаем NPC влево
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            // Проверяем, достигли ли мы левой границы
            if (transform.position.x <= startPosition.x - distance)
            {
                movingRight = true;  // Меняем направление на правое
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }
    }

    // Метод для нанесения урона NPC
    public void TakeDamage(int damage)
    {
        currentHP -= damage;  // Уменьшаем текущее здоровье
        if (currentHP <= 0)
        {
            Die();  // Если здоровье меньше или равно нулю, NPC умирает
        }
    }

    // Метод для смерти NPC
    private void Die()
    {
        Destroy(gameObject);  // Уничтожаем объект NPC
    }
   
}
