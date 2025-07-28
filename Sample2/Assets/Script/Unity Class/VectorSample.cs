using UnityEngine;

public class VectorSample : MonoBehaviour
{
    public Vector3 A = new Vector3(); // x와 y와 z가 자동적으로 0(영점)
    public Vector3 B = new Vector3(3, 4); //x와 y에 대한 정보 전달, z는 자동적으로 0
    public Vector3 C = new Vector3(5, 6, 7);
    public Vector2 D = new Vector2(7, 8);
    public Vector3 E;
    public Vector3 F;

    #region 필기
    // 벡터의 요소
    // x : X축의 값
    // y : Y축의 값
    // z : Z축의 값
    // w : 셰이더나 수학 계산 등에서 사용되는 Vector4에서의 W축

    // ※ 값(value) vs 참조(reference)
    // 값 : 변수에 데이터가 직접 저장됩니다.(ex. int A = 5;)
    // 참조 : 변수에 데이터가 저장된 메모리 주소 값이 저장되는 경우
    //      ex) VectorSample = new VectorSample(); 클래스는 대표적인 참조 타입

    // ※ 메모리 저장 영역
    // 프로그램이 실행되기 위해서는 운영체제(OS)가 프로그램의 정보를 메모리에 로드해야 합니다.
    // 프로그램이 실행되는 동안 중앙 제어 장치(CPU)가 코드를 처리하기 위해 메모리가
    // 명령어와 데이터들을 저장하고 있어야 합니다.

    // 컴퓨터 메모리는 바이트(Byte) 단위로 번호가 새겨진 선형 공간을 의미합니다.
    // 낮은 주소부터 높은 주소까지 저장되는 영역이 다르게 설정되어 있습니다.

    // 낮은 주소 : 메모리의 시작 부분
    // 높은 주소 : 메모리의 끝 부분

    // 대표적인 메모리 공간
    // 1. 코드(code) : 실행할 프로그램 코드가 저장되는 영역(텍스트 영역)
    //                 CPU에서 저장된 명령을 하나씩 가져가서 처리합니다.
    //                 프로그램 시작 부터 종료까지 계속 남아있는 값.

    // 2. 데이터(data) : 프로그램에서 사용되는 전역 변수, 정적 변수가 저장되는 영역
    //    전역 변수(global) : 프로그램 어디서나 접근 가능한 변수
    //    (C#에서는 전역 대신 클래스 수준의 정적 변수를 사용합니다.)

    //    정적 변수(static) : static 키워드가 붙은 변수는 별도의 객체 생성 없이
    //    클래스명.변수명으로 직접 접근하는 것이 가능합니다.
    //          프로그램 시작 시에 할당이 되고 그 이후 부터 종료 시점까지 유지
    // + static과 일반은 다른 부분이기에 겹치지 않는다
    //   따라서 static을 사용하고 싶으면 클래스를 static으로 바꿔서 해야한다.

    // 3. 힙(heap) : 프로그래머가 직접 저장 공간에 대한 할당과 해제를 진행하는 영역
    //              값에 대한 등록도, 값에 대한 제거도 프로그래머가 설계합니다.(C,C++)
    //     특징) 참조 타입은 힙에 저장됩니다.
    //     C#의 힙 영역의 데이터는 GC에 의해 자동으로 관리됩니다.
    //     저장 순서, 정렬에 대한 작업을 따로 신경 쓸 필요가 없습니다.
    //     단 메모리가 크고, GC에 의해 자동으로 처리되는 만큼 많이 사용되면 그만큼 성능이 저하됩니다.
    //     접근 속도가 느린 편입니다.

    // 4. 스택(stack) : 프로그램이 자동으로 사용하는 임시 메모리 영역
    // 함수 호출 시 생성되는 변수(지역 변수, 매개변수)가 저장되는 영역
    // 함수의 호출이 완료되면 사라지는 데이터, 이때의 호출 정보 == stack frame(스택 프레임)
    // 매우 빠른 속도로 접근이 가능합니다.(할당과 해제의 비용이 사실상 없음)
    // 데이터가 먼저 들어온 데이터가 누적되고 가장 마지막에 남은 데이터가 먼저 제거되는 방식(LIFO)



    // 벡터의 특징
    // 1. 값 타입(value)으로 참조가 아닌 값 그 자체를 의미합니다. (구조체 struct)
    // --> 계산이 빠르게 처리됩니다.
    // 2. 값을 복사할 경우 값 그 자체를 복사하기만 하면 됩니다.

    // 3. 벡터에 대한 계산 보조 기능이 많이 제공됩니다.(magnitude, normalized(정규화), Dot, Cross...)
    // 4. 벡터는 스택(stack) 영역의 메모리에서 저장이 됩니다.  
    #endregion


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        E = A + B;
        F = C + (Vector3)D;
        Debug.Log(A);
        Debug.Log(B);
        Debug.Log(C);
        Debug.Log(D);
        Debug.Log(E);
        Debug.Log(F);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
