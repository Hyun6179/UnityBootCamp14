using System;
using System.Collections.Generic;
using UnityEngine;

class Pos
{
    public Pos(int y, int x) { Y = y; X = x; }

    public int Y;
    public int X;
}

public class Player : MonoBehaviour
{
    public int PosY { get; set; }
    public int PosX { get; set; }

    private Board _board;
    private bool _isBoardCreated = false;

    enum Dir
    {
        Up = 0,
        Left = 1,
        Down = 2,
        Right = 3,
    }

    int _dir = (int)Dir.Up; // 0

    List<Pos> _points = new List<Pos>();
    
    public void Initialze(int posY, int posX, Board board)
    {
        PosY = posY;
        PosX = posX;
        _board = board;

        AStar();

        transform.position = new Vector3(posX, 0, -posY);

        // ���� �ٶ󺸴� ���� ���� �չ��� Ÿ���� Ȯ�� �ϱ� ���� ��ǥ
        int[] _frontY = new int[] { -1, 0, 1, 0 };
        int[] _frontX = new int[] { 0, -1, 0, 1 };

        // ���� �ٶ󺸴� ���� ���� ������ Ÿ���� Ȯ�� �ϱ����� ��ǥ
        int[] _rightY = new int[] { 0, -1, 0, 1 };
        int[] _rightX = new int[] { 1, 0, -1, 0 };

        _points.Add(new Pos(PosY, PosX));

        // ������ ����� ���� ��ӽ���
        while (PosY != board.DestY || PosX != board.DestX)
        {
            // 1. ���� �ٶ󺸴� ������ �������� ���������� �� �� �ִ��� Ȯ��

            // ���� ���� �ٶ� ���� �ִ� �������, ������ �� Ÿ���� Ȯ���ؾ��ϴϱ�
            if (board.Tile[PosY + _rightY[_dir], PosX + _rightX[_dir]] != TileType.Wall)
            {
                #region 
                // ������ �������� 90�� ȸ��
                // ��ⷯ ����(modular arithmetic)�� �̿��� ���� �ε���(circular index) ����
                // ��ⷯ ���� = ������ ���� %�� ����ؼ� ���� ������ �����ϴ� ������ ���.
                // ���� �ε��� = ������ ������ ��� �ε����� ������ �ʵ��� ���� �����ϸ� �ٽ� ó������ ���ư��� ����
                #endregion

                _dir = (_dir - 1 + 4) % 4;
                #region
                //   [ ]
                //[ ] P [*] 
                //   [^]

                //switch (_dir)
                //{
                //    case (int)Dir.Up:
                //        _dir = (int)Dir.Right;
                //        break;
                //    case (int)Dir.Left:
                //        _dir = (int)Dir.Up;
                //        break;
                //    case (int)Dir.Down:
                //        _dir = (int)Dir.Left;
                //        break;
                //    case (int)Dir.Right:
                //        _dir = (int)Dir.Down;
                //        break;
                //}


                // X: 1, Y: 1
                // ���� �ٶ󺸴� �������� ������ �Ѻ� ����
                //   [ ]
                //[ ] P [*] 
                //   [ ]


                #endregion

                PosY = PosY + _frontY[_dir];
                PosX = PosX + _frontX[_dir];

                _points.Add(new Pos(PosY, PosX));
            }
            // 2. ���� �ٶ󺸴� ������ �������� ������ �� �ִ��� Ȯ��
            else if (board.Tile[PosY + _frontY[_dir], PosX + _frontX[_dir]] != TileType.Wall)
            {
                // ������ �Ѻ� ����
                PosY = PosY + _frontY[_dir];
                PosX = PosX + _frontX[_dir];

                _points.Add(new Pos(PosY, PosX));
            }
            // 3. �� ������, �� �� ��� ���� �ִٸ�
            else
            {
                // ���� �������� 90�� ȸ�� �� �� �ѱ��
                _dir = (_dir + 1 + 4) % 4;
            }
        }

        _isBoardCreated = true;
    }
    // struct�� ���� ����
    // 1. �� �����̶� �� �Ҵ� / GC �δ��� ����
    // class�� ���� �����̶� new �Ҷ����� ��(heap)�� ��ü�� �����, GC�� �����ؾ� ��
    // struct�� �� �����̶� ����(stack) �̳� �迭 ���ο� �ٷ� ���� ��
    // ��, �켱���� ť���� ��û ���� ��带 Push/Pop �Ҷ� GC Alloc�� �ٰ� ������ ������ �� ����  

    // 2. ũ�Ⱑ ���� ������ �����̱� ������ struct�� ����
    // PQNode�� ��� �ִ� �ʵ尡 � �ȵɰŰ�
    // struct�� �� �׷� �������� ���� ��������� ����
    // .Net�� ������ ���̵忡�� ����ü�� 16byte�̳���� Ŭ����(��ü)���� ���ɻ� �����ϴ� ��������

    struct PQNode : IComparable<PQNode>
    {
        public int F;
        public int G;
        public int Y;
        public int X;

        public int CompareTo(PQNode other)
        {
            if (F == other.F)
            return 0;

            return F < other.F ? 1 : -1;
        }
    }

    void AStar()
    {
        int[] dY = new int[] { -1, 0, 1, 0 };
        int[] dX = new int[] { 0, -1, 0, 1 };

        int[] cost = new int[] { 1, 1, 1, 1 }; // �����¿�� �̵��� ���� �־���

        // ���� �ű��
        // F = G + H
        // F : ���� ���� (���� ���� ����, ��ο� ���� �޶���)
        // G : ���������� �ش� ��ǥ���� �̵��ϴµ� ��� ��� (���� ���� ����, ��ο� ���� �޶���)
        // H : ���������� �󸶳� ������� ( ���� ���� ����, ������ )

        // (y,x) �̹� �湮�ߴٸ� (�湮 = closed ����)
        bool[,] closed = new bool[_board.Size, _board.Size]; // CloseList        ������ visited -> closed
        // (y,x) ���� ���� �ѹ��̶� �߰� �ߴ���
        // �߰� X => MaxValue
        // �߰� O => F = G + H
        int[,] open = new int[_board.Size, _board.Size]; // OpenList
        for (int y = 0; y < _board.Size; y++)
        {
            for(int x = 0; x < _board.Size; x++)
            {
                open[y, x] = Int32.MaxValue; // �� ���� ū ��?
            }
        }

        Pos[,] parent = new Pos[_board.Size, _board.Size];

        // ���¸���Ʈ�� �ִ� ������ �߿���, �� �� ���� �ĺ��� ������ �̾ƿ��� ���� �켱���� ť
        PriorityQueue<PQNode> pq = new PriorityQueue<PQNode>();

        // ������ �߰� (���� ����)
        open[PosY, PosX] =/* G = 0 ���ۺκ��̱� ���� */ /*H = */Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX);
        pq.Push(new PQNode()
        {
            F = Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX),
            G = 0,
            Y = PosY,
            X = PosX
        });
        parent[PosY,PosX] = new Pos(PosY,PosX);


        while (pq.Count > 0)
        {
            // ���� ���� �ĺ� ã��
            PQNode node = pq.Pop(); // ������������ ������������ ���� ����� ��

            // ������ ��ǥ�� ���� ��η� ã�Ƽ�, �� ���� ��η� ���ؼ� �̹� �湮(closed) �� ���� ��ŵ

            // �츮�� ���� PriorityQueue�� DecreaseKey �� ���� �ܼ� Push/Pop ��
            // ���� ť�� ���� Ű�� ������ �� ����Ű�� ����� �� ���� Ű�� ������ ����� ����
            if (closed[node.Y, node.X]) continue; // �ߺ� �Ǵ� Ű�� ������� �ְ� �װ� �����ϱ� ���� �ڵ�

            // �湮 �Ѵ�
            closed[node.Y,node.X] = true;

            // �������� �����ϸ� �ٷ� ����
            if (node.Y == _board.DestY && node.X == _board.DestX)
                break;

            // �����¿� �� �̵��� �� �ִ� ��ǥ���� Ȯ���ؼ� ����(open) �Ѵ�.
            for (int i = 0; i < 4; i++)
            {
                int nextY = node.Y + dY[i];
                int nextX = node.X + dX[i];

                // ��ȿ���� ����� ��ŵ
                if (nextY < 0 || nextY >= _board.Size || nextX < 0 || nextX >= _board.Size) continue;

                // ������ ���������� ��ŵ(���� ����� ��ŵ)
                if (_board.Tile[nextY, nextX] == TileType.Wall) continue;

                // �̹� �湮������ ��ŵ
                if (closed[nextY, nextX] == true) continue;

                // ��� ��� F = G + H
                int g = node.G + cost[i];
                int h = Math.Abs(_board.DestY - nextY) + Math.Abs(_board.DestX - nextX);

                // �ٸ� ��ο��� �� ���� ���� �̹� ã������ ��ŵ
                if (open[nextY, nextX] < g + h) continue; // ����� ���ٰ� �Դٸ� G ���� ���� ������ �н� 

                // ���� ����
                open[nextY, nextX] = g + h;

                // ť�� ����
                pq.Push(new PQNode() { F = g + h, G = g, Y = nextY, X = nextX });
                parent[nextY,nextX] = new Pos(nextY, nextX);
            }

        }

    }

    // ����� - (�̷θ� Ż���ϱ� ����) ������ ��Ģ

    private const float MOVE_TICK = 0.1f;
    private float _sumTick = 0;
    private int _lastIndex = 0;

    private void Update()
    {
        if (_lastIndex >= _points.Count)
            return;

        if (_isBoardCreated == false)
            return;

        _sumTick += Time.deltaTime;
        if (_sumTick < MOVE_TICK)
            return;

        _sumTick = 0;

        //int dir = Random.Range(0, 4);

        //int NextY = PosY;
        //int NextX = PosX;

        //switch (dir)
        //{
        //    case 0:
        //        NextY = PosY - 1;
        //        break;
        //    case 1:
        //        NextY = PosY + 1;
        //        break;
        //    case 2:
        //        NextX = PosX - 1;
        //        break;
        //    case 3:
        //        NextX = PosX + 1;
        //        break;
        //}

        //if (NextY < 0 || NextY >= _board.Size) return;
        //if (NextX < 0 || NextX >= _board.Size) return;
        //if (_board.Tile[NextY, NextX] == TileType.Wall) return; 

        //PosY = NextY;
        //PosX = NextX;
        PosY = _points[_lastIndex].Y;
        PosX = _points[_lastIndex].X;
        _lastIndex++;

        transform.position = new Vector3(PosX, 0, -PosY);
    }

}
