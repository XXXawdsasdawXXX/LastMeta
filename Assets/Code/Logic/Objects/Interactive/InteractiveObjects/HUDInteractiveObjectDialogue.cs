using System;
using System.Linq;
using Code.Audio.AudioEvents;
using Code.PresentationModel.HeadUpDisplay;
using Code.PresentationModel.Windows;
using Code.Services;
using UnityEngine;
using Zenject;

namespace Code.Logic.Interactive.InteractiveObjects
{
    public class HUDInteractiveObjectDialogue : Interactivity, IEventSubscriber
    {
        [SerializeField] private TextAsset _textAsset;
        [SerializeField] private AudioEvent _layerAudio;

        private IDialogueWindow _presentationWindow;
        private bool _isWindowNull;

        [Inject]
        private void Construct(Hud hud)
        {
            hud.InteractiveObjectWindows
                .FirstOrDefault(w => w.Type == Type)?
                .InteractiveObjectWindow
                .TryGetComponent(out _presentationWindow);

            _isWindowNull = _presentationWindow == null;
        }

        private void OnEnable()
        {
            SubscribeToEvent(true);
        }

        private void OnDisable()
        {
            SubscribeToEvent(false);
        }

        public override void StartInteractive()
        {
            if (_isWindowNull)
                return;

            OnAnimationProcess = true;
            OnStartInteractive?.Invoke();

            _layerAudio.PlayAudioEvent();
            _presentationWindow.ShowWindow(WindowShowed: WindowShowed);
        }

        private void WindowShowed()
        {
            if (_isWindowNull)
                return;

            OnAnimationProcess = false;
            _presentationWindow.DialogueController.StartDialogue(_textAsset);
            _presentationWindow.DialogueController.OnStopDialogue += StopInteractive;
        }

        public override void StopInteractive()
        {
            if (_isWindowNull)
                return;

            _presentationWindow.DialogueController.OnStopDialogue -= StopInteractive;
            OnAnimationProcess = true;
            OnStopInteractive?.Invoke();

            _layerAudio.PlayAudioEvent();
            _presentationWindow.HideWindow(() => OnAnimationProcess = false);
        }

        public void SubscribeToEvent(bool flag)
        {
            if (flag)
            {
                _presentationWindow.DialogueController.OnDialogueIsEnd += () => OnEndInteractive?.Invoke();
            }
            else
            {
                _presentationWindow.DialogueController.OnDialogueIsEnd -= () => OnEndInteractive?.Invoke();
            }
        }
    }
}