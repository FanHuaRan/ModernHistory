﻿using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;
using ModernHistory.Models;
using ModernHistory.Services;
using System.Windows.Forms;

namespace ModernHistory.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class PersonAddViewModel : ViewModelBase<PersonAddViewModel>
    {
        private IFamousePersonService personService;

        private IImageService imageService;

        private FamousPerson famousPerson = new FamousPerson();

        private string selectImg=null;

        private Boolean isMale = true;

        public Boolean IsMale
        {
            get { return isMale; }
            set
            {
                if (isMale != value)
                {
                    isMale = value;
                    NotifyPropertyChanged(p => p.IsMale);
                }
            }
        }

        private Boolean isFemale = false;

        public Boolean IsFemale
        {
            get { return isFemale; }
            set
            {
                if (isFemale != value)
                {
                    isFemale = value;
                    NotifyPropertyChanged(p => p.IsFemale);
                }
            }
        }


        public PersonAddViewModel(IFamousePersonService personService, IImageService imageService)
        {
            this.personService = personService;
            this.imageService = imageService;
            Initial();
        }

        public FamousPerson FamousPerson
        {
            get { return famousPerson; }
            set
            {
                if (famousPerson != value)
                {
                    famousPerson = value;
                    NotifyPropertyChanged(p => p.FamousPerson);
                }
            }
        }
        public string SelectImg
        {
            get { return selectImg; }
            set
            {
                if (selectImg != value)
                {
                    selectImg = value;
                    NotifyPropertyChanged(p => p.SelectImg);
                }
            }
        }


        public async void SaveAsync()
        {
            try
            {
                FamousPerson.Gender = IsMale ? (byte)1 : (byte)2;
                var result = await personService.SaveAsync(DtoConvert.DtoConvertToModel.FamousePersonConvert(famousPerson));
                System.Windows.MessageBox.Show("保存成功");
                SyncAddModel();
                if (!string.IsNullOrEmpty(SelectImg))
                {
                    await imageService.UploadPersonImgAsync(result.FamousPersonId, SelectImg);
                }
                Initial();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
        }

        public void ChooseImage()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "*.jpg|*.jpg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.SelectImg = openFileDialog.FileName;
            }
        }

        public void Initial()
        {
            IsMale = true;
            SelectImg = null;
            FamousPerson = new FamousPerson();
        }
        /// <summary>
        /// 同步ViewModel的数据
        /// </summary>
        public void SyncAddModel()
        {
            ViewModelLocator.PersonsInfoViewModelInstance.FamousPersons.Add(this.FamousPerson);
        }
    }
}