using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;

[RequireComponent(typeof(Collider))]
public class WeepingAngel : BaseAngel {

    private Collider _Collider;
    
    private float _MovementVelocity;

    protected void Awake() {
        _Collider = GetComponent<Collider>();
    }

    protected void OnEnable() {
        base.OnEnable();
    }

    public override void OnBeingShoot() {
        Debug.Log("SUCCESS!");

        DestroyAngel();
    }

    protected void Update() {
        if (Vector2.Distance(transform.position.FromMapPos(), _Settings.AngelsAttackPosition) < 
                _Settings.GameplaySettings.AngelsWinRadius) {
            Debug.Log("ANGELS WIN");
            return;
        }
        
        var planes = GeometryUtility.CalculateFrustumPlanes(Camera.main);
        if (GeometryUtility.TestPlanesAABB(planes, _Collider.bounds)) {
            // angel visible - stop movement!
            _MovementVelocity = 0.0f;
        } else {
            // angel invisible - start movement!
            if (Math.Abs(_MovementVelocity) < 0.001f) {
                _MovementVelocity = _Settings.NewAngelMovementSpeed();
            }
        }
        
        var position = new Vector2(transform.position.x, transform.position.z);
        var movDelta = (Time.deltaTime * _MovementVelocity *
                        (_Settings.AngelsAttackPosition - (Vector2) position).normalized);
        transform.position += movDelta.ToMapPos();
    }

}