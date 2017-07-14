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

namespace ModernHistory.ViewModels
{
    public class PersonsInfoViewModel : ViewModelBase<PersonsInfoViewModel>//,IDataErrorInfo
    {
        // TODO: Add a member for IXxxServiceAgent
        private IFamousePersonService personService;

        private IConstModelsService constModelsService;

        private IImageService imgService;


        private ObservableCollection<FamousPerson> famousPersons;

        private FamousPerson selectFamousePerson;

        public PersonsInfoViewModel(IFamousePersonService personService, IConstModelsService constModelsService, IImageService imgService)
        {
            this.personService = personService;
            this.constModelsService = constModelsService;
            this.imgService = imgService;
            Task.Run(async () =>
            {
                try
                {
                    var famousePersonsDto = await this.personService.FindAllAsync();
                    FamousPersons = DtoConvertToModel.FamousePersonsConvert(famousePersonsDto);
                }
                catch (ApiErrorException e)
                {
                    MessageBox.Show(e.Message);
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