using UnityEngine;

public class Board : MonoBehaviour
{
    public enum TileType
    {
        Empty,
        Wall,
        //4) �߰��ϱ�
        Goal
    }

    public TileType[,] Tile { get; private set; }
    public int Size { get; set; }

    public int DestY { get; private set; }
    public int DestX { get; private set; }

    private Transform _maze;
    private Shader shader;
    private Material emptyMat;
    private Material wallMat;
    private Material goalMat;

    private void Start()
    {
        shader = Shader.Find("Universal Render Pipeline/Lit");
        emptyMat = new Material(shader);
        emptyMat.color = Color.gray;
        wallMat = new Material(shader);
        wallMat.color = Color.white;
        goalMat = new Material(shader);
        goalMat.color = Color.green;
    }

    public void Initialize()
    {
        Tile = new TileType[Size, Size];

        // 2) �߰��ϱ�
        DestY = Size - 2;
        DestX = Size - 2;

        // 3) ���ֱ�
        //for (int y = 0; y < Size; y++)
        //{
        //    for (int x = 0; x < Size; x++)
        //    {
        //        if (x == 0 || x == Size - 1 || y == 0 || y == Size - 1)
        //            Tile[y, x] = TileType.Wall;
        //        else
        //            Tile[y, x] = TileType.Empty;
        //    }
        //}

        GenerateBySideWineder();
    }

    public void Spawn()
    {
        if (_maze != null) 
            Despawn();

        _maze = new GameObject().transform;
        _maze.parent = transform;
        _maze.name = "Maze";

        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.transform.position = new Vector3(x, 0, -y);
                go.transform.parent = _maze;

                if (Tile[y, x] == TileType.Empty /*10) �߰��ϱ�->>>>>*/|| Tile[y, x] == TileType.Goal)
                    go.transform.localScale = new Vector3(1f, 0.1f, 1f);
                else
                    go.transform.localScale = new Vector3(1f, 2f, 1f);

                go.GetComponent<MeshRenderer>().sharedMaterial = GetTileColor(Tile[y, x]);
            }
        }
    }

    private void GenerateBySideWineder()
    {
        // �ϴ� �� �� ����
        for (int y = 0; y < Size; y++)
        {
            for (int x = 0; x < Size; x++)
            {
                // x�� y ��ǥ�� ¦���ΰ�� - ������ ����(��)
                if (x % 2 == 0 || y % 2 == 0)
                    Tile[y, x] = TileType.Wall;
                // 8) �߰��ϱ�
                else if (x == DestX && y == DestY)
                    Tile[y, x] = TileType.Goal;
                else
                    Tile[y, x] = TileType.Empty;
            }
        }

        // �������� ���� Ȥ�� �Ʒ��� �� ����
        for (int y = 0; y < Size; y++)
        {
            // �Ʒ��� �ձ��� ī��Ʈ ����
            int count = 1;
            for (int x = 0; x < Size; x++)
            {
                // �Ʊ� ���������� ���� ���� �ǳʶ�
                if (x % 2 == 0 || y % 2 == 0)
                    continue;

                // ���� ������ �� �̰� ���� �Ʒ��� �� �ִ� �ǳʶ�
                if (y == Size - 2 && x == Size - 2)
                    continue;

                // ���� ������ ���̸� ������ ��Ǯ�� ���
                if (y == Size - 2)
                {
                    Tile[y, x + 1] = TileType.Empty;
                    continue;
                }

                // ���� �Ʒ��� ���̸� ������ ��Ǯ�� ���
                if (x == Size - 2)
                {
                    Tile[y + 1, x] = TileType.Empty;
                    continue;
                }

                // �ᱹ x, y ��ǥ�� ��� Ȧ���� �ֵ��� �������
                // 0 �� 1�� ���� ����
                // 0 �̸� ������ ��հ� ī��Ʈ 1����
                if (Random.Range(0, 2) == 0)
                {
                    Tile[y, x + 1] = TileType.Empty;
                    count++;
                }
                // 1 �̸� �Ʒ��� ��մµ� ���±��� ���������� �վ��� x �� �Ѱ��� ��� ����
                else
                {
                    //           x - ��°� ���� ������ ���ʿ��� ���������� �հ� �־��� ����
                    //                                      * 2 ���� ������ ¦����ǥ�ֵ��� �ֱ⶧���� ���ϱ� 2�� ����
                    //               �� ���������� 3�� ���� ���¶�� 0, 1, 2 �߿� �ϳ� ���ò���
                    //                                              ���� 2�� ������ ���ϱ� 2�ؼ� x - 4 �� �� ���ʿ��� �Ʒ��� ���� ��
                    Tile[y + 1, x - Random.Range(0, count) * 2] = TileType.Empty;
                    // �׸��� ī��Ʈ �� ������ �վ��� ���� �ʱ�ȭ
                    count = 1;
                }

            }
        }

    }

    private Material GetTileColor(TileType type)
    {
        switch (type)
        {
            case TileType.Empty:
                return emptyMat;
            case TileType.Wall:
                return wallMat;
                // 7) �߰��ϱ�
            case TileType.Goal:
                return goalMat;
        }

        return wallMat;
    } 

    private void Despawn()
    {
        Destroy(_maze.gameObject);
        _maze = null;
    }
}
