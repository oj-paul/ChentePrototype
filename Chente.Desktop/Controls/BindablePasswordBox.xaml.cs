using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chente.Desktop.Controls;
/// <summary>
/// Interaction logic for BindablePasswordBox.xaml
/// </summary>
public partial class BindablePasswordBox : UserControl
{
    public BindablePasswordBox()
    {
        InitializeComponent();
    }

    private static bool isUserTyping;

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(BindablePasswordBox), new PropertyMetadata(string.Empty, HandlePasswordChanged));

    private static void HandlePasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is BindablePasswordBox bindablePasswordBox) bindablePasswordBox.UpdateText();
    }

    private void UpdateText()
    {
        if (!isUserTyping) DefaultPasswordBox.Password = Text;
    }

    private void DefaultPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
    {
        isUserTyping = true;
        Text = DefaultPasswordBox.Password;
        isUserTyping = false;
    }
}
