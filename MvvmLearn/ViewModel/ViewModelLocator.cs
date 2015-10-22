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

namespace MvvmLearn.ViewModel
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
            /*
            * ��������λ����ServiceLocator��ָ��IOC
            * ��ΪIOC��ʵ���ж���
            */
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

            /*
            * IOC����һ������������
            * ��Ҫ��������ע�ᣬ���ⲿ������Ҫ������͵Ķ���ʱ�����Զ�������ʵ�������������������ٴ�ʹ��
            *
            * �����ǽ�MainViewModel����ע�ᣬ���ڽ����ṩ��ʵ��
            */
            SimpleIoc.Default.Register<SimpleViewModel>();
        }

        /// <summary>
        /// MainViewModel��ʵ���������
        /// </summary>
        public SimpleViewModel Simple
        {
            get
            {
                /*
                * ServiceLocator��ָ��SimpleIoc��ΪIOC���������ʵ��
                * 
                * �����ǻ�ȡ��MainViewModel������IOC�е�ʵ��
                */
                return ServiceLocator.Current.GetInstance<SimpleViewModel>();
            }
        }

        /// <summary>
        /// MainViewModel��ʵ���������
        /// </summary>
        public SimpleViewModel Simple2
        {
            get
            {
                /*
                * ServiceLocator��ָ��SimpleIoc��ΪIOC���������ʵ��
                * 
                * �����ǻ�ȡ��MainViewModel������IOC�е�ʵ��
                */
                return ServiceLocator.Current.GetInstance<SimpleViewModel>("Simple2");
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}