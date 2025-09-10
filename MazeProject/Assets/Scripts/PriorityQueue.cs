using System;
using System.Collections.Generic;


class PriorityQueue<T> where T : IComparable<T> // <= 얘를 상속받아 구현한 클래스만 T 가능
{
	List<T> _heap = new List<T>();

	// 삽입
	public void Push(T data)
	{
		_heap.Add(data);
		// 일단 노드 맨 아래 추가
		/*
					   [32]
					  /    \
				   [26]    [15]
				  /   \    /   \
			   [19]  [new] [6]  [13]
			   / \    /
			[1][10]  [14]
		*/
		int now = _heap.Count - 1;
		while (now > 0)
		{
			// 부모 구하기
			int next = (now - 1) / 2;
			// Count == 10
			//  0   1   2   3   4   5   6  7   8   9
			// [32][26][15][19][14][6][13][1][10][new]   

			/*
				   [0]
				  /   \
			   [1]     [2]
			  /   \   /   \
			 [3] [4] [5]  [6]

			노드 1 : 
			(1-1) / 2 = 0

			노드 2 :
			(2-1) / 2 = 0

			노드 3 :
			(3-1) / 2 = 1

			노드 4 :
			(4-1) / 2 = 1

			노드 5 : 
			(5-1) / 2 = 2

			노드 6 : 
			(6-1) / 2 = 2

			즉, 부모를 구하는 공식 = (now-1)/2
			 */
			// 내가 부모보다 작다면 브레이크
			if (_heap[now].CompareTo(_heap[next]) < 0)
				break;

			// 부모랑 나의 위치를 교환
			T temp = _heap[now];
			_heap[now] = _heap[next];
			_heap[next] = temp;
			/*
						   [32]
						  /    \
					   [26]    [15]
					  /   \    /   \
				   [19]  [new] [6]  [13]
				   / \    /
				[1][10] [14]
			*/

			// 검사 위치 이동              
			//  0   1   2   3   4   5   6  7   8   9
			// [32][26][15][19][new][6][13][1][10][14]
			//                  ^                  ^
			//                 next   <--------   now
			now = next;
		}
	}

	public T Pop()
	{
		// 반환 데이터 저장
		T ret = _heap[0];
		/*
					   [32] <---------      
					  /    \         |
				   [26]    [15]      |
				  /   \    /   \     |
			   [19]  [14] [6]  [13]  |
			   / \                   |
			[1] [10] ----------------- 

			꼴지 노드를 가장 상위로 올려서 트리의 형태를 유지
		*/
		// 마지막 인덱스 가져오기
		int lastIndex = _heap.Count - 1;
		// 루트 노드의 데이터를 마지막 데이터와 교체하기
		_heap[0] = _heap[lastIndex];
		_heap.RemoveAt(lastIndex);
		lastIndex--;
		/*
						   [32]                       ---> [10]     
						  /    \                          /    \   
					   [26]    [15]                    [26]    [15] 
					  /   \    /   \                   /   \    /   \
				   [19]  [14] [6]  [13]             [19]  [14] [6]  [13]
				   / \                              /
				[1]  [10]  <---                   [1]  

		꼴지 노드를 최상위에 올리고 최하위 노드를 RemoveAt 으로 삭제
		그리고, 라스트 인덱스 1 감소

							   [10]
							  /   \
							 /     \
							/       \
						   /         \
						  /           \  
						 /             \
					  [26] <누가더큼?> [15]      
					 /   \            /   \     
				   [19]  [14]       [6]  [13]  
				   /                    
				[1]  
			바로 밑 자식 노드중 더 큰쪽 으로 비교 시도 해야함
		*/


		int now = 0;
		while (true)
		{
			// 왼쪽 자식 노드 구하기
			int left = 2 * now + 1;

			// 오른쪽 자식 노드 구하기
			int right = 2 * now + 2;
			/*
							[0]
							/   \
						 [1]    [2]
						/   \   /   \
					  [3]  [4] [5]  [6]

				노드 1 : 
				2 * 0 + 1 = 1

				노드 2 :
				2 * 0 + 2 = 2

				왼쪽 자식 구하는 공식   = 2 * now + 1
				오른쪽 자식 구하는 공식 = 2 * now + 2
			*/
			int next = now;
			if (left <= lastIndex && _heap[next].CompareTo(_heap[left]) < 0)
				next = left;

			if (right <= lastIndex && _heap[next].CompareTo(_heap[right]) < 0)
				next = right;
			/*
						  now >[26]    10   
							  /    \         
				얘가더큼--->[10]<next[15]      
						  /   \    /   \     
					   [19]  [14] [6]  [13]  
					   /                    
					[1]  
			*/

			// 만약, 왼쪽 오른쪽 모두 now 보다 작다면 종료
			if (next == now)
				break;

			/*
				위의 경우가 없을것 같지만 있음

						[7]
						/   \
					[5]     [6]

				루트(7) 삭제 -> 마지막 노드(6)를 루트로 올림

						[6]
						/   
					[5]     
			*/

			// 이제 두 값을 교체
			T temp = _heap[now];
			_heap[now] = _heap[next];
			_heap[next] = temp;
			/*
					 --->  [10]                            [26]     
						  /    \                          /    \   
					   [26]    [15]               --->  [10]    [15] 
					  /   \    /   \                   /   \    /   \
				   [19]  [14] [6]  [13]             [19]  [14] [6]  [13]
				   /                                /
				[1]                               [1]  

			*/
			now = next;

			/*
					 --->  [10]                            [26]     
						  /    \                          /    \   
					   [26]    [15]                     [19]    [15] 
					  /   \    /   \                   /   \    /   \
				   [19]  [14] [6]  [13]             [10]  [14] [6]  [13]
				   /                                /
				[1]                               [1]  

			*/
		}

		return ret;
	}

	public int Count { get { return _heap.Count; } }
}


