using UnityEngine;

/*
 Sample2 Script�� ���� ���� ���� �����մϴ�.
 ȭ�鿡�� field of view�� ��ũ�� ��� ���� �����մϴ�. 
 */
public enum Projection
{
    Perspective,
    Orthographic
}

public enum Field_Of_View_Axis
{
    Vertical, 
    Horizontal
}

public class Sample2 : MonoBehaviour
{
    public Projection Projection;
    public Field_Of_View_Axis FieldOfViewAxis;
    public float FieldOfView;
    public float ClippingPlanesNear;
    public float ClippingPlanesFar;
    public bool PhysicalCamera;
    // �빮�ڷ� �����ϸ� �ڵ� ����

}
