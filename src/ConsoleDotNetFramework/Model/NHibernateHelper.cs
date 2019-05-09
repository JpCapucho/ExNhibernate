using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDotNetFramework.Model
{

    public sealed class NHibernateHelper
    {
        private static readonly ISessionFactory _sessionFactory;
        private static ISession currentSession;

        static NHibernateHelper()
        {
            _sessionFactory = new Configuration().Configure().BuildSessionFactory();
        }

        /// <summary>
        /// returns hibernate session object
        /// </summary>
        /// <returns></returns>
        public static ISession GetCurrentSession()
        {
            if (currentSession == null)
            {
                currentSession = _sessionFactory.OpenSession();
            }

            return currentSession;
        }

        public static void CloseSession()
        {
            if (currentSession == null)
            {
                // No current session
                return;
            }

            currentSession.Close();
        }

        public static void CloseSessionFactory()
        {
            if (_sessionFactory != null)
            {
                _sessionFactory.Close();
            }
        }
    }
}
