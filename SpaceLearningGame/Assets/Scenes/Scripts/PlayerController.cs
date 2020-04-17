using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float min_Y=-4.3f, max_Y=4.3f;

    [SerializeField] // to be accesible by other script but not private
    private GameObject player_Bullet;

    public float attack_Timer = 0.35f;
    private float current_Attack_Timer;
    private bool canAttack;
 
    [SerializeField]
    private Transform attack_point;
    // Update is called once per frame

    void Start()
    {
        current_Attack_Timer = attack_Timer;
        
    }
    void Update()
    {
        MovePlayer();
        Attack();
    }
    void MovePlayer()
    {
        if(Input.GetAxisRaw("Vertical")>0f)
        {
            Vector3 temp = transform.position;
            temp.y += speed * Time.deltaTime;
            if(temp.y>max_Y)
            {
                temp.y = max_Y;
            }
            transform.position = temp;
        }
        if (Input.GetAxisRaw("Vertical") < 0f)
        {
            Vector3 temp = transform.position;
            temp.y -= speed * Time.deltaTime;
            if (temp.y < min_Y)
            {
                temp.y = min_Y;
            }
            transform.position = temp;
        }
    }
    void Attack()
    {
      
        attack_Timer += Time.deltaTime;
        if(attack_Timer>current_Attack_Timer)
        {
            canAttack = true;
        }
        if(Input.GetKeyDown(KeyCode.K))
        {
            if(canAttack)
            {
                canAttack = false;
                attack_Timer = 0f;
                Instantiate(player_Bullet, attack_point.position, Quaternion.identity);
                

            }
        }
    }
}
