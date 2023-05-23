using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] Hp; // 켜거나 끌 자식 오브젝트
    public AudioClip deathClip; //사망시 재생할 오디오 클립
    public float jumpForce = 700f; //점프 힘
    public int hp = 3;
    

    private int jumpCount = 0; //누적 점프 횟수
    private bool isGrounded = false; // 바닥에 닿았는지 나타냄
    private bool isDead = false;//사망 상태
    private Rigidbody2D playerRigidbody; // 사용할 리지드바디 컴포넌트
    private Animator animator; // 사용할 애니메이터 컴포넌트
    private AudioSource playerAudio; // 사용할 오디오 소스 컴포넌트
    // Start is called before the first frame update
    void Start()
    {
        // 게임 오브젝트로부터 사용할 컴포넌트들을 가져와 변수에 할당
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
            // 사망 시 처리를 더 이상 진행하지 않고 종료
            return;
        }
        if (Input.GetMouseButtonDown(0) && jumpCount < 2)
        {
            //점프 횟수 증가
            jumpCount++;
            // 점프 직전에 속도를 순간적으로 제로(0,0)로 변경
            playerRigidbody.velocity = Vector2.zero;
            // 리지드바디에 위쪽으로 힘 주기
            playerRigidbody.AddForce(new Vector2(0, jumpForce));
            // 오디오 소스 재생
            playerAudio.Play();
        }
        else if (Input.GetMouseButtonUp(0) && playerRigidbody.velocity.y > 0)
        {
            // 마우스 왼쪽 버튼에서 손을 떼는 순간 && 속도의 y 값이 양수라면(위로 상승 중)
            // 현재 속도를 절반으로 변경
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
      //트리거 콜라이더를 가진 장애물과의 충돌을 감지
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
        //사망 처리
        animator.SetTrigger("Die");
        //오이오 소스에 할당된 오디오 클립을 deathClip으로 변경
        playerAudio.clip = deathClip;
        //사망 효과음 재생
        playerAudio.Play();
        //속도를 제로(0,0)로 변경
        playerRigidbody.velocity = Vector2.zero;
        // 사망 상태를 true로 변경
        isDead = true;
        //게임 매니저의 게임오버 처리 실행
        GameManager.instance.OnPlayerDead();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥에 닿았음을 감지하는 처리
        if(collision.contacts[0].normal.y>0.7f)
        {
            //isGround를 true로 변경하고, 누적 점프 횟수를 0으로 리셋
            isGrounded = true;
            jumpCount = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //바닥에서 벗어났음을 감지하는 처리
        isGrounded = false;
    }


}
