using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Liquinator.AttachedProperties {
    class LeftButtonUp : DependencyObject{
        public static DependencyProperty CommandProperty =
             DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(LeftButtonUp), new UIPropertyMetadata(CommandChanged));

        public static DependencyProperty CommandParameterProperty =
            DependencyProperty.RegisterAttached("CommandParameter", typeof(object), typeof(LeftButtonUp), new UIPropertyMetadata(null));

        public static void SetCommand(DependencyObject target, ICommand value) {
            target.SetValue(CommandProperty, value);
        }

        public static void SetCommandParameter(DependencyObject target, object value) {
            target.SetValue(CommandParameterProperty, value);
        }

        public static object GetCommandParameter(DependencyObject target) {
            return target.GetValue(CommandParameterProperty);
        }

        private static void CommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e) {
            Control control = target as Control;
            if (control != null) {
                if ((e.NewValue != null) && (e.OldValue == null)) {
                    control.MouseLeftButtonUp += MouseLeftButtonUp;
                } else if ((e.NewValue == null) && (e.OldValue != null)) {
                    control.MouseLeftButtonUp -= MouseLeftButtonUp;
                }
            }
        }

        private static void MouseLeftButtonUp(object sender, MouseButtonEventArgs e) {
            Control control = sender as Control;
            ICommand command = (ICommand)control.GetValue(CommandProperty);
            object commandParameter = control.GetValue(CommandParameterProperty);
            command.Execute(commandParameter);
        }
    }
}
