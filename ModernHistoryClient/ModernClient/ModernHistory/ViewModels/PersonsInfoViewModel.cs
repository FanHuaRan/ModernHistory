using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;
using ModernHistory.Services;
using ModernHistory.Models;
using System.Threading.Tasks;
using System.ComponentModel;
using ModernHistory.Exceptions;
using ModernHistory.DtoConvert;
using System.Drawing;

namespace ModernHistory.ViewModels
{
    public class PersonsInfoViewModel : ViewModelBase<PersonsInfoViewModel>//,IDataErrorInfo
    {
        // TODO: Add a member for IXxxServiceAgent
        private IFamousePersonService personService;


        private IImageService imgService;

        private ObservableCollection<FamousPerson> famousPersons;

        private FamousPerson selectFamousePerson;

        public PersonsInfoViewModel(IFamousePersonService personService, IImageService imgService)
        {
            this.personService = personService;
            this.imgService = imgService;
            Task.Run(() =>
            {
                //try
                //{
                //    var famousePersonsDto = await this.personService.FindAllAsync();
                //    FamousPersons = DtoConvertToModel.FamousePersonsConvert(famousePersonsDto);
                //}
                //catch (ApiErrorException e)
                //{
                //    MessageBox.Show(e.Message);
                //}
                //连续5次延迟1秒从mapPageViewModelInstance中获取数据 不应该这样做 不过为了方便。。。。
                for (int i = 0; i < 5; i++)
                {
                    var mapPageViewModelInstance=ViewModelLocator.MapPageViewModelInstance;
                    if (mapPageViewModelInstance.FamousPersons != null)
                    {
                        FamousPersons = mapPageViewModelInstance.FamousPersons;
                        break;
                    }
                    Thread.Sleep(1);
                }
            });
        }

        public ObservableCollection<FamousPerson> FamousPersons
        {
            get
            {
                return famousPersons;
            }
            set
            {
                if (famousPersons != value)
                {
                    this.famousPersons = value;
                    NotifyPropertyChanged(P => P.FamousPersons);
                }
            }
        }
        public FamousPerson SelectFamousePerson
        {
            get
            {
                return selectFamousePerson;
            }
            set
            {
                if (selectFamousePerson != value)
                {
                    this.selectFamousePerson = value;
                    NotifyPropertyChanged(P => P.SelectFamousePerson);
                }
            }
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // TODO: Add properties using the mvvmprop code snippet

        // TODO: Add methods that will be called by the view
        public async void Delete()
        {
            if (SelectFamousePerson != null)
            {
                try
                {
                    await personService.DeleteAsync(selectFamousePerson.FamousPersonId);
                    this.famousPersons.Remove(SelectFamousePerson);
                    SelectFamousePerson = null;
                    MessageBox.Show("删除成功");
                }
                catch (Exception e)
                {
                    System.Windows.MessageBox.Show(e.Message);
                }
            }
        }

        // TODO: Optionally add callback methods for async calls to the service agent
        
        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}