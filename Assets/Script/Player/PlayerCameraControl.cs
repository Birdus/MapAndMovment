using UnityEngine;

public class PlayerCameraControl : MonoBehaviour
{
    public Camera cam;
    public Transform target;

    public LayerMask obdtacles;
    public LayerMask noPlayer;
    private float _scroll;
    public float wheel_speed = 100f;
    public float maxZoom = 40f;
    public float minZoom = 0f;

    public float speedX = 360f;
    public float speedY = 240f;

    public float limitY = 40f;
    public float minDistance = 1.5f;
    public float hideDistance = 2f;

    private float _maxDistance;
    private Vector3 _localPosition;
    private float _currentYRotation;
    private LayerMask _camOriginMasc;

    private Vector3 _position
    {
        get { return transform.position; }
        set { transform.position = value; }
    }

    void Start()
    {
        _localPosition = target.InverseTransformPoint(_position);
        _maxDistance = Vector3.Distance(_position, target.position);
        _camOriginMasc = cam.cullingMask;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _position = target.TransformPoint(_localPosition);
        CameraRotation();
        ObstacleReact();
        PlayerReact();
        _localPosition = target.InverseTransformPoint(_position);
    }

    private void CameraRotation()
    {
        var mx = Input.GetAxis("Mouse X");
        var my = Input.GetAxis("Mouse Y");
        _scroll = Input.GetAxis("Mouse ScrollWheel");
        
        if (my != 0)
        {
            var tmp = Mathf.Clamp(_currentYRotation + my * speedY * Time.deltaTime, -limitY, limitY);
            if (tmp != _currentYRotation)
            {
                var rot = tmp - _currentYRotation;
                transform.RotateAround(target.position, transform.right, rot);
                _currentYRotation = tmp;
            }
        }
        if (mx != 0)
        {
            transform.RotateAround(target.position, Vector3.up, mx * speedX * Time.deltaTime);
        }
        if (Input.mouseScrollDelta.y > 0)
        {
            if (Vector3.Distance(target.position,transform.position ) > minZoom)
            {
                transform.position += Time.deltaTime * wheel_speed * transform.forward;
            }
        }
        if (Input.mouseScrollDelta.y < 0)
        {
            if (Vector3.Distance(target.position, transform.position) < maxZoom)
            {
                transform.position -= transform.forward * Time.deltaTime * wheel_speed;
            }
        }

        transform.LookAt(target);
    }

    private void ObstacleReact()
    {
        var distance = Vector3.Distance(_position, target.position);
        
        RaycastHit hit;
        if (Physics.Raycast(target.position, transform.position - target.position, out hit, _maxDistance, obdtacles))
        {
            _position = hit.point;
        }
        else if (distance < _maxDistance && !Physics.Raycast(_position, -transform.forward, .1f, obdtacles))
        {
            _position -= transform.forward * .05f;
        }
    }

    private void PlayerReact()
    {
        var distance = Vector3.Distance(_position, target.position);
        if (distance < hideDistance)
            cam.cullingMask = noPlayer;
        else
            cam.cullingMask = _camOriginMasc;
    }
}
