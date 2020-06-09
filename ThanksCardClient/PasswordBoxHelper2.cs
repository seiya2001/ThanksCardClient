using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ThanksCardClient
{
    class PasswordBoxHelper2 : DependencyObject
    {
        public static readonly DependencyProperty IsAttachedProperty = DependencyProperty.RegisterAttached(
            "IsAttached",
            typeof(bool),
            typeof(PasswordBoxHelper2),
            new FrameworkPropertyMetadata(false, PasswordBoxHelper2.IsAttachedProperty_Changed));

        public static readonly DependencyProperty PasswordProperty = DependencyProperty.RegisterAttached(
            "Password",
            typeof(string),
            typeof(PasswordBoxHelper2),
            new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, PasswordBoxHelper2.PasswordProperty_Changed));

        public static bool GetIsAttached(DependencyObject dp)
        {
            return (bool)dp.GetValue(PasswordBoxHelper2.IsAttachedProperty);
        }

        public static string GetPassword(DependencyObject dp)
        {
            return (string)dp.GetValue(PasswordBoxHelper2.PasswordProperty);
        }

        public static void SetIsAttached(DependencyObject dp, bool value)
        {
            dp.SetValue(PasswordBoxHelper2.IsAttachedProperty, value);
        }

        public static void SetPassword(DependencyObject dp, string value)
        {
            dp.SetValue(PasswordBoxHelper2.PasswordProperty, value);
        }

        private static void IsAttachedProperty_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;

            if ((bool)e.OldValue)
            {
                passwordBox.PasswordChanged -= PasswordBoxHelper2.PasswordBox_PasswordChanged;
            }

            if ((bool)e.NewValue)
            {
                passwordBox.PasswordChanged += PasswordBoxHelper2.PasswordBox_PasswordChanged;
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            PasswordBoxHelper2.SetPassword(passwordBox, passwordBox.Password);
        }

        private static void PasswordProperty_Changed(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var passwordBox = sender as PasswordBox;
            var newPassword = (string)e.NewValue;

            if (!GetIsAttached(passwordBox))
            {
                SetIsAttached(passwordBox, true);
            }

            if ((string.IsNullOrEmpty(passwordBox.Password) && string.IsNullOrEmpty(newPassword)) ||
                passwordBox.Password == newPassword)
            {
                return;
            }

            passwordBox.PasswordChanged -= PasswordBoxHelper2.PasswordBox_PasswordChanged;
            passwordBox.Password = newPassword;
            passwordBox.PasswordChanged += PasswordBoxHelper2.PasswordBox_PasswordChanged;
        }
    }
}
    