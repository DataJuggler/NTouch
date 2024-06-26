

#region using statements

using DataAccessComponent.DataBridge;
using DataAccessComponent.DataOperations;
using DataAccessComponent.Logging;
using ObjectLibrary.BusinessObjects;
using System;
using System.Collections.Generic;

#endregion


namespace DataAccessComponent.Controllers
{

    #region class ControllerManager
    /// <summary>
    /// This class manages the child controllers for this application.
    /// </summary>
    public class ControllerManager
    {

        #region Private Variables
        private ErrorHandler errorProcessor;
        private ApplicationController appController;
        private ContactController contactController;
        private ContactPreferenceController contactpreferenceController;
        private ContactViewController contactviewController;
        private StateController stateController;
        #endregion

        #region Constructor
        /// <summary>
        /// Creates a new Creates a new 'ControllerManager' object.
        /// </summary>
        public ControllerManager(ErrorHandler errorProcessorArg, ApplicationController appControllerArg)
        {
            // Save Arguments
            this.ErrorProcessor = errorProcessorArg;
            this.AppController = appControllerArg;

            // Create Child Controllers
            Init();
        }
        #endregion

        #region Methods

            #region Init()
            /// <summary>
            /// Create Child Controllers
            /// </summary>
            private void Init()
            {
                // Create Child Controllers
                this.ContactController = new ContactController(this.ErrorProcessor, this.AppController);
                this.ContactPreferenceController = new ContactPreferenceController(this.ErrorProcessor, this.AppController);
                this.ContactViewController = new ContactViewController(this.ErrorProcessor, this.AppController);
                this.StateController = new StateController(this.ErrorProcessor, this.AppController);
            }
            #endregion

        #endregion

        #region Properties

            #region AppController
            public ApplicationController AppController
            {
                get { return appController; }
                set { appController = value; }
            }
            #endregion

            #region ErrorProcessor
            public ErrorHandler ErrorProcessor
            {
                get { return errorProcessor; }
                set { errorProcessor = value; }
            }
            #endregion

            #region ContactController
            public ContactController ContactController
            {
                get { return contactController; }
                set { contactController = value; }
            }
            #endregion

            #region ContactPreferenceController
            public ContactPreferenceController ContactPreferenceController
            {
                get { return contactpreferenceController; }
                set { contactpreferenceController = value; }
            }
            #endregion

            #region ContactViewController
            public ContactViewController ContactViewController
            {
                get { return contactviewController; }
                set { contactviewController = value; }
            }
            #endregion

            #region StateController
            public StateController StateController
            {
                get { return stateController; }
                set { stateController = value; }
            }
            #endregion

        #endregion

    }
    #endregion

}
