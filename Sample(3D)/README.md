# UnityBootCamp14
Unity BootCamp 14th Projects

# 유니티 기초

| 클래스 | 내용 | 설명 |
|-------|---|---|
| int | 정수형 변수 | -2,147,483,648 ~ 2,147,483,647 |
| float | 실수형 변수 | 소수점까지 출력 |
| string | 문자형 변수 | "s", $"{s}", "{0},s" 로 출력|

## 1. 하이어라키(Hierachy)
### 계층 창이라고 부르며, 모든 게임 오브젝트를 계층 구조, 텍스트로 표현.
> 씬에서 사용할 게임 오브젝트를 정렬하고 그룹화할 수 있습니다.

## 2. 씬(Scene)
### 유니티 에디터에서 생성한 월드를 시각화하고 상호작용 하는곳
> 배경, 캐릭터, 카메라, 광원 등에 대한 선택 조작 수정

## 3. 프로젝트(Project)
### 프로젝트 내에서 사용할 수 있는 에셋 라이브러리가 표시
> ※ 라이브러리 : 소프트웨어 개발에서 재사용이 가능한 코드 모음
> 
> ※ 에셋(Asset) : 유니티 내에서 사용하는 폴더, 동영상, 오브젝트 등을 칭하는 말 >> 게임 제작에 필요한 모든 요소를 지칭
> 
> 사용중인 에셋별로 별도의 메타 타입이 생성.

## 4. 콘솔(Console)
### 디버그 확인용 창

## 5. 인스펙터(Inspector)
### 게임 오브젝트 정보를 알 수 있는 창
> 선택한 게임 오브젝트의 속성(Property)을 통해 편집이 가능.

### GameObject
+ GetComponant<T>
  + GameObject Componant의 Data를 호출
  + 이 기능을 통해 받아오는 값 --> T
> GameObject.GetComponant<T>.value : GameObject의 Componant안에 있는 value라는 값을 호출

+ FindWithTag("T")
  + 씬에서 해당 태그를 가지고 있는 오브젝트를 검색하는 기능
  + 이 기능을 통해 받아오는 값 --> GameObject
>  GameObject.FindWithTag("s1") : s1이라는 Tag를 가진 Object를 검색, Object를 찾아오기에 GetComponent 사용가능

### OnTriggerEnter : Trigger가 Enter(작동)했을 때 호출
+ CompareTag("T")
  + Tag를 T와 같은지 비교하는 연산
> other.gameObject.CompareTag("T") : Trigger가 작동된 Object의 Tag를 비교, T와 동일하다면 호출

### Vector
#### 물리적 위치(방향)을 의미
|변수|값|형태|
|----|---|---|
|Vector2|x, y|float|
|vector3|x, y, z|float|

### Enum
#### 하나 혹은 그 이상을 선택하여 값을 부여
> [Flags] enum : 여러개를 선택할 수 있는 기능, 값을 2의 제곱수로 표현가능
>
> ex) 물 1 << 0, 불 1 << 1, 바람 1 << 2, 번개
> 
> Tip) 1bit로 자동으로 배치, "번개"는 (1 << 2 + 1) 임으로 "바람 + 물"을 가지고 있음,
> << 비트연산은 임의로 지정하는 것이 보기좋음
