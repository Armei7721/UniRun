
using UnityEngine;
// ���� ������Ʈ�� ��� �������� �����̴� ��ũ��Ʈ
public class ScrollingObject : MonoBehaviour
{
    public float speed = 10f;
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
