using Lands.Models;
using Lands.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Lands.ViewModels
{
  class LandsViewModel : BaseViewModel
  {
    #region Services

    private ApiService apiService;

    #endregion

    #region Attributes
    private ObservableCollection<Land> lands;
    #endregion

    #region Properties
    public ObservableCollection<Land> Lands
    {
      get { return this.lands; }
      set { SetValue(ref this.lands, value); }
    }
    #endregion

    #region Constructors

    public LandsViewModel()
    {
      apiService = new ApiService();
      LoadLands();
    }

    #endregion

    #region Methods

    private async void LoadLands()
    {
      var connection = await apiService.CheckConnection();

      if (!connection.IsSuccess)
      {
        await Application.Current.MainPage.DisplayAlert(
            "Error",
            connection.Message,
            "Accept");
        //Simula un flechita atras del usuario
        await Application.Current.MainPage.Navigation.PopAsync();
        return;
      }

      var response = await this.apiService.GetList<Land>(
          "http://restcountries.eu",
          "/rest",
          "/v2/all");

      if (!response.IsSuccess)
      {
        await Application.Current.MainPage.DisplayAlert(
            "Error",
            response.Message,
            "Accept");
        //Simula un flechita atras del usuario
        await Application.Current.MainPage.Navigation.PopAsync();
        return;
      }

      var list = (List<Land>)response.Result;
      this.Lands = new ObservableCollection<Land>(list);
    }

    #endregion
  }
}
