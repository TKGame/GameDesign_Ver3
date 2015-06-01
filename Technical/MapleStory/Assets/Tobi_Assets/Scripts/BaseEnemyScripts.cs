using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

public struct Status
{
    public bool move;
    public bool attack;
    public bool shoot;
}
public class BaseEnemyScripts : BaseGameObject
{
    // biến xác định Flip
    bool _facingRight = true;
    // thời gian delay
    float _timeDelayOfBoss = 0.0f;

    float _timeDelayOfEnemy = 0.0f;
    // thời gian giữa 2 lần chuyển trạng thái của enemy
    public float distanceTimeDelayOfEnemy = 0.0f;
    // khoang cách
    float distanceEnemyToPlayer = 0.0f;
    // khoảng cách di chuyển quanh vị trí ban đầu
    public float distanceMove = 0.0f;
    // vị trí ban đầu 
    public Vector3 startPosition;
    // đối tượng player
    public GameObject playerObj;

    public float distanceTimeAttack = 3.0f;

    // xác định trong vùng bao của Player
    // trong vùng bao của Player nếu = true , và ngược lại
    public bool inAroundOfPlayer = false;

    public bool move;
    public bool attack;
    public bool shoot;

    #region Enemy
    public void RunUpdateEnemy(Transform tranformTarget)
    {
        if (playerObj != null)
        {
            distanceEnemyToPlayer = playerObj.transform.position.x - this.transform.position.x;
            UpdateStatusOfEnemy();
            if ((_timeDelayOfEnemy += Time.deltaTime) >= distanceTimeDelayOfEnemy && inAroundOfPlayer == false)
            {
                move = !move;
                _timeDelayOfEnemy = 0;
            }
            Die();
        }
    }
    // Hàm update trạng thái của Enemy
    public void UpdateStatusOfEnemy()
    {
        if (move)
        {
            UpdateStatusMove();
        }
        _animator.SetBool("isAttack", attack); // enemy attack
        _animator.SetBool("isMove", move);

    }
    #endregion
    //*************************************************************************//
    #region Boss
    int[] arrAttack = { 3, 3, 0, 3, 4, 0, 4, 0, 3, 3, 4, 4, 3, 0, 4 };
    int i = 0;
    public void BossStand()
    {
        _animator.SetBool("isAttack3", false);
        _animator.SetBool("isAttack4", false);
        _animator.SetBool("isAttack2", false);
    }
    // Hàm update trạng thái của Boss
    public void UpdateStatusOfBoss()
    {
        if(move)
        {
            UpdateStatusMove();
        }
        else if(attack)
        {
            if((_timeDelayOfBoss += Time.deltaTime)>= distanceTimeAttack)
            {
                //System.Random rand = new System.Random();
                //int indexAttack = rand.Next(0, 3);
                //Debug.Log(indexAttack);
                if (arrAttack[i] == 3)
                {
                    _animator.SetBool("isAttack3", true);
                }
                else if (arrAttack[i] == 4)
                {
                    _animator.SetBool("isAttack4", true);
                }
                else
                    BossStand();
                //
                if (i > arrAttack.Length -2)
                {
                    i = 0;
                }
                else
                    i++;
                _timeDelayOfBoss = 0.0f;
            }
        }
        else if(shoot)
        {
            _animator.SetBool("isAttack2", true);
        }
        _animator.SetBool("isMove",move);
    }
    #endregion
    public void RunUpdateBoss(Transform tranformTarget)
    {
        if (playerObj != null)
        {
            distanceEnemyToPlayer = playerObj.transform.position.x - this.transform.position.x;
            UpdateStatusOfBoss();
            if ((_timeDelayOfEnemy += Time.deltaTime) >= distanceTimeDelayOfEnemy && inAroundOfPlayer == false)
            {
                move = !move;
                _timeDelayOfEnemy = 0;
            }
            Die();
        }
    }
    //**************************************************************************//
    #region Chung

    /// <summary>
    /// hàm di chuyển của enemy
    /// Nếu ngoài vùng bao thì di chuyển quanh 1 vị trí 
    /// nếu trong vùng bao thì di chuyển lại gần player
    /// </summary>
    public void UpdateStatusMove()
    {
        if (inAroundOfPlayer == false)                    // nếu nằm ngoài vùng bao
        {
            Move(speed);
            if (transform.position.x >= startPosition.x + distanceMove || transform.position.x <= startPosition.x - distanceMove)
            {
                Flip();
            }
        }
        else                                            // nếu nằm trong vùng bao
        {
            if (distanceEnemyToPlayer < 0 && speed < 0 || distanceEnemyToPlayer > 0 && speed > 0)
            {
                Move(speed);
            }
            else if (distanceEnemyToPlayer < 0 && speed > 0 || distanceEnemyToPlayer > 0 && speed < 0)
            {
                if (_facingRight)
                {
                    _facingRight = !_facingRight;
                    Flip();
                }
                else
                    _facingRight = !_facingRight;
            }

            if (transform.position.x > startPosition.x + distanceMove || transform.position.x < startPosition.x - distanceMove)
            {
                startPosition = transform.position;
            }
        }
    }
    // hàm di chuyển 
    public void Move(float speedMove)
    {
        Vector3 newPos = transform.position;
        newPos.x += Time.deltaTime * speedMove;
        transform.position = newPos;
    }
    // hàm đổi hướng di chuyển của enemy
    public void Flip()
    {
        speed = -speed;
        Vector3 theScale = transform.localScale;
        theScale.x = -theScale.x;
        transform.localScale = theScale;

        if (transform.position.x < startPosition.x + distanceMove)
        {
            Vector3 newPos = transform.position;
            newPos.x += 0.2f;
            transform.position = newPos;
        }
        else
        {
            Vector3 newPos = transform.position;
            newPos.x -= 0.2f;
            transform.position = newPos;
        }
    }

    #endregion

    #region Xử lý va chạm

    public void onTriggerEnter2D(Collider2D col, string tag)
    {
        if(col.tag == tag)
        {
            inAroundOfPlayer = true;
            move = true;
        }
    }

    public void onTriggerStay2D(Collider2D col , string tagPlayer)
    {
        if(col.tag == tagPlayer)
        {
            move = false;
            attack = true;
            inAroundOfPlayer = false;
        }
    }

    public void onTriggerExit2D(Collider2D col , string tagAround)
    {
        if (col.tag == tagAround)
        {
            inAroundOfPlayer = false;
            move = true;
            attack = false;
        }
    }

    public void onTriggerExit2D(Collider2D col, string tagAround, string tagPlayer)
    {
        if(col.tag == tagAround)
        {
            inAroundOfPlayer = false;
        }
        if(col.tag== tagPlayer)
        {
            attack = false;
            move = true;
            inAroundOfPlayer = true;
        }
    }

    public void onTriggerStay2D_Shoot(Collider2D col, string tagAround)
    {
        if(col.tag == tagAround)
        {
            inAroundOfPlayer = false;
            attack = true;
            move = false;
        }
    }
    #endregion
}
