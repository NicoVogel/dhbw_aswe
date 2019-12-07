using mvvm.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace mvvm.ViewModel
{
    public class MainVIewModel : INotifyPropertyChanged
    {
		private int m_valTwoWay = 5;
		private int m_valOneWay = 5;
		private int m_valOneWayToSource = 5;

		public int ValOneWayToSource
		{
			get { return m_valOneWayToSource; }
			set 
			{
				if(m_valOneWayToSource == value)
				{
					return;
				}
				m_valOneWayToSource = value;
				OnPropertyChanged();
			}
		}

		public int ValOneWay
		{
			get { return m_valOneWay; }
			set 
			{
				if(m_valOneWay == value)
				{
					return;
				}
				m_valOneWay = value;
				OnPropertyChanged();
			}
		}

		public int ValTwoWay
		{
			get { return m_valTwoWay; }
			set
			{
				if(m_valTwoWay == value)
				{
					return;
				}
				m_valTwoWay = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
