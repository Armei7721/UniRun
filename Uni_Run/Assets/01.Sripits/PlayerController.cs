using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] Hp; // �Ѱų� �� �ڽ� ������Ʈ
    public AudioClip deathClip; //����� ����� ����� Ŭ��
    public float jumpForce = 700f; //���� ��
    public int hp = 3;
    

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
        for (int i = 0; i < Hp.Length; i++)
        {
            Hp[i].SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Slide();
    }
    private void Jump()
    {
        if (isDead)
        {
            // ��� �� ó���� �� �̻� �������� �ʰ� ����
            return;
        }
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            //���� Ƚ�� ����
            jumpCount++;
            // ���� ������ �ӵ��� ���������� ����(0,0)�� ����
            playerRigidbody.velocity = Vector2.zero;
            // ������ٵ� �������� �� �ֱ�
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            // ����� �ҽ� ���
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            // ���콺 ���� ��ư���� ���� ���� ���� && �ӵ��� y ���� ������(���� ��� ��)
            // ���� �ӵ��� �������� ����
            playerRigidbody.velocity = playerRigidbody.velocity * 0.5f;
        }
        animator.SetBool("Grounded", isGrounded);
    }
    private void Slide()
    {
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("Slide", true);
        }
        else if(Input.GetMouseButtonUp(1))
        {
            animator.SetBool("Slide", false);
        }
    }
    private void Recovery()
    {
        if (hp < Hp.Length)
        {
            
            Hp[hp].SetActive(true);
            hp += 1;
        }

    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
      //Ʈ���� �ݶ��̴��� ���� ��ֹ����� �浹�� ����
      if(other.tag =="Dead" && !isDead)
        {
            Die();   
        }
      else if (other.tag =="Recovery" && !isDead)
        {
            Recovery();
            other.gameObject.SetActive(false);
        }
      else if (other.tag == "Trap" && !isDead)
        {
            if (hp == 1)
            {
                hp -= 1;
                Hp[hp].SetActive(false);
                Die();
            }
            else if (hp > 0)
            {
                hp -= 1;
                Hp[hp].SetActive(false);
            }

        }
    }
    private void Die()
    {
        //��� ó��
        animator.SetTrigger("Die");
        //���̿� �ҽ��� �Ҵ�� ����� Ŭ���� deathClip���� ����
        playerAudio.clip = deathClip;
        //��� ȿ���� ���
        playerAudio.Play();
        //�ӵ��� ����(0,0)�� ����
        playerRigidbody.velocity = Vector2.zero;
        // ��� ���¸� true�� ����
        isDead = true;
        //���� �Ŵ����� ���ӿ��� ó�� ����
        GameManager.instance.OnPlayerDead();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �ٴڿ� ������� �����ϴ� ó��
        if(collision.contacts[0].normal.y>0.7f)
        {
            //isGround�� true�� �����ϰ�, ���� ���� Ƚ���� 0���� ����
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //�ٴڿ��� ������� �����ϴ� ó��
        isGrounded = false;
    }


}
