using System;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

namespace ExceptionHandlingFramework
{
    class Program
    {
        /*
         * Sample class to demponsterate the use of the enterprise library.
         */
        static void CheckAndCreateEmployee()
        {
            LoggingManager.Logger.Write("Checking the employee");

            // Process the function with an exception policy specified
            ExceptionHandlingManager.Instance.Process(() => CreateEmployee(), ExceptionPolicy.ASSISTING_ADMINISTRATORS);

            // Employee checked
            LoggingManager.Logger.Write(" Employee checked");
        }

        static void CreateEmployee()
        {
            LoggingManager.Logger.Write("Entered the function");

            // Process the function with an exception policy specified
            ExceptionHandlingManager.Instance.Process(() => FetchData(), ExceptionPolicy.ASSISTING_ADMINISTRATORS);
            LoggingManager.Logger.Write("Left the function");

            // To check the upper function, throw a new exception
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Fetches the data
        /// </summary>
        static void FetchData()
        {
            throw new ArgumentException();
        }
    }
}
