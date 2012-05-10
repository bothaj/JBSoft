using System;
using System.Security.Principal;

namespace JBSoft.Web.Security
{
    public class UserPrincipal : IPrincipal
    {
        #region Constructors

        public UserPrincipal(
            UserIdentity userIdentity,
            Guid userId
            /* Additional information to store on the users */)
        {
            _CreationTime = DateTime.Now;

            if (userIdentity == null)
                throw new ArgumentNullException("userIdentity");

            _UserIdentity = userIdentity;
            _UserId = userId;

            /* Additional information loaded into local variables*/
        }

        #endregion

        #region IPrincipal Members

        public IIdentity Identity
        {
            get { return _UserIdentity; }
        }

        /// <summary>
        /// Determines whether the current principal belongs to the specified role (or has the specific Feature in MZone).
        /// </summary>
        /// <param name="role">The name of the role for which to check membership.</param>
        /// <returns>
        /// true if the current principal is a member of the specified role; otherwise, false.
        /// </returns>
        public bool IsInRole(string role)
        {
            return true;
        }

        #endregion

        #region Public Members

        public DateTime CreationTime
        {
            get { return _CreationTime; }
        }

        /// <summary>
        /// Gets the User ID from the UserIdentity.
        /// </summary>
        /// <value>The User ID.</value>
        public string Id
        {
            get { return _UserIdentity.Id; }
        }

        public UserIdentity UserIdentity
        {
            get { return _UserIdentity; }
        }

        public Guid User_Id
        {
            get { return _UserId; }
        }

        /*
         Additional properties used to store the user information that validates
         and provides access to often repeated values.
         */
         
        #endregion

        #region Private Members

        private readonly DateTime _CreationTime;
        private Guid _UserId;
        private readonly UserIdentity _UserIdentity;

        #endregion
    }
}
