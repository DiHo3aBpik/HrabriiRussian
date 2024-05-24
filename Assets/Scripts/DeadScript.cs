using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadScript : MonoBehaviour
{
    public GameObject panel;
    public GameObject Player;
    private PlayerHp hp;
    // Start is called before the first frame update
    void Start()
    {
        hp = Player.GetComponent<PlayerHp>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y == -38)
        {
            hp.Hp = 0;

        }
    }
    
}
