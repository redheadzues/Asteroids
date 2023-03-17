using System;
using TMPro;
using UnityEngine;

namespace Assets.Source.CodeBase.UI
{
    public class UiHud : MonoBehaviour
    {
        [SerializeField] private TMP_Text _coordinatesText;
        [SerializeField] private TMP_Text _angleText;
        [SerializeField] private TMP_Text _velocityText;
        [SerializeField] private TMP_Text _reloadTimeText;
        [SerializeField] private TMP_Text _ammoCountText;

        private IReadOnlyObservable<Vector2> _coordinates;
        private IReadOnlyObservable<Quaternion> _angle;
        private IReadOnlyObservable<Vector2> _velocity;
        private IReadOnlyObservable<float> _reloadTime;
        private IReadOnlyObservable<int> _ammoCount;

        public void Construct(IReadOnlyObservable<Vector2> position,
            IReadOnlyObservable<Quaternion> rotation,
            IReadOnlyObservable<Vector2> velocity,
            IReadOnlyObservable<float> reload,
            IReadOnlyObservable<int> ammoCount)
        {
            _coordinates = position;
            _angle = rotation;
            _velocity = velocity;
            _reloadTime = reload;
            _ammoCount = ammoCount;

            _coordinates.ValueChanged += OnCoordinatesChanged;
            _angle.ValueChanged += OnRotationChanged;
            _velocity.ValueChanged += OnVelocityChanged;
            _reloadTime.ValueChanged += OnReloadTimeChanged;
            _ammoCount.ValueChanged += OnAmmoCountChanged;
        }


        private void OnDisable()
        {
            if(_coordinates != null)
            {
                _coordinates.ValueChanged -= OnCoordinatesChanged;
                _angle.ValueChanged -= OnRotationChanged;
                _velocity.ValueChanged -= OnVelocityChanged;
                _reloadTime.ValueChanged -= OnReloadTimeChanged;
                _ammoCount.ValueChanged -= OnAmmoCountChanged;
            }
        }

        private void OnAmmoCountChanged(int ammo) => 
            _ammoCountText.text = ammo.ToString();

        private void OnReloadTimeChanged(float time) => 
            _reloadTimeText.text = Math.Round(time, 2).ToString();

        private void OnVelocityChanged(Vector2 velocity) => 
            _velocityText.text = (velocity.magnitude * 1000).ToString();

        private void OnRotationChanged(Quaternion rotation) => 
            _angleText.text = Mathf.RoundToInt(rotation.eulerAngles.z).ToString();

        private void OnCoordinatesChanged(Vector2 position) => 
            _coordinatesText.text = position.ToString();
    }
}
