using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace BackendManagement.CommonView.ViewModels
{
    public class SettingViewModel
    {
        private readonly PaletteHelper _paletteHelper = new();
        private readonly Theme? theme = null;
        public IEnumerable<ISwatch> Swatches { get; } = SwatchHelper.Swatches;
        public DelegateCommand? LightCommand { get; private set; }
        public DelegateCommand? DarkCommand { get; private set; }
        public DelegateCommand<Color?>? SetPrimaryColorCommand { get; private set; }
        public DelegateCommand<Color?>? SetSecondaryColorCommand { get; private set; }
        public SettingViewModel()
        {
            if (theme == null)
            {
                theme = _paletteHelper.GetTheme();
            }
            LightCommand = new DelegateCommand(() => ApplyBase(false));
            DarkCommand = new DelegateCommand(() => ApplyBase(true));
            SetPrimaryColorCommand = new DelegateCommand<Color?>(SetPrimaryColor);
            SetSecondaryColorCommand = new DelegateCommand<Color?>(SetSecondaryColor);
        }
        private void ApplyBase(bool isDark)
        {
            if (theme != null)
            {
                theme.SetBaseTheme(isDark ? BaseTheme.Dark : BaseTheme.Light);
                _paletteHelper.SetTheme(theme);
            }

        }
        private void SetPrimaryColor(Color? color)
        {
            if (color != null)
                theme?.SetPrimaryColor((Color)color);
        }
        private void SetSecondaryColor(Color? color)
        {
            if (color != null)
                theme?.SetSecondaryColor((Color)color);
        }
    }
}
