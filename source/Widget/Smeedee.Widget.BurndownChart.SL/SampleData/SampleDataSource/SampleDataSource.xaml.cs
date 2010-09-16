﻿//      *********    DO NOT MODIFY THIS FILE     *********
//      This file is regenerated by a design tool. Making
//      changes to this file can cause errors.
namespace Expression.Blend.SampleData.SampleDataSource
{
	using System; 

// To significantly reduce the sample data footprint in your production application, you can set
// the DISABLE_SAMPLE_DATA conditional compilation constant and disable sample data at runtime.
#if DISABLE_SAMPLE_DATA
	internal class SampleDataSource { }
#else

	public class SampleDataSource : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		public SampleDataSource()
		{
			try
			{
				System.Uri resourceUri = new System.Uri("/APD.Client.Widget.BurndownChart.SL;component/SampleData/SampleDataSource/SampleDataSource.xaml", System.UriKind.Relative);
				if (System.Windows.Application.GetResourceStream(resourceUri) != null)
				{
					System.Windows.Application.LoadComponent(this, resourceUri);
				}
			}
			catch (System.Exception)
			{
			}
		}

		private ActualBurndown _ActualBurndown = new ActualBurndown();

		public ActualBurndown ActualBurndown
		{
			get
			{
				return this._ActualBurndown;
			}
		}

		private IdealBurndown _IdealBurndown = new IdealBurndown();

		public IdealBurndown IdealBurndown
		{
			get
			{
				return this._IdealBurndown;
			}
		}

		private string _ProjectName = string.Empty;

		public string ProjectName
		{
			get
			{
				return this._ProjectName;
			}

			set
			{
				if (this._ProjectName != value)
				{
					this._ProjectName = value;
					this.OnPropertyChanged("ProjectName");
				}
			}
		}

		private string _IterationName = string.Empty;

		public string IterationName
		{
			get
			{
				return this._IterationName;
			}

			set
			{
				if (this._IterationName != value)
				{
					this._IterationName = value;
					this.OnPropertyChanged("IterationName");
				}
			}
		}
	}

	public class ActualBurndown : System.Collections.ObjectModel.ObservableCollection<ActualBurndownItem>
	{ 
	}

	public class ActualBurndownItem : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private double _RemainingWorkEffort = 0;

		public double RemainingWorkEffort
		{
			get
			{
				return this._RemainingWorkEffort;
			}

			set
			{
				if (this._RemainingWorkEffort != value)
				{
					this._RemainingWorkEffort = value;
					this.OnPropertyChanged("RemainingWorkEffort");
				}
			}
		}

		private double _TimeStampForUpdate = 0;

		public double TimeStampForUpdate
		{
			get
			{
				return this._TimeStampForUpdate;
			}

			set
			{
				if (this._TimeStampForUpdate != value)
				{
					this._TimeStampForUpdate = value;
					this.OnPropertyChanged("TimeStampForUpdate");
				}
			}
		}
	}

	public class IdealBurndown : System.Collections.ObjectModel.ObservableCollection<IdealBurndownItem>
	{ 
	}

	public class IdealBurndownItem : System.ComponentModel.INotifyPropertyChanged
	{
		public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				this.PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
			}
		}

		private double _TimeStampForUpdate = 0;

		public double TimeStampForUpdate
		{
			get
			{
				return this._TimeStampForUpdate;
			}

			set
			{
				if (this._TimeStampForUpdate != value)
				{
					this._TimeStampForUpdate = value;
					this.OnPropertyChanged("TimeStampForUpdate");
				}
			}
		}

		private double _RemainingWorkEffort = 0;

		public double RemainingWorkEffort
		{
			get
			{
				return this._RemainingWorkEffort;
			}

			set
			{
				if (this._RemainingWorkEffort != value)
				{
					this._RemainingWorkEffort = value;
					this.OnPropertyChanged("RemainingWorkEffort");
				}
			}
		}
	}
#endif
}