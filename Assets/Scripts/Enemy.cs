using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f;          // �������� �������� NPC
    public float distance = 5.0f;       // ����������, �� ������� NPC ����� ��������� ����� � ������
    public int maxHP = 100;             // ������������ �������� NPC
    private int currentHP;              // ������� �������� NPC

    private Vector3 startPosition;      // ��������� ������� NPC
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
        // ��������� ����������� ��������
        if (movingRight)
        {
            // ������� NPC ������
            transform.Translate(Vector3.right * speed * Time.deltaTime);
            // ���������, �������� �� �� ������ �������
            if (transform.position.x >= startPosition.x + distance)
            {
                movingRight = false;  // ������ ����������� �� �����
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }
        else
        {
            // ������� NPC �����
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            // ���������, �������� �� �� ����� �������
            if (transform.position.x <= startPosition.x - distance)
            {
                movingRight = true;  // ������ ����������� �� ������
                SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }
    }

    // ����� ��� ��������� ����� NPC
    public void TakeDamage(int damage)
    {
        currentHP -= damage;  // ��������� ������� ��������
        if (currentHP <= 0)
        {
            Die();  // ���� �������� ������ ��� ����� ����, NPC �������
        }
    }

    // ����� ��� ������ NPC
    private void Die()
    {
        Destroy(gameObject);  // ���������� ������ NPC
    }
   
}
