using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Array : MonoBehaviour
{
    public enum ElementType
    {
        Empty,
        Selected,
        Filled,
        Finished
    }

    private Material emptyMat;
    private Material selectedMat;
    private Material filledMat;
    private Material finishedMat;

    private void Start()
    {
        Shader shader = Shader.Find("Universal Render Pipeline/Lit");
        emptyMat = new Material(shader);
        emptyMat.color = Utils.GetColor("#E0E0E0"); // #E0E0E0
        selectedMat = new Material(shader);
        selectedMat.color = Utils.GetColor("#A5D8FF"); // #A5D8FF
        filledMat = new Material(shader);
        filledMat.color = Utils.GetColor("#FFD6A5"); // #FFD6A5
        finishedMat = new Material(shader);
        finishedMat.color = Utils.GetColor("#B2F2BB"); // #B2F2BB
    }

    private List<ElementType> Elements;
    public int Size { get; set; }
    private List<Transform> cubes = new List<Transform>();
    private List<int> numbers;

    public void Initialize()
    {
        Elements = new List<ElementType>();

        GenerateArray();
    }

    void GenerateArray()
    {
        for (int i = 0; i < Size; i++)
        {
            Elements.Add(ElementType.Empty);
        }
    }

    private IEnumerator GenerateRandomNumbers(List<MeshRenderer> meshRenderers)
    {
        var set = new HashSet<int>();

        while (set.Count < Size)
        {
            set.Add(Random.Range(0, Size));
        }

        numbers = new List<int>(set);

        for (int i = 0; i < numbers.Count; i++)
        {
            meshRenderers[i].sharedMaterial = GetElementColor(ElementType.Filled);

            CreateTextObject(
                parent: meshRenderers[i].transform,
                localPos: new Vector3(0f, 0f, -0.5f),
                text: $"{numbers[i]}",
                fontSize: 5,
                color: Color.black
            );

            yield return new WaitForSeconds(0.2f);
        }
    }

    private const float GAP = 0.15f;
    private const float CUBE_SIZE = 1f;

    public void Spawn()
    {
        List<MeshRenderer> meshRenderers = new List<MeshRenderer>();

        float step = CUBE_SIZE + GAP;

        for (int i = 0; i < Size; i++)
        {
            GameObject cubeObj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cubeObj.transform.position = new Vector3(i * step, 0, 0);
            cubeObj.transform.SetParent(transform);

            cubes.Add(cubeObj.transform);

            var mr = cubeObj.GetComponent<MeshRenderer>();
            meshRenderers.Add(mr);
            mr.sharedMaterial = GetElementColor(Elements[i]);

            CreateTextObject(
                parent: cubeObj.transform,
                localPos: new Vector3(0f, -0.8f, 0f),
                text: $"[{i}]",
                fontSize: 2.5f,
                color: Color.white
            );
        }

        StartCoroutine(GenerateRandomNumbers(meshRenderers));
    }

    private TextMeshPro CreateTextObject(Transform parent, Vector3 localPos, string text, float fontSize, Color color)
    {
        GameObject textObj = new GameObject("TMP_" + text);
        textObj.transform.SetParent(parent, false);
        textObj.transform.localPosition = localPos;
        textObj.transform.localRotation = Quaternion.identity;

        var tmp = textObj.AddComponent<TextMeshPro>();
        tmp.text = text;
        tmp.fontSize = fontSize;
        tmp.color = color;
        tmp.alignment = TextAlignmentOptions.Center;
        tmp.rectTransform.sizeDelta = new Vector2(2f, 1f);

        return tmp;
    }

    public IEnumerator SelectionSort()
    {
        for (int i = 0; i < Size - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < cubes.Count; j++)
            {
                if (numbers[minIndex] >= numbers[j])
                    minIndex = j;
            }

            if (minIndex != i)
            {
                // 애니메이션 스왑
                yield return StartCoroutine(SwapAnimated(i, minIndex));

                // 데이터 스왑 (numbers / cubes 모두)
                int tempNum = numbers[i];
                numbers[i] = numbers[minIndex];
                numbers[minIndex] = tempNum;

                GameObject tempCube = cubes[i].gameObject;
                cubes[i] = cubes[minIndex];
                cubes[minIndex] = tempCube.transform;

                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                SetElementColor(i, ElementType.Finished);
            }
        }

        for (int i = 0; i < Size; i++)
            SetElementColor(i, ElementType.Finished);
    }

    [Header("Swap Animation")]
    public float liftHeight = 1.0f;   // 위로 솟는 높이
    public float liftTime = 0.15f;  // 들어올리는 시간
    public float moveTime = 0.25f;  // 수평 이동 시간
    public float dropTime = 0.15f;  // 내리는 시간
    public float betweenDelay = 0.05f; // 단계 사이 약간의 딜레이

    private IEnumerator SwapAnimated(int aIndex, int bIndex)
    {
        SetElementColor(aIndex, ElementType.Selected);
        SetElementColor(bIndex, ElementType.Selected);

        Transform a = cubes[aIndex];
        Transform b = cubes[bIndex];

        Vector3 aStart = a.position;
        Vector3 bStart = b.position;

        // 1) 동시에 들어올리기 (a는 h, b는 2h)
        Vector3 aLiftTarget = aStart + Vector3.up * liftHeight;
        Vector3 bLiftTarget = bStart + Vector3.up * (liftHeight * 2f);
        yield return MoveBoth(a, aLiftTarget, b, bLiftTarget, liftTime);
        yield return new WaitForSeconds(betweenDelay);

        // 2) 동시에 수평 이동
        Vector3 aTopTarget = new Vector3(bStart.x, aLiftTarget.y, aLiftTarget.z);
        Vector3 bTopTarget = new Vector3(aStart.x, bLiftTarget.y, bLiftTarget.z);
        yield return MoveBoth(a, aTopTarget, b, bTopTarget, moveTime);
        yield return new WaitForSeconds(betweenDelay);

        // 3) 동시에 내리기(최종 자리)
        Vector3 aFinal = new Vector3(bStart.x, bStart.y, bStart.z);
        Vector3 bFinal = new Vector3(aStart.x, aStart.y, aStart.z);
        yield return MoveBoth(a, aFinal, b, bFinal, dropTime);
        SetElementColor(bIndex, ElementType.Finished);
        SetElementColor(aIndex, ElementType.Filled);
    }

    public IEnumerator BubbleSort()
    {
        // numbers / cubes 준비 대기 (필요시)
        while (numbers == null || numbers.Count != cubes.Count)
            yield return null;

        int n = numbers.Count;

        // 초기 상태 색(선택) — 이미 Filled라면 생략 가능
        for (int k = 0; k < n; k++)
            SetElementColor(k, ElementType.Filled);

        for (int i = 0; i < n - 1; i++)
        {
            bool swapped = false;

            for (int j = 0; j < n - 1 - i; j++)
            {
                // 비교 중인 두 개 강조
                SetElementColor(j, ElementType.Selected);
                SetElementColor(j + 1, ElementType.Selected);

                if (numbers[j] > numbers[j + 1])
                {
                    // 애니메이션 스왑(완료 마킹 없는 버전 사용)
                    yield return StartCoroutine(SwapAnimatedNoFinish(j, j + 1));

                    // 데이터 스왑 (numbers / cubes)
                    int tmpNum = numbers[j];
                    numbers[j] = numbers[j + 1];
                    numbers[j + 1] = tmpNum;

                    Transform tmpTf = cubes[j];
                    cubes[j] = cubes[j + 1];
                    cubes[j + 1] = tmpTf;

                    swapped = true;
                }

                // 비교 끝 — 다시 Filled로 되돌림
                SetElementColor(j, ElementType.Filled);
                SetElementColor(j + 1, ElementType.Filled);

                yield return new WaitForSeconds(0.05f); // 템포 조절
            }

            // 이번 라운드의 마지막 원소는 확정
            SetElementColor(n - 1 - i, ElementType.Finished);

            // 더 이상 바뀔 게 없으면 조기 종료
            if (!swapped) break;
        }

        // 남은 앞쪽 원소들도 Finished로 마무리
        for (int k = 0; k < n; k++)
            SetElementColor(k, ElementType.Finished);
    }

    private IEnumerator SwapAnimatedNoFinish(int aIndex, int bIndex)
    {
        // 색상 마킹은 호출부(BubbleSort)에서 처리하므로 여기서는 건드리지 않음

        Transform a = cubes[aIndex];
        Transform b = cubes[bIndex];

        Vector3 aStart = a.position;
        Vector3 bStart = b.position;

        // 1) 동시에 들어올리기
        Vector3 aLiftTarget = aStart + Vector3.up * liftHeight;
        Vector3 bLiftTarget = bStart + Vector3.up * liftHeight;
        yield return MoveBoth(a, aLiftTarget, b, bLiftTarget, liftTime);
        yield return new WaitForSeconds(betweenDelay);

        // 2) 동시에 수평 이동
        Vector3 aTopTarget = new Vector3(bStart.x, aLiftTarget.y, aLiftTarget.z);
        Vector3 bTopTarget = new Vector3(aStart.x, bLiftTarget.y, bLiftTarget.z);
        yield return MoveBoth(a, aTopTarget, b, bTopTarget, moveTime);
        yield return new WaitForSeconds(betweenDelay);

        // 3) 동시에 내리기(최종 자리)
        Vector3 aFinal = new Vector3(bStart.x, bStart.y, bStart.z);
        Vector3 bFinal = new Vector3(aStart.x, aStart.y, aStart.z);
        yield return MoveBoth(a, aFinal, b, bFinal, dropTime);
    }

    private IEnumerator MoveBoth(Transform a, Vector3 aTarget, Transform b, Vector3 bTarget, float duration)
    {
        Vector3 a0 = a.position;
        Vector3 b0 = b.position;

        float t = 0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            float u = Mathf.Clamp01(t / duration);
            float e = Mathf.SmoothStep(0f, 1f, u);

            a.position = Vector3.LerpUnclamped(a0, aTarget, e);
            b.position = Vector3.LerpUnclamped(b0, bTarget, e);

            yield return null;
        }

        a.position = aTarget;
        b.position = bTarget;
    }

    private void SetElementColor(int index, ElementType type)
    {
        cubes[index].GetComponent<MeshRenderer>().sharedMaterial = GetElementColor(type);
    }

    private Material GetElementColor(ElementType type)
    {
        switch (type)
        {
            case ElementType.Empty:
                return emptyMat;
            case ElementType.Selected:
                return selectedMat;
            case ElementType.Filled:
                return filledMat;
            default:
                return finishedMat;
        }
    }
}