using System;
using System.Windows.Input;
using System.Windows;
using MyCalculator.Command;
using MyCalculator.ViewModels.Base;
using static System.Net.Mime.MediaTypeNames;
using System.Data;

namespace MyCalculator.ViewModels
{
    internal class CalculatorViewModel:ViewModelBase
	{
		#region Заголовок окна
		private string _display = "0";
		public string Display
		{
			get => _display;
			set => Set(ref _display, value);
		}
		#endregion
		
		public ICommand ClickButton { get;  }
		private bool CanClickButtonExecute(object parameter) => true;
		private void OnClickButtonExecited(object parameter)
		{
			string paramterText = parameter.ToString();
			
			try
			{
				
				string list = "123456789";
				if (paramterText == "C")
				{
					Display = "";
					
				}

				else if (paramterText == "=")
				{
					Display = new DataTable().Compute(Display, null).ToString();
				}
				else if (paramterText == "X")
				{
					Display = Display.Remove(Display.Length - 1, 1);
				}
				else if (Display == "0")
				{

					if (paramterText == "0") { Display = "0"; }
					if (list.IndexOf(paramterText.ToString()) != -1) { Display = paramterText.ToString(); }

				}

				else Display += paramterText.ToString();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		public CalculatorViewModel()
		{

			ClickButton = new LambdaCommand( OnClickButtonExecited, CanClickButtonExecute);
		}
	}
}

