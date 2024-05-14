namespace GameLauncher
{
    public partial class SettingItemControl : UserControl
    {
        public new bool Enabled
        {
            get => this._enabled;
            set
            {
                this._enabled = value;
                this.ComboBox.Enabled = value;
                this.TextBox.Enabled = value;
                this.CheckBox.Enabled = value;
                this.Button.Enabled = value;
            }
        }
        private string _key;
        private bool _enabled;
        private SettingItemControl(string key)
        {
            this.InitializeComponent();
            this.MainLabel.Text = key;
        }

        public static SettingItemControl ForAction(string key, Action onClick)
        {
            SettingItemControl control = new(key);
            control.Button.Click += (s, e) => onClick();
            control.Button.Visible = true;

            control.MainLabel.Visible = false;
            control.Button.Text = key;

            return control;
        }

        public static SettingItemControl ForAction(string key, Action<Button> onClick)
        {
            SettingItemControl control = new(key);
            control.Button.Click += (s, e) => onClick((Button)s);
            control.Button.Visible = true;

            control.MainLabel.Visible = false;
            control.Button.Text = key;

            return control;
        }

        public static SettingItemControl ForText(string key, Action<string> onType, string value = "")
        {
            SettingItemControl control = new(key);
            control.TextBox.Text = value;
            control.TextBox.TextChanged += (s, e) => onType(control.TextBox.Text);
            control.TextBox.Visible = true;

            return control;
        }

        public static SettingItemControl ForCondition(string key, Action<bool> onChange, bool value = false)
        {
            SettingItemControl control = new(key);
            control.CheckBox.Checked = value;
            control.CheckBox.CheckedChanged += (s, e) => onChange.Invoke(control.CheckBox.Checked);
            control.CheckBox.Visible = true;

            return control;
        }

        public static SettingItemControl ForSelect(string key, Action<string> onSelect, string[] values, string defaultValue = "")
        {
            SettingItemControl control = new(key);
            control.ComboBox.Items.AddRange(values);
            control.ComboBox.SelectedIndex = 0;
            control.ComboBox.SelectedIndexChanged += (s, e) => onSelect(control.ComboBox.Items[control.ComboBox.SelectedIndex].ToString());
            control.ComboBox.Visible = true;
            if (defaultValue != "") control.ComboBox.SelectedIndex = values.ToList().IndexOf(defaultValue);

            return control;
        }

        public static SettingItemControl ForObject(string key, object value, Action<object> objectUpdate)
        {
            return value switch
            {
                int i => ForText(key, v =>
                {
                    if (int.TryParse(v, out var val))
                        objectUpdate(int.Parse(v));
                }, i.ToString()),
                string s => ForText(key, v => objectUpdate(v), s),
                Enum e => ForSelect(key, v =>
                {
                    if (Enum.TryParse(value.GetType(), v, out var result))
                        objectUpdate(result);
                }, Enum.GetNames(value.GetType()), value.ToString()),
                bool b => ForCondition(key, v => objectUpdate(v), b),
                Action a => ForAction(key, () => { a(); objectUpdate(a); }),
                Action<Button> ab => ForAction(key, b => { ab(b); objectUpdate(ab); }),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
