using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject[] bostacles; //��ֹ� ������Ʈ��
    private bool stepped = false; //�÷��̾� ĳ���Ͱ� ��Ҵ°�?
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //������Ʈ�� Ȱ��ȭ�� ������ �Ź� ����Ǵ� �޼���
    private void OnEnabel()
    {
        //������ �����ϴ� ó��
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //�÷��̾� ĳ���Ͱ� �ڽ��� ����� �� ������ �߰��ϴ� ó��
    }
        
}
