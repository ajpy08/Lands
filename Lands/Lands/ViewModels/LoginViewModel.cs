using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lands.ViewModels
{
  class LoginViewModel : INotifyPropertyChanged
  {
    #region Attributes
    private string password;
    private bool isRunning;
    private bool isEnabled;
    #endregion

    #region Properties
    public string Email { get; set; }
    public string Password
    { get
      {
        return password;
      }
      set
      {
        if (password != value)
        {
          password = value;
          PropertyChanged.Invoke(
            this,
            new PropertyChangedEventArgs(nameof(Password)));
        }
      }
    }
    public bool IsRunning
    {
      get
      {
        return isRunning;
      }
      set
      {
        if (isRunning != value)
        {
          isRunning = value;
          PropertyChanged.Invoke(
            this,
            new PropertyChangedEventArgs(nameof(IsRunning)));
        }
      }
    }
    public bool IsRemembered { get; set; }
    public bool IsEnabled
    {
      get
      {
        return isEnabled;
      }
      set
      {
        if (isEnabled != value)
        {
          isEnabled = value;
          PropertyChanged.Invoke(
            this,
            new PropertyChangedEventArgs(nameof(IsEnabled)));
        }
      }
    }
    #endregion

    #region Constructors

    public LoginViewModel()
    {
      this.IsRemembered = true;
      this.isEnabled = true;
    }

    #endregion

    #region Commands

    public ICommand LoginCommand
    {
      get
      {
        return new RelayCommand(Login);
      }
    }

    private async void Login()
    {
      if (string.IsNullOrEmpty(this.Email))
      {
        await Application.Current.MainPage.DisplayAlert(
          "Error",
          "You must enter an email",
          "Accept");
        return;
      }

      if (string.IsNullOrEmpty(this.Password))
      {
        await Application.Current.MainPage.DisplayAlert(
          "Error",
          "You must enter an password",
          "Accept");
        return;
      }

      this.IsRunning = true;
      this.IsEnabled = false;
      
      if (this.Email != "1" || this.Password != "1")
      {
        this.IsRunning = false;
        this.IsEnabled = true;

        await Application.Current.MainPage.DisplayAlert(
          "Error",
          "Email or password incorrect",
          "Accept");
        this.Password = string.Empty;
        return;
      }

      this.IsRunning = false;
      this.IsEnabled = true;

      await Application.Current.MainPage.DisplayAlert(
          "Lands",
          "Access!",
          "Accept");
    }
    #endregion

    #region Methods

    #endregion

    #region Events

    public event PropertyChangedEventHandler PropertyChanged;

    #endregion    
  }
}
