using Code.Data.Configs;
using Code.Data.GameData;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Code.Logic.DayOfTime
{
    public class DirectionLightingToggle : MonoBehaviour
    {
        [SerializeField] private Light _directionLight;

        private LightingSettings _lightingSettings;
        private TimeOfDayController _timeOfDayController;
        private float _animationDuration;


        [Inject]
        private void Construct(TimeOfDayController timeOfDayController, GameSettings gameSettings)
        {
            _timeOfDayController = timeOfDayController;
            _lightingSettings = gameSettings.LightingSettings;
            _animationDuration = gameSettings.DurationOfDayTime;
        }

        private void Start()
        {
            SubscribeToEvent();
            SetLighting(_timeOfDayController.dayTimeNormalized);
        }

        private void OnDestroy()
        {
            UnsubscribeToEvent();
        }

        private void SubscribeToEvent()
        {
            _timeOfDayController.OnMorning += SetMorningLighting;
            _timeOfDayController.OnEvening += SetEveningLighting;
            _timeOfDayController.OnNight += SetNightLighting;
        }

        private void UnsubscribeToEvent()
        {
            _timeOfDayController.OnMorning -= SetMorningLighting;
            _timeOfDayController.OnEvening -= SetEveningLighting;
            _timeOfDayController.OnNight -= SetNightLighting;
        }

        private void SetMorningLighting()
        {
            var angle = _lightingSettings.morningAngle;
            var intensity = _lightingSettings.morningIntensity;
            SetLighting(angle, intensity);
        }

        private void SetEveningLighting()
        {
            var angle = _lightingSettings.eveningAngle;
            var intensity = _lightingSettings.eveningIntensity;
            SetLighting(angle, intensity);
        }

        private void SetNightLighting()
        {
            var angle = _lightingSettings.nightAngle;
            var intensity = _lightingSettings.nightIntensity;
            SetLighting(angle, intensity);
        }

        private void SetLighting(Vector3 angle, float intensity)
        {
            _directionLight.transform.DOLocalRotate(angle, _animationDuration).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
            _directionLight.DOIntensity(intensity, _animationDuration).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
        }

        private void SetLighting(float dayTimeNormalized)
        {
            var targetAngle = Mathf.Lerp(_lightingSettings.morningAngle.y, _lightingSettings.eveningAngle.y,
                dayTimeNormalized);
            _directionLight.transform.DOLocalRotate(
                new Vector3(targetAngle, _lightingSettings.morningAngle.x, _lightingSettings.morningAngle.z), 0).SetLink(gameObject, LinkBehaviour.KillOnDestroy);

            var targetIntensity = Mathf.Lerp(_lightingSettings.morningIntensity, _lightingSettings.nightIntensity,
                dayTimeNormalized);
            _directionLight.DOIntensity(targetIntensity, 0).SetLink(gameObject, LinkBehaviour.KillOnDestroy);
        }
    }
}