/*
  ViewModel��λ��������������ViewModel�����ã���������xaml���ṩ��ЩViewModel����ڵ㡣

  ��App.xaml�У�
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MvvmPractice" x:Key="Locator" />
  </Application.Resources>

  ����ͼ�У�
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  �����Ҫ�������ViewModel����ڣ��ɲο�MainViewModel�����´��롣
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace MvvmPractice.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
        }

        /// <summary>
        /// MainViewModel��ʵ���������
        /// </summary>
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}