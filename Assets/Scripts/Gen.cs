using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// ��ͼ����
public class Gen : MonoBehaviour
{
    // ����Ԥ����
    // 0-��
    // 1-ǽ
    // 2-��
    // 3-������
    // 4-��
    // 5-��
    // 6-����ǽ
    public GameObject[] prefabs;
    // ��¼��ʹ�õ�λ��
    private List<Vector3> itemPositionList = new List<Vector3>();


    private void Awake()
    {
        CreateItem(prefabs[0], new Vector3(0, -8, 0), Quaternion.identity);
        CreateItem(prefabs[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(prefabs[1], new Vector3(1, -8, 0), Quaternion.identity);
        // �ҵ���ǽ
        for(int i = -1; i< 2;i++)
        {
            CreateItem(prefabs[1], new Vector3(i, -7, 0), Quaternion.identity);
        }
        // ��ͼ�߽����ǽ
        for(int i = -11; i< 12;i++)
        {
            CreateItem(prefabs[6], new Vector3(i, 9, 0), Quaternion.identity);
            CreateItem(prefabs[6], new Vector3(i, -9, 0), Quaternion.identity);
        }

        for(int i = -8; i< 9;i++)
        {
            CreateItem(prefabs[6], new Vector3(-11, i, 0), Quaternion.identity);
            CreateItem(prefabs[6], new Vector3(11, i, 0), Quaternion.identity);
        }

        // ����
        for(int i = 0; i<20; i++)
        {
            CreateItem(prefabs[1], CreatePostion(), Quaternion.identity);
            CreateItem(prefabs[2], CreatePostion(), Quaternion.identity);
            CreateItem(prefabs[4], CreatePostion(), Quaternion.identity);
            CreateItem(prefabs[5], CreatePostion(), Quaternion.identity);
        }

        // ��Һ͵���
        GameObject player = Instantiate(prefabs[3], new Vector3(-2, -8, 0), Quaternion.identity);
        player.GetComponent<Born>().createPlayer = true;

        CreateItem(prefabs[3], new Vector3(-10, 8, 0), Quaternion.identity);
        //CreateItem(prefabs[3], new Vector3(0, 8, 0), Quaternion.identity);
        //CreateItem(prefabs[3], new Vector3(10, 8, 0), Quaternion.identity);
        //InvokeRepeating("GenEnemy", 4, 5);
    }

    private void GenEnemy()
    {
        int n = Random.Range(0, 3);
        Vector3 p = new Vector3(-10 + n*10, 8, 0);
        CreateItem(prefabs[3], p, Quaternion.identity);
    }

    private void CreateItem(GameObject createGameObj, Vector3 position, Quaternion location)
    {
        GameObject i = Instantiate(createGameObj, position, location);
        i.transform.SetParent(gameObject.transform);
        itemPositionList.Add(position);
    }

    private Vector3 CreatePostion()
    {
        while(true)
        {
            Vector3 p = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if (!checkPositionInList(p))
            {
                return p;
            }
        }
    }
    private bool checkPositionInList(Vector3 p)
    {
        for(int i = 0; i< itemPositionList.Count; i++)
        {
            if (p == itemPositionList[i])
            {
                return true;
            }
        }
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
