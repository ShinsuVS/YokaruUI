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

namespace YokaruUI.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            if (((App)Application.Current).LightTheme == true) { rdLightTheme.IsChecked = true; }
            else rdDarkTheme.IsChecked = true; 

            TogleChekSet.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();

            ResourceDictionary resourceDictionaryTheme = new ResourceDictionary();
            resourceDictionaryTheme.Source = new Uri("View/Themes/LightTheme.xaml", UriKind.RelativeOrAbsolute);
            ResourceDictionary resourceDictionaryIcons = new ResourceDictionary();
            resourceDictionaryIcons.Source = new Uri("View/Assets/Icons/Icons.xaml", UriKind.RelativeOrAbsolute);
            ResourceDictionary resourceDictionaryStyles = new ResourceDictionary();
            resourceDictionaryStyles.Source = new Uri("View/Styles/MainStyle.xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionaryTheme);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionaryIcons);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionaryStyles);
            ((App)Application.Current).LightTheme = true;
        }

        private void BlackTheme_Click(object sender, RoutedEventArgs e)

        {
            Application.Current.Resources.MergedDictionaries.Clear();
           
            ResourceDictionary resourceDictionaryTheme = new ResourceDictionary();
            resourceDictionaryTheme.Source = new Uri("View/Themes/DarkTheme.xaml", UriKind.RelativeOrAbsolute);
            ResourceDictionary resourceDictionaryIcons = new ResourceDictionary();
            resourceDictionaryIcons.Source = new Uri("View/Assets/Icons/Icons.xaml", UriKind.RelativeOrAbsolute);
            ResourceDictionary resourceDictionaryStyles = new ResourceDictionary();
            resourceDictionaryStyles.Source = new Uri("View/Styles/MainStyle.xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionaryTheme);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionaryIcons);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionaryStyles);

            ((App)Application.Current).LightTheme = false;
        }

        private void rdLightTheme_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();

            ResourceDictionary resourceDictionaryTheme = new ResourceDictionary();
            resourceDictionaryTheme.Source = new Uri("View/Themes/LightTheme.xaml", UriKind.RelativeOrAbsolute);
            ResourceDictionary resourceDictionaryIcons = new ResourceDictionary();
            resourceDictionaryIcons.Source = new Uri("View/Assets/Icons/Icons.xaml", UriKind.RelativeOrAbsolute);
            ResourceDictionary resourceDictionaryStyles = new ResourceDictionary();
            resourceDictionaryStyles.Source = new Uri("View/Styles/MainStyle.xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionaryTheme);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionaryIcons);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionaryStyles);
            ((App)Application.Current).LightTheme = true;
        }

        private void rdDarkTheme_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();

            ResourceDictionary resourceDictionaryTheme = new ResourceDictionary();
            resourceDictionaryTheme.Source = new Uri("View/Themes/DarkTheme.xaml", UriKind.RelativeOrAbsolute);
            ResourceDictionary resourceDictionaryIcons = new ResourceDictionary();
            resourceDictionaryIcons.Source = new Uri("View/Assets/Icons/Icons.xaml", UriKind.RelativeOrAbsolute);
            ResourceDictionary resourceDictionaryStyles = new ResourceDictionary();
            resourceDictionaryStyles.Source = new Uri("View/Styles/MainStyle.xaml", UriKind.RelativeOrAbsolute);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionaryTheme);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionaryIcons);
            Application.Current.Resources.MergedDictionaries.Add(resourceDictionaryStyles);
            ((App)Application.Current).LightTheme = false;
        }
    }
}
