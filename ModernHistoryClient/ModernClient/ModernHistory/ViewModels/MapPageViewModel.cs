using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;
using ModernHistory.Services;
using ModernHistory.Models;
using ModernHistory.DtoConvert;
using System.Threading.Tasks;
using ModernHistory.Exceptions;

namespace ModernHistory.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class MapPageViewModel : ViewModelBase<MapPageViewModel>
    {
        
        private IFamousePersonService personService;
        private IHistoryEventService historyEventService;
        private IImageService imgService;

        private ObservableCollection<FamousPerson> famousPersons;

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

        private ObservableCollection<HistoryEvent> historyEvents;

        public ObservableCollection<HistoryEvent> HistoryEvents
        {
            get { return historyEvents; }
            set
            {
                if (historyEvents != value)
                {
                    this.historyEvents = value;
                    NotifyPropertyChanged(P => P.FamousPersons);
                }
            }
        }

        public MapPageViewModel(IFamousePersonService personService, IHistoryEventService historyEventService, IImageService imgService)
        {
            this.personService = personService;
            this.historyEventService = historyEventService;
            this.imgService = imgService;
            Task.Run(async () =>
            {
                try
                {
                    var famousePersonsDto = await this.personService.FindAllAsync();
                    FamousPersons = DtoConvertToModel.FamousePersonsConvert(famousePersonsDto);
                    var eventsDto = await this.historyEventService.FindAllAsync();
                    HistoryEvents = DtoConvertToModel.HistoryEventsConvert(eventsDto);
                }
                catch (ApiErrorException e)
                {
                    MessageBox.Show(e.Message);
                }
            });
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
    }
}