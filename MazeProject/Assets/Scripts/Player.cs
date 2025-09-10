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

        // 내가 바라보는 방향 기준 앞방향 타일을 확인 하기 위한 좌표
        int[] _frontY = new int[] { -1, 0, 1, 0 };
        int[] _frontX = new int[] { 0, -1, 0, 1 };

        // 내가 바라보는 방향 기준 오른쪽 타일을 확인 하기위한 좌표
        int[] _rightY = new int[] { 0, -1, 0, 1 };
        int[] _rightX = new int[] { 1, 0, -1, 0 };

        _points.Add(new Pos(PosY, PosX));

        // 목적지 계산전 까지 계속실행
        while (PosY != board.DestY || PosX != board.DestX)
        {
            // 1. 현재 바라보는 방향을 기준으로 오른쪽으로 갈 수 있는지 확인

            // 현재 내가 바라 보고 있는 방향기준, 오른쪽 의 타일을 확인해야하니까
            if (board.Tile[PosY + _rightY[_dir], PosX + _rightX[_dir]] != TileType.Wall)
            {
                #region 
                // 오른쪽 방향으로 90도 회전
                // 모듈러 연산(modular arithmetic)을 이용한 원형 인덱스(circular index) 패턴
                // 모듈러 연산 = 나머지 연산 %을 사용해서 값의 범위를 고정하는 수학적 기법.
                // 원형 인덱스 = 음수나 범위를 벗어난 인덱스가 나오지 않도록 끝에 도달하면 다시 처음으로 돌아가는 구조
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
                // 내가 바라보는 방향으로 앞으로 한보 전진
                //   [ ]
                //[ ] P [*] 
                //   [ ]


                #endregion

                PosY = PosY + _frontY[_dir];
                PosX = PosX + _frontX[_dir];

                _points.Add(new Pos(PosY, PosX));
            }
            // 2. 현재 바라보는 방향을 기준으로 전진할 수 있는지 확인
            else if (board.Tile[PosY + _frontY[_dir], PosX + _frontX[_dir]] != TileType.Wall)
            {
                // 앞으로 한보 전진
                PosY = PosY + _frontY[_dir];
                PosX = PosX + _frontX[_dir];

                _points.Add(new Pos(PosY, PosX));
            }
            // 3. 내 오른쪽, 내 앞 모두 벽이 있다면
            else
            {
                // 왼쪽 방향으로 90도 회전 후 턴 넘기기
                _dir = (_dir + 1 + 4) % 4;
            }
        }

        _isBoardCreated = true;
    }
    // struct로 만든 이유
    // 1. 값 형식이라 힙 할당 / GC 부담이 없음
    // class는 참조 형식이라 new 할때마다 힙(heap)에 객체가 생기고, GC가 관리해야 함
    // struct는 값 형식이라 스택(stack) 이나 배열 내부에 바로 저장 됨
    // 즉, 우선순위 큐에서 엄청 많은 노드를 Push/Pop 할때 GC Alloc이 줄고 성능이 좋아질 수 있음  

    // 2. 크기가 작은 데이터 묶음이기 때문에 struct가 적절
    // PQNode가 담고 있는 필드가 몇개 안될거고
    // struct가 딱 그런 변수들의 묶음 덩어리용으로 쓰임
    // .Net의 디자인 가이드에도 구조체가 16byte이내라면 클래스(객체)보다 성능상 유리하다 나와있음

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

        int[] cost = new int[] { 1, 1, 1, 1 }; // 상하좌우로 이동시 값을 넣어줌

        // 점수 매기기
        // F = G + H
        // F : 최종 점수 (작을 수록 좋음, 경로에 따라 달라짐)
        // G : 시작점에서 해당 좌표까지 이동하는데 드는 비용 (작을 수록 좋음, 경로에 따라 달라짐)
        // H : 목적지에서 얼마나 가까운지 ( 작을 수록 좋음, 고정값 )

        // (y,x) 이미 방문했다면 (방문 = closed 상태)
        bool[,] closed = new bool[_board.Size, _board.Size]; // CloseList        이전의 visited -> closed
        // (y,x) 가는 길을 한번이라도 발견 했는지
        // 발견 X => MaxValue
        // 발견 O => F = G + H
        int[,] open = new int[_board.Size, _board.Size]; // OpenList
        for (int y = 0; y < _board.Size; y++)
        {
            for(int x = 0; x < _board.Size; x++)
            {
                open[y, x] = Int32.MaxValue; // 왜 가장 큰 값?
            }
        }

        Pos[,] parent = new Pos[_board.Size, _board.Size];

        // 오픈리스트에 있는 정보들 중에서, 가 장 좋은 후보를 빠르게 뽑아오기 위한 우선순위 큐
        PriorityQueue<PQNode> pq = new PriorityQueue<PQNode>();

        // 시작점 발견 (예약 진행)
        open[PosY, PosX] =/* G = 0 시작부분이기 때문 */ /*H = */Math.Abs(_board.DestY - PosY) + Math.Abs(_board.DestX - PosX);
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
            // 제일 좋은 후보 찾기
            PQNode node = pq.Pop(); // 시작지점부터 골인지점까지 가장 가까운 값

            // 동일한 좌표를 여러 경로로 찾아서, 더 빠른 경로로 인해서 이미 방문(closed) 된 경우는 스킵

            // 우리가 만든 PriorityQueue는 DecreaseKey 가 없는 단순 Push/Pop 임
            // 같은 큐에 같은 키가 들어왔을 때 최적키만 남기고 더 나쁜 키는 버리는 기능이 없음
            if (closed[node.Y, node.X]) continue; // 중복 되는 키가 생길수도 있고 그걸 방지하기 위한 코드

            // 방문 한다
            closed[node.Y,node.X] = true;

            // 목적지에 도착하면 바로 종료
            if (node.Y == _board.DestY && node.X == _board.DestX)
                break;

            // 상하좌우 등 이동할 수 있는 좌표인지 확인해서 예약(open) 한다.
            for (int i = 0; i < 4; i++)
            {
                int nextY = node.Y + dY[i];
                int nextX = node.X + dX[i];

                // 유효범위 벗어나면 스킵
                if (nextY < 0 || nextY >= _board.Size || nextX < 0 || nextX >= _board.Size) continue;

                // 벽으로 막혀있으면 스킵(연결 끊기면 스킵)
                if (_board.Tile[nextY, nextX] == TileType.Wall) continue;

                // 이미 방문했으면 스킵
                if (closed[nextY, nextX] == true) continue;

                // 비용 계산 F = G + H
                int g = node.G + cost[i];
                int h = Math.Abs(_board.DestY - nextY) + Math.Abs(_board.DestX - nextX);

                // 다른 경로에서 더 빠른 길을 이미 찾았으면 스킵
                if (open[nextY, nextX] < g + h) continue; // 샛길로 샜다가 왔다면 G 값이 높기 때문에 패스 

                // 예약 진행
                open[nextY, nextX] = g + h;

                // 큐에 삽입
                pq.Push(new PQNode() { F = g + h, G = g, Y = nextY, X = nextX });
                parent[nextY,nextX] = new Pos(nextY, nextX);
            }

        }

    }

    // 우수법 - (미로를 탈출하기 위한) 오른손 법칙

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
