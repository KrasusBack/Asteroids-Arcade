using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerSmallMovementComponent : MovementConponentBase
{
    private Saucer _saucer;
    private CircleCollider2D _checkCollider;
    private Transform _checkerObjectTransform;
    private Vector2 _direction;
    private float _checkInterval = 0.2f;
    private bool _timeToCheck = true;

    List<Collider2D> collidersNear = new List<Collider2D>();
    ContactFilter2D contactFilter2D = new ContactFilter2D();

    private void Start()
    {
        _saucer = GetComponent<SaucerSettingsComponent>().GetSettings();
        //create obstacles checker object
        CreateAndSetUpObstaclesCheckerObject();

        var someAngle = 60;
        _direction = GetRandomDirection(someAngle);

        StartCoroutine(WaitForTheNextObstaclesCheck());
    }

    private void CreateAndSetUpObstaclesCheckerObject()
    {
        var checkerObject = new GameObject("obstaclesChecker");
        _checkerObjectTransform = checkerObject.transform;
        _checkerObjectTransform.position = transform.position;
        checkerObject.tag = tag;
        checkerObject.layer = gameObject.layer;
        _checkCollider = checkerObject.AddComponent<CircleCollider2D>();
        _checkCollider.isTrigger = true;
        //change collider checker radious based on its size and avoiding obstacles mastery 
        _checkCollider.radius = GetComponent<Renderer>().bounds.size.magnitude * 2 + _saucer.MoveSpeed;
        contactFilter2D.SetLayerMask(LayerMask.GetMask("Player", "Asteroids"));
        contactFilter2D.useTriggers = true;
    }

    private void FixedUpdate()
    {
        //for debug: perpendicular line end pos
        Vector3 perpen = _checkerObjectTransform.position;

        if (_timeToCheck)
        {
            _timeToCheck = false;
            perpen = ChangeDirectionBasedOnNearObjects();
        }
        MoveKinematicRB(_saucer.MoveSpeed, _direction);
        _checkerObjectTransform.position = transform.position;

        /* //Show debug lines
        var multiplier = 8;
        Vector3 endPos = new Vector3(checkerObjectTransform.position.x + direction.x * multiplier, 
                                        checkerObjectTransform.position.y + direction.y * multiplier, 
                                        checkerObjectTransform.position.z);
        Debug.DrawLine(checkerObjectTransform.position, endPos, Color.cyan);
        Debug.DrawLine(checkerObjectTransform.position, perpen, Color.red);
        */
    }

    private Vector3 ChangeDirectionBasedOnNearObjects() //<-change back to void
    {
        _checkCollider.OverlapCollider(contactFilter2D, collidersNear);

        if (collidersNear.Count == 0) return _checkerObjectTransform.position;

        float minDistance = float.MaxValue;
        Vector3 nearestColliderPos = Vector3.zero;
        //find nearest collider to avoid
        for (var i = 0; i < collidersNear.Count; i++)
        {
            var closestPos = collidersNear[i].ClosestPoint(_checkerObjectTransform.position);
            var distance = Vector2.Distance(transform.position, closestPos);
            if (distance < minDistance)
            {
                nearestColliderPos = closestPos;
                minDistance = distance;
            }
        }

        //if (!nearestCollider) return _checkerObjectTransform.position;

        //print("nearest collider: " + nearestCollider.name);

        //что-то сделать с minDistance
        Vector2 directionToNearestCollider = nearestColliderPos - _checkerObjectTransform.position;
        var currentDirectionAngle = Vector2.SignedAngle(Vector2.right, _direction);
        var toNearestColliderDirectionAngle = Vector2.SignedAngle(Vector2.right, directionToNearestCollider);

        var safeAngle = 30 + 330 * _saucer.AvoidingObstaclesMastery;
        //if (Mathf.Abs( currentDirectionAngle - toNearestColliderDirectionAngle) > safeAngle) return checkerObjectTransform.position;
        if (currentDirectionAngle - toNearestColliderDirectionAngle > safeAngle) return _checkerObjectTransform.position;

        var toNearestColliderDirection = MathfExtentions.DegreeToVector2(toNearestColliderDirectionAngle);
        //currently good enough version
        _direction = -(Vector2.Perpendicular(toNearestColliderDirection).normalized + toNearestColliderDirection.normalized);
        //or just like this:
        //_direction = Vector2.Perpendicular(toNearestColliderDirection);

        var multiplier = 4;
        Vector3 endPos = new Vector3(_checkerObjectTransform.position.x + toNearestColliderDirection.x * multiplier,
                                        _checkerObjectTransform.position.y + toNearestColliderDirection.y * multiplier,
                                        _checkerObjectTransform.position.z);

        //min time = 0.2f
        return endPos;
    }

    private IEnumerator WaitForTheNextObstaclesCheck()
    {
        while (true)
        {
            _timeToCheck = true;
            yield return new WaitForSeconds(_checkInterval);
        }
    }

    private void OnDestroy()
    {
        Destroy(_checkerObjectTransform.gameObject);
    }

}
