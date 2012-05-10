using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JBSoft.Dal.Models;
using JBSoft.Bll;
using JBSoft.Web.Security;

namespace JBSoft.Web.ViewModels
{
    /// <summary>
    /// Base Class for all ViewModel classes.
    /// Is used to store common functionality across the viewmodel.
    /// </summary>
    public class JBSoftBaseViewModel
    {
        //protected const string EMAIL_REGULAR_EXPRESSION = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
        protected const string EMAIL_REGULAR_EXPRESSION = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";

        protected const string PASSWORD_REGULAR_EXPRESSION = @"^(?!password$).*$";
        protected const string SACELLNUMBER_REGULAR_EXPRESSION = @"^[1-9]{9}$";
        protected const string SACELLNUMBERFULL_REGULAR_EXPRESSION = @"^[+][2][7][1-9]{9}$";

        private const string DECIMAL_FORMAT = "{0:#,###,###.##}";

        private const string DATETIME_FORMAT_DEFAULTDATE = "dd MMM yyyy";
        private const string DATETIME_FORMAT_DEFAULTDATETIME = "dd MMM yyyy - HH:mm:ss";

        protected const string SACELLNUMBER_REGULAR_EXPRESSION_ERROR = "Please enter a correct mobile number (eg: +27 821234567)";

        /// <summary>
        /// Has errors flag used to determine whether a error occured on the server side.
        /// Will be required in cases where javascript isn't usable.
        /// </summary>
        public bool HasErrors
        {
            get
            {
                return this.errors.Count() > 0;
            }
        }

        /// <summary>
        /// Stores the server date time field when it is required.
        /// Is used as a property returning the result so it doesn't need to be set each time.
        /// </summary>
        public DateTime ServerDateTime
        {
            get
            {
                return this.GetServerDateTime();
            }
        }

        /// <summary>
        /// List to contain the errors messages and to handle the validation errors.
        /// </summary>
        private List<string> errors = new List<string>();
        public List<string> GetErrors()
        {
            return this.errors;
        }

        public string ReturnUrl { get; set; }

        private string viewModelName = "";
        public string ViewModelName
        {
            get
            {
                return this.viewModelName;
            }
            set
            {
                this.viewModelName = value;
            }
        }

        public string ValidationName 
        { 
            get
            {
                return string.Concat("validationSummary", viewModelName);
            }
        }

        public string ValidationServerName 
        {
            get
            {
                return string.Concat("validationServerSummary", viewModelName);
            }
        }

        public string ReplaceDivName
        {
            get
            {
                return string.Concat("divResults", viewModelName);
            }
        }

        #region Utility Functions

        /// <summary>
        /// Returns the current server date/time.
        /// Is abstracted away from DateTime.Now to allow for potential use of db datatieme 
        /// rather than application server date/time
        /// </summary>
        /// <returns></returns>
        private DateTime GetServerDateTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// Adds an error to the error messages list of the viewmodel.
        /// Should be used always instead of direct access to the list.
        /// </summary>
        public void AddModelError(string errorMessage)
        {
            this.errors.Add(errorMessage);
        }

        /// <summary>
        /// Adds the modelstate to the error dictionary if any exist.
        /// Should be used always instead of direct access to the list.
        /// </summary>
        public void AddModelErrors(ModelStateDictionary modelStateDictionary)
        {
            foreach (var modelState in modelStateDictionary.Values)
            {
                foreach (var error in modelState.Errors)
                    this.AddModelError(error.ErrorMessage);
            }
        }

        /// <summary>
        /// Formats the decimal value passed in to have no cents and to be seperated on the
        /// thousands and the millions
        /// </summary>
        /// <param name="value"></param>
        public string FormatDecimal(decimal value)
        {
            return string.Format(DECIMAL_FORMAT, Math.Floor(value));
        }

        public string FormatDateTimeDefaultDate(DateTime dateTime)
        {
            return dateTime.Year == 0001 ? "" : dateTime.ToString(DATETIME_FORMAT_DEFAULTDATE);
        }

        public string FormatDateTimeDefaultDateTime(DateTime dateTime)
        {
            return dateTime.Year == 0001 ? "" : dateTime.ToString(DATETIME_FORMAT_DEFAULTDATETIME);
        }

        #endregion

        #region Mobi Functionalities

        public bool IsIPhone { get; set; }

        #endregion

        #region Security

        private Dictionary<string, Module> userModules = null;

        public bool AccessModule(string moduleName)
        {
            if (userModules == null)
            {
                userModules = new Dictionary<string, Module>();

                var bll = new ModuleBll();
                foreach (var module in bll.SelectByUserId(CurrentUser.UserId, "EN"))
                {
                    userModules.Add(module.Description, module);
                }
            }

            return userModules.ContainsKey(moduleName);
        }

        #endregion
    }
}

