using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerSmallMovementComponent : MovementConponentBase
{
    private Saucer _saucer;
    private CircleCollider2D _checkCollider;
    private Transform checkerObjectTransform;
    private Vector2 direction;

    private bool timeToCheck = true;

    List<Collider2D> collidersNear = new List<Collider2D>();
    ContactFilter2D contactFilter2D = new ContactFilter2D();
    //появиться там где нет астероида (проверка пригодиться еще и для hyperSpace)
    //задать изначальный вектор
    //раз в n времени сменять направление / сменять направление если встречает препятствие на пути (раз в n времени проверки (зависит от мастерства movement)
    //
    //при любом задании направления проверять есть ли препятствие на пути
    private void Start()
    {
        _saucer = GetComponent<SaucerSettingsComponent>().GetSettings();
        //create obstacles checker object
        var checkerObject = new GameObject("obstaclesChecker");
        checkerObjectTransform = checkerObject.transform;
        checkerObjectTransform.position = transform.position;
        checkerObject.tag = tag;
        checkerObject.layer = gameObject.layer;

        _checkCollider = checkerObject.AddComponent<CircleCollider2D>();
        _checkCollider.isTrigger = true;
        //change collider checker radious based on its size and avoiding obstacles mastery 
        _checkCollider.radius = GetComponent<Renderer>().bounds.max.magnitude + _saucer.AvoidingObstaclesMastery * _saucer.MoveSpeed;

        //checkerObject.AddComponent<ObstaclesCheckerComponent>().SomethingFoundOnTheWay += ChangeDirectionBasedOnNearObjects;
        //var checkerComponent = checkerObject.AddComponent<ObstaclesCheckerComponent>();
        //var setUpCheckerComponent = new ObstaclesCheckerComponent(ChangeDirectionBasedOnNearObject);
        //checkerComponent = setUpCheckerComponent;

        //contactFilter2D.SetLayerMask(LayerMask.GetMask(LayerMask.LayerToName(gameObject.layer)));
        contactFilter2D.SetLayerMask(LayerMask.GetMask("Player", "Asteroids"));
        contactFilter2D.useTriggers = true;
        print("mask " + contactFilter2D.layerMask.value);

        var someAngle = 60;
        direction = GetRandomDirection(someAngle);

        StartCoroutine(WaitForTheNextObstaclesCheck());
    }

    private void FixedUpdate()
    {
        if (timeToCheck)
        {
            timeToCheck = false;
            ChangeDirectionBasedOnNearObjects();
        }
        MoveKinematicRB(_saucer.MoveSpeed, direction);
        checkerObjectTransform.position = transform.position;
    }

    private void ChangeDirectionBasedOnNearObjects()
    {
        _checkCollider.OverlapCollider(contactFilter2D, collidersNear);

        if (collidersNear.Count == 0) return;

        float minDistance = float.MaxValue;
        Collider2D nearestCollider = new Collider2D();
        List<Vector2> nearCollidersPositions = new List<Vector2>();

        //find nearest collider to avoid
        for (var i = 0; i < collidersNear.Count; i++)
        {
            nearCollidersPositions.Add(collidersNear[i].transform.position);
            var distance = Vector2.Distance(transform.position, nearCollidersPositions[i]);
            if (distance < minDistance)
            {
                minDistance = distance;
                nearestCollider = collidersNear[i];
            }
            //print("--" + collider.name);
        }

        if (!nearestCollider) return;

        print("nearest collider: " + nearestCollider.name);
        
        //что-то сделать с minDistance
        Vector2 directionToNearestCollider = nearestCollider.transform.position - transform.position;
        var currentDirectionAngle = Vector2.SignedAngle(direction, Vector2.right);
        var toNearestColliderDirectionAngle = Vector2.SignedAngle(directionToNearestCollider, Vector2.right);
        var safeAngle = 15;
        if (currentDirectionAngle - toNearestColliderDirectionAngle > safeAngle) return;
        direction = Vector2.Reflect(MathfExtentions.DegreeToVector2(toNearestColliderDirectionAngle), direction);
        
        //min time = 0.2f
    }

    private IEnumerator WaitForTheNextObstaclesCheck()
    {
        while(true)
        {
            timeToCheck = true;
            yield return new WaitForSeconds(1.15f - _saucer.AvoidingObstaclesMastery);
        }
    }

    private void OnDestroy()
    {
        Destroy(checkerObjectTransform.gameObject);
    }

}
