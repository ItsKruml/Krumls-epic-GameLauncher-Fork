using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameLauncher.Models
{
    [TypeConverter(typeof(PaletteTypeConverter))]
    public class Palette
    {
        public static readonly Palette BackgroundPrimary = new(36, 39, 45);
        public static readonly Palette BackgroundLight = new(47, 51, 58);

        public static readonly Palette ForegroundPrimary = new(73, 80, 92);

        public static readonly Palette TextPrimary = new(Color.WhiteSmoke);

        public static readonly Palette ActivePrimary = new(142, 122, 181);
        public static readonly Palette ActiveDark = new(142, 122, 181);
        public static readonly Palette ActiveLight = new(98, 87, 126);
        public static readonly Palette Default = new(SystemColors.Control);

        public Color Color { get; private set; }
        public int R => Color.R;
        public int G => Color.G;
        public int B => Color.B;

        private Palette(int r, int g, int b) => this.Color = Color.FromArgb(r, g, b);
        private Palette(Color color) => this.Color = color;
        public Palette() => this.Color = Color.Transparent;

        public static Palette Find(Color color)
        {
            return typeof(Palette)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Select(x => (Palette)x.GetValue(null)!)
                .FirstOrDefault(x => x.R == color.R && x.G == color.G && x.B == color.B) ?? Palette.Default;
        }

        public static implicit operator Color(Palette palette) => palette.Color;
    }

    public class PaletteTypeConverter : StringConverter
    {
        static Dictionary<Palette, string> _nameIndex = InitializeNameIndex();
        static Dictionary<string, Palette> _colorIndex = InitializeColorIndex();

        private static Dictionary<string, Palette> InitializeColorIndex()
        {
            return typeof(Palette)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .ToDictionary(f => f.Name, f => (Palette)f.GetValue(null));
        }

        private static Dictionary<Palette, string> InitializeNameIndex()
        {
            return typeof(Palette)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .ToDictionary(f => (Palette)f.GetValue(null), f => f.Name);
        }

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(_nameIndex.Values.ToList());
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string))
                return true;

            return base.CanConvertTo(context, destinationType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(Palette))
                return true;

            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
            {
                Palette result;
                if (_colorIndex.TryGetValue((string)value, out result))
                    return result;
                else
                    return new Palette();
            }

            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is Palette)
            {
                string result;
                if (_nameIndex.TryGetValue((Palette)value, out result))
                    return result;
                else
                    return String.Empty;
            }
            else
            {
                return base.ConvertTo(context, culture, value, destinationType);
            }
        }
    }

    [ProvideProperty("CustomForeColor", typeof(Control))]
    [ProvideProperty("CustomBackColor", typeof(Control))]
    public class PaletteExtenderProvider : Component, IExtenderProvider
    {
        public Palette GetCustomForeColor(Control control)
        {
            return Palette.Find(control.ForeColor);
        }

        public Palette GetCustomBackColor(Control control)
        {
            return Palette.Find(control.BackColor);
        }

        public void SetCustomBackColor(Control control, Palette value)
        {
            control.BackColor = value.Color;
        }

        public void SetCustomForeColor(Control control, Palette value)
        {
            control.ForeColor = value.Color;
        }

        public bool ShouldSerializeCustomForeColor(Control control)
        {
            return false;
        }

        public bool ShouldSerializeCustomBackColor(Control control)
        {
            return false;
        }

        #region IExtenderProvider Members

        public bool CanExtend(object extendee)
        {
            return (extendee is Control);
        }

        #endregion
    }
}
