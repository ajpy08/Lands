using Lands.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.Infrastructure
{
    class InstanceLocator
    {
    #region Properties
    public MainViewModel  Main { get; set; }
    #endregion

    #region Constructors
    public InstanceLocator()
    {
      Main = new MainViewModel();
    }
    #endregion
  }
}
