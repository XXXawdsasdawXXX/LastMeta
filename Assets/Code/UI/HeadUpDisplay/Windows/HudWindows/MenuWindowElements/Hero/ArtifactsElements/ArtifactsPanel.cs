using Code.UI.HeadUpDisplay.HudElements;
using UnityEngine;

namespace Code.UI.HeadUpDisplay.Windows.HudWindows.MenuWindowElements.Hero.ArtifactsElements
{
    public class ArtifactsPanel: HudElement
    {

        public ArtifactIcon[] ArtifactIcons => _artifactIcons;
        [SerializeField] private ArtifactIcon[] _artifactIcons;
    }
}