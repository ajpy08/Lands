namespace Lands.ViewModels
{
  class MainViewModel
    {
    #region ViewModels
    public LoginViewModel Login { get; set; }
    public LandsViewModel Lands { get; set; }
    #endregion

    #region Constructors
    public MainViewModel()
    {
      instance = this;
      this.Login = new LoginViewModel();
    }
    #endregion

    #region Singleton

    private static MainViewModel instance;

    public static MainViewModel GetInstance()
    {
      if (instance is null)
        return new MainViewModel();

      return instance;
    }

    #endregion
  }
}
