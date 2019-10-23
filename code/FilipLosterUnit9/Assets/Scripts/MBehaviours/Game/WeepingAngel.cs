using System;
using TinyMessenger;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;

[RequireComponent(typeof(Collider))]
public class WeepingAngel : BaseAngel {

    private Collider _Collider;
    
    private float _MovementVelocity;

    private float _MovementDelay;

    protected void Awake() {
        _Collider = GetComponent<Collider>();
    }

    protected override void OnEnable() {
        base.OnEnable();

        _MovementDelay = _Settings.NewAngelMovmentDelay();
    }

    public override void OnBeingShoot() {
        Debug.Log("SUCCESS!");

        DestroyAngel();
    }

    protected void Update() {
        var distanceToTarget = Vector2.Distance(
            transform.position.FromMapPos(), 
            _Settings.AngelsAttackPosition);
        
        if (distanceToTarget < _Settings.GameplaySettings.AngelsWinRadius) {
            TinyMessengerHub
                .Instance
                .Publish(Msg.AngelsWon.Get());
            return;
        }

        // wait for movement if delay set
        if (_MovementDelay > 0) {
            _MovementDelay -= Time.deltaTime;
            return;
        }
        
        var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (GeometryUtility.TestPlanesAABB(planes, _Collider.bounds)) {
            // angel visible - stop movement!
            _MovementVelocity = 0.0f;
        } else {
            // angel invisible - start movement!
            _MovementVelocity = _Settings.GetAngelVelocity(distanceToTarget);
        }
        
        var position = transform.position.FromMapPos();
        var movDelta = (Time.deltaTime * _MovementVelocity *
                        (_Settings.AngelsAttackPosition - position).normalized);
        transform.position += movDelta.ToMapPos();
    }

}