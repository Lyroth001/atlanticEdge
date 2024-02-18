using System.Linq;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;

public class newLeverScript : MonoBehaviour
{
    public RotoController RotoController;
    public MechaController mech;
    public Transform MechTransform;
    private Transform _transform;
    private XRSimpleInteractable _simpleInteractable;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Vector3 originEuler = _transform.localEulerAngles;
        _transform = GetComponent<Transform>();
        _simpleInteractable = GetComponent<XRSimpleInteractable>();

    }

    // Update is called once per frame
    void Update()
    {
        if (_simpleInteractable.interactorsSelecting.Any())
        {
            var interactVector = Vector3.Cross(_transform.forward, (_simpleInteractable.interactorsSelecting[0].transform.position - _transform.position));
            var leverAngle = Mathf.Clamp(Vector3.Angle(interactVector, MechTransform.up),-45f,45f);
            _transform.up = Quaternion.AngleAxis(leverAngle, _transform.right) * MechTransform.up;
        }
    }
}
