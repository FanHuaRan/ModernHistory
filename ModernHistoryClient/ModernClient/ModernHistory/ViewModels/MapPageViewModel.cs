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
using Esri.ArcGISRuntime.Geometry;
using Esri.ArcGISRuntime.Controls;
using Esri.ArcGISRuntime.Symbology;
using Esri.ArcGISRuntime.Layers;
using System.Linq;
using System.Windows.Input;
using System.Windows.Controls;
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
        #region 地图控制区
        //主地图
        private MapView mainMapView = null;
        //鹰眼图
        private MapView overviewMap = null;
        #region Extent 暂时没用
            private Envelope extent = null;
            public Envelope Extent
            {
                get
                {
                    return extent;
                }
                set
                {
                    if (extent != value)
                    {
                        extent = value;
                        NotifyPropertyChanged(p => p.Extent);
                    }
                }
            }        
            #endregion
        //鹰眼图加载完毕
        /// <summary>
        /// 鹰眼图层加载完毕 后进入等待画矩形状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void OverviewMap_LayerLoaded(object sender, LayerLoadedEventArgs e)
        {
            if (mainMapView == null)
            {
                overviewMap = sender as MapView;
            }
            await AddSingleGraphicAsync();
        }
        /// <summary>
        /// 一直添加鹰眼图框
        /// </summary>
        /// <returns></returns>
        private async Task AddSingleGraphicAsync()
        {
            try
            {
                await mainMapView.LayersLoadedAsync();
                var graphicsOverlay = overviewMap.GraphicsOverlays["overviewOverlay"];
                var symbol = System.Windows.Application.Current.Resources["RedFillSymbol"] as Symbol;
                //  Symbol symbol = symbol = layoutGrid.Resources["RedFillSymbol"] as Symbol;
                while (true)
                {
                    var geometry = await overviewMap.Editor.RequestShapeAsync(DrawShape.Rectangle, symbol);
                    graphicsOverlay.Graphics.Clear();
                    var graphic = new Graphic(geometry, symbol);
                    graphicsOverlay.Graphics.Add(graphic);
                    var viewpointExtent = geometry.Extent;
                    await mainMapView.SetViewAsync(viewpointExtent);
                }
            }
            catch (TaskCanceledException)
            {
                // Ignore cancellations from selecting new shape type
            }
            catch (Exception ex)
            { }
            await AddSingleGraphicAsync();//递归调用 防止出错
        }
        /// <summary>
        /// 界面load事件
        /// </summary>
        public ICommand MapPageLoadedCommand
        {
            get
            {
                return new DelegateCommand<Grid>(mapGrid =>
                {
                    if (mainMapView == null)
                    {
                        mainMapView = mapGrid.Children[0] as MapView;
                    }
                    if (overviewMap == null)
                    {
                        var border=mapGrid.Children[1] as Border;
                        overviewMap = border.Child as MapView;
                    }
                });
            }
        }
        /// <summary>
        /// 主图范围变化事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void MyMapView_ExtentChanged(object sender, System.EventArgs e)
        {
            var graphicsOverlay = overviewMap.GraphicsOverlays["overviewOverlay"];
            Graphic g = graphicsOverlay.Graphics.FirstOrDefault();
            if (g == null) //first time
            {
                g = new Graphic();
                graphicsOverlay.Graphics.Add(g);
            }
            var currentViewpoint = mainMapView.GetCurrentViewpoint(ViewpointType.BoundingGeometry);
            var viewpointExtent = currentViewpoint.TargetGeometry.Extent;
            g.Geometry = viewpointExtent;
            await overviewMap.SetViewAsync(viewpointExtent.GetCenter(), mainMapView.Scale * 15);
        }
        #endregion
        
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