using System.Security.Principal;

namespace JBSoft.Web.Security
{
    public class UserIdentity : GenericIdentity
    {
        #region Constructors

        public UserIdentity(string userName)
            : base(userName)
        {
            _Id = userName;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets the User ID.
        /// </summary>
        /// <value>The User ID.</value>
        public string Id
        {
            get { return _Id; }
        }

        #endregion

        #region Public GenericIdentity Member Overrides

        public override string AuthenticationType
        {
            get { return "ElementreeHR"; }
        }

        #endregion

        #region Private Members

        private readonly string _Id;

        #endregion
    }
}
