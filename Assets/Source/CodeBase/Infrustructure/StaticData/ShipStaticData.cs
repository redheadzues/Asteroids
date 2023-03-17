using Assets.Source.CodeBase.Entities;
using UnityEngine;

namespace Assets.Source.CodeBase.Infrustructure.StaticData
{
    [CreateAssetMenu(fileName = "ShipStaticData", menuName = "StaticData/ShipStaticData")]
    public class ShipStaticData : ScriptableObject
    {
        [field: SerializeField] public EntityType EntityType { get; private set; }
        [field: SerializeField] public float Acceleration { get; private set; }
        [field: SerializeField] public float Deceleration { get; private set; }
        [field: SerializeField] public float MaxSpeed { get; private set; }
        [field: SerializeField] public float RotationSpeed { get; private set; }
        [field: SerializeField] public Vector2 StartPosition { get; private set; }
        [field: SerializeField] public Quaternion StartRotation { get; private set; }
    }
}