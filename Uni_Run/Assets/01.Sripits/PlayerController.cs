using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip deathClip; //����� ����� ����� Ŭ��
    public float jumpForce = 700f; //���� ��

    private int jumpCount = 0; //���� ���� Ƚ��
    private bool isGrounded = false; // �ٴڿ� ��Ҵ��� ��Ÿ��
    private bool isDead = false;//��� ����

    private Rigidbody2D playerRigidbody; // ����� ������ٵ� ������Ʈ
    private Animator animator; // ����� �ִϸ����� ������Ʈ
    private AudioSource playerAudio; // ����� ����� �ҽ� ������Ʈ
    // Start is called before the first frame update
    void Start()
    {
        // ���� ������Ʈ�κ��� ����� ������Ʈ���� ������ ������ �Ҵ�
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Die()
    {
        //��� ó��
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
      //Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ٴڿ� ������� �����ϴ� ó��
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //�ٴڿ��� ������� �����ϴ� ó��
    }
}