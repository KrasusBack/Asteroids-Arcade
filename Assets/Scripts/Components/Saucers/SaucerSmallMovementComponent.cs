using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerSmallMovementComponent : MovementConponentBase
{
    private Saucer _saucer;
    private CircleCollider2D _checkCollider;
    private Transform checkerObjectTransform;
    private Vector2 direction;

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

        contactFilter2D.SetLayerMask(LayerMask.GetMask(LayerMask.LayerToName(gameObject.layer)));

        var someAngle = 60;
        direction = GetRandomDirection(someAngle);
    }

    private void FixedUpdate()
    {
        ChangeDirectionBasedOnNearObjects();

        MoveKinematicRB(_saucer.MoveSpeed, direction);
        checkerObjectTransform.position = transform.position;
    }

    private void ChangeDirectionBasedOnNearObjects()
    {
        _checkCollider.OverlapCollider(contactFilter2D, collidersNear);

        if (collidersNear.Count == 0) return;
        print("Colliders near:");
        foreach (var collider in collidersNear)
        {
            print("--" + collider.name);
        }
    }

    private void OnDestroy()
    {
        Destroy(checkerObjectTransform.gameObject);
    }

}
