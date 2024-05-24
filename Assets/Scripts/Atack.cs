using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atack : MonoBehaviour
{
    public int damage = 1;
    private bool hasAttacked = false; // Флаг для отслеживания атаки в текущем цикле

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy") && !hasAttacked) // Проверка наличия атаки
        {
            print(1111111);
            Enemy npc = collision.gameObject.GetComponent<Enemy>();
            if (npc != null)
            {
                npc.TakeDamage(damage); // Наносим урон врагу
                hasAttacked = true; // Устанавливаем флаг атаки
            }
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Enemy"))
        {
            hasAttacked = false;
        }
    }
}
