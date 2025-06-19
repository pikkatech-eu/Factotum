/***********************************************************************************
* File:         StopIterationException.cs                                          *
* Contents:     Class StopIterationException                                       *
* Author:       Stanislav "Bav" Koncebovski (stanislav@pikkatech.eu)               *
* Date:         2024-10-20 11:44                                                   *
* Version:      1.0                                                                *
* Copyright:    pikkatech.eu (www.pikkatech.eu)                                    *
***********************************************************************************/

using System;

namespace Factotum.Exceptions
{
	/// <summary>
	/// Analog to Python's StopIteration exception.
	/// Used to signalize that a defined maximum number of iterations has been reached or exceeded.
	/// </summary>
	public class StopIterationException : Exception
	{
        #region Properties
		/// <summary>
		/// Maximum number of iterations, if known and relevant.
		/// </summary>
        public int? MaxIterations {get;set;}	= null;

		/// <summary>
		/// Actual number of iterations, if knownt.
		/// </summary>
		public int? ActualIterations {get;set;}	= null;
		#endregion

		#region Construction
		/// <summary>
		/// Full data constructor.
		/// Creates an instance with both properties set.
		/// </summary>
		/// <param name="maxIterations">The value of maximum iterations.</param>
		/// <param name="actualIterations">The value of actual iterations made.</param>
		public StopIterationException(int maxIterations, int actualIterations)
		{
			this.MaxIterations = maxIterations;
			this.ActualIterations = actualIterations;
		}

		/// <summary>
		/// MaxIterations constructor.
		/// Creates an instance with the value of actual iterations unknown.
		/// </summary>
		/// <param name="maxIterations">The value of maximum iterations.</param>
		public StopIterationException(int maxIterations)
		{

		}

		/// <summary>
		/// Default constructor.
		/// Creates an instance with the both properties unknown or / and irrelevant.
		/// </summary>
		public StopIterationException()
		{

		}

		/// <summary>
		/// Base message constructor. Creates an instance with the message defined.
		/// </summary>
		/// <param name="message">The message defined.</param>
		public StopIterationException(string message) : base(message)
		{

		}
		#endregion

		#region Overridden
		/// <summary>
		/// Overridden exception message.
		/// </summary>
		public override string Message
		{
			get
			{
				if (!String.IsNullOrEmpty(base.Message))
				{
					return base.Message;
				}

				if (this.MaxIterations != null && this.ActualIterations != null)
				{
					return $"Maximum iterations reached or exceeded. MaxIterations={this.MaxIterations}; ActualIteration={this.ActualIterations}.";
				}
				else if (this.ActualIterations == null)
				{
					return $"Maximum iterations reached or exceeded. MaxIterations={this.MaxIterations}.";
				}
				else
				{
					return $"Maximum iterations reached or exceeded..";
				}
			}
		}
		#endregion
	}
}
