﻿namespace Catel.Examples.SL.PersonApplication.Data.Converters
{
    using System;
    using System.Windows;
    using System.Windows.Data;
    using Models;

	/// <summary>
	/// Converts a <see cref="Gender"/> to a <see cref="bool"/> indicating whether the gender is selected.
	/// </summary>
	public class GenderToIsSelectedConverter : IValueConverter
	{
		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <param name="value">The value produced by the binding source.</param>
		/// <param name="targetType">The type of the binding target property.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>
		/// A converted value. If the method returns null, the valid null value is used.
		/// </returns>
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			// Check if the value is a gender object
			if (!(value is Gender)) return false;

			// Parse parameter
			Gender genderRepresented = Gender.Unknown;
			if (parameter is Gender) genderRepresented = (Gender)parameter;
			else if (parameter is string) genderRepresented = (Gender)Enum.Parse(typeof(Gender), (string)parameter, true);

			// Cast
			Gender gender = (Gender)value;

			// Check values
			return (gender == genderRepresented);
		}

		/// <summary>
		/// Converts a value.
		/// </summary>
		/// <param name="value">The value that is produced by the binding target.</param>
		/// <param name="targetType">The type to convert to.</param>
		/// <param name="parameter">The converter parameter to use.</param>
		/// <param name="culture">The culture to use in the converter.</param>
		/// <returns>
		/// A converted value. If the method returns null, the valid null value is used.
		/// </returns>
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			// Parse parameter
			Gender genderRepresented = Gender.Unknown;
			if (parameter is Gender) genderRepresented = (Gender)parameter;
			else if (parameter is string) genderRepresented = (Gender)Enum.Parse(typeof(Gender), (string)parameter, true);

			// Check if the value is true or value
			bool isChecked = false;
			if (value is bool)
			{
				isChecked = (bool)value;
			}
			else if (value is bool?)
			{
				isChecked = ((bool?)value).HasValue ? ((bool?)value).Value : false;
			}

			// Return value
			return (isChecked) ? genderRepresented : DependencyProperty.UnsetValue;
		}
	}
}
