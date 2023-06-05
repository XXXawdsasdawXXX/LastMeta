using System.Linq;
using Code.Data.Configs;
using Code.UI;
using Code.UI.HeadUpDisplay;
using Code.UI.Windows;
using Ink.Runtime;
using UnityEngine;
using Zenject;

namespace Code.Logic.Interactive.InteractiveObjects
{
    public class HUDInteractiveObjectNote : Interactivity
    {
        [SerializeField] private int _noteId;
        [SerializeField] private AudioEvent _layerAudioEvent;

        private Sprite _noteImage;
        private TextAsset _inkJSON;
        private INoteWindow _presentationWindow;

        private bool _isNull;

        [Inject]
        private void Construct(HUD hud,TextConfig textConfig)
        {
            _presentationWindow = (INoteWindow)hud.InteractiveObjectWindows
                .FirstOrDefault(w => w.Type == Type)?
                .InteractiveObjectWindow;

            _inkJSON = textConfig.Notes.FirstOrDefault(n => n.Id == _noteId)!.inkJSON;
            _noteImage = textConfig.Notes.FirstOrDefault(n => n.Id == _noteId)!.NoteImage;
            
            _isNull = _presentationWindow == null || _inkJSON == null;
        }

        public override void StartInteractive()
        {
            if (_isNull)
                return;

            var message = new Story(_inkJSON.text).ContinueMaximally();
            
            OnAnimationProcess = true;
            OnStartInteractive?.Invoke();
            
            _layerAudioEvent.PlayAudioEvent();
            _presentationWindow.SetText(message);
            _presentationWindow.SetImage(_noteImage);
            _presentationWindow.ShowWindow(() => OnAnimationProcess = false);
        }

        public override void StopInteractive()
        {
            if (_isNull)
                return;

            OnAnimationProcess = true;
            
            OnStopInteractive?.Invoke();
            _layerAudioEvent.PlayAudioEvent();
            _presentationWindow.HideWindow(() => OnAnimationProcess = false);
        }
    }
}