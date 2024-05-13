using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Management;
using System.Runtime.CompilerServices;

namespace GameLauncher.Utils
{
    public static class Extensions
    {
        /// <summary>
        /// Returns true if <paramref name="path"/> starts with the path <paramref name="baseDirPath"/>.
        /// The comparison is case-insensitive, handles / and \ slashes as folder separators and
        /// only matches if the base dir folder name is matched exactly ("c:\foobar\file.txt" is not a sub path of "c:\foo").
        /// </summary>
        public static bool IsSubPathOf(this string path, string baseDirPath)
        {
            string normalizedPath = Path.GetFullPath(path.Replace('/', '\\')
                .WithEnding("\\"));

            string normalizedBaseDirPath = Path.GetFullPath(baseDirPath.Replace('/', '\\')
                .WithEnding("\\"));

            return normalizedPath.StartsWith(normalizedBaseDirPath, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Returns <paramref name="str"/> with the minimal concatenation of <paramref name="ending"/> (starting from end) that
        /// results in satisfying .EndsWith(ending).
        /// </summary>
        /// <example>"hel".WithEnding("llo") returns "hello", which is the result of "hel" + "lo".</example>
        public static string WithEnding(this string str, string ending)
        {
            if (str == null)
                return ending;

            string result = str;

            // Right() is 1-indexed, so include these cases
            // * Append no characters
            // * Append up to N characters, where N is ending length
            for (int i = 0; i <= ending.Length; i++)
            {
                string tmp = result + ending.Right(i);
                if (tmp.EndsWith(ending))
                    return tmp;
            }

            return result;
        }

        /// <summary>Gets the rightmost <paramref name="length" /> characters from a string.</summary>
        /// <param name="value">The string to retrieve the substring from.</param>
        /// <param name="length">The number of characters to retrieve.</param>
        /// <returns>The substring.</returns>
        public static string Right([NotNull] this string value, int length)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("length", length, "Length is less than zero");
            }

            return length < value.Length ? value.Substring(value.Length - length) : value;
        }

        public static string? GetMainModuleFilepath(this Process process)
        {
            string wmiQueryString = "SELECT ProcessId, ExecutablePath FROM Win32_Process WHERE ProcessId = " + process.Id;

            using var searcher = new ManagementObjectSearcher(wmiQueryString);
            using var results = searcher.Get();
            ManagementObject? mo = results.Cast<ManagementObject>().FirstOrDefault();
            if (mo != null)
                return (string)mo["ExecutablePath"];

            return null;
        }

        public static void Spawn(this Control control, Form parent)
        {
            control.Dock = DockStyle.Fill;
            control.Parent = parent;
            parent.Controls.Add(control);
            control.BringToFront();
        }

        public static Color GetColor(this LauncherTheme theme, LauncherThemeKey key)
        {
            return theme switch
            {
                LauncherTheme.Dark => key switch
                {
                    LauncherThemeKey.PrimaryText => Color.White,
                    LauncherThemeKey.PrimaryBackground => Color.FromArgb(44,44,44),
                    LauncherThemeKey.SecondaryBackground => Color.FromArgb(60, 60, 60),
                },
                LauncherTheme.Light => key switch
                {
                    LauncherThemeKey.PrimaryText => Color.Black,
                    LauncherThemeKey.PrimaryBackground => Color.WhiteSmoke,
                    LauncherThemeKey.SecondaryBackground => Color.White,
                }
            };;
        }
        
        public static void Apply(this LauncherTheme theme, Control control)
        {
            control.BackColor = theme.GetColor(LauncherThemeKey.PrimaryBackground);
            control.ForeColor = theme.GetColor(LauncherThemeKey.PrimaryText);

            ApplyControlThemePatch(control, theme);
        }
        
        private static void ApplyControlThemePatch(Control control, LauncherTheme theme)
        {
            // if we are a button, textbox, groupbox, we need to change the style
            if (control is Button b)
            {
                b.FlatStyle = theme == LauncherTheme.Dark ? FlatStyle.Flat : FlatStyle.Standard;
                b.BackColor = theme.GetColor(LauncherThemeKey.SecondaryBackground);
                b.ForeColor = theme.GetColor(LauncherThemeKey.PrimaryText);
                b.FlatAppearance.BorderColor = theme.GetColor(LauncherThemeKey.PrimaryText);
            }
            
            if (control is TextBox)
            {
                control.BackColor = theme.GetColor(LauncherThemeKey.SecondaryBackground);
                control.ForeColor = theme.GetColor(LauncherThemeKey.PrimaryText);
            }
            
            if (control is GroupBox gb)
            {
                gb.ForeColor = theme.GetColor(LauncherThemeKey.PrimaryText);
                gb.BackColor = theme.GetColor(LauncherThemeKey.PrimaryBackground);
                gb.FlatStyle = theme == LauncherTheme.Dark ? FlatStyle.Flat : FlatStyle.Standard;
            }
            
            foreach (Control child in control.Controls) ApplyControlThemePatch(child, theme);
        }
        
        public static string CleanFileName(this string fileName)
        {
            return Path.GetInvalidFileNameChars().Aggregate(fileName, (current, c) => current.Replace(c.ToString(), string.Empty));
        }
    }
}
