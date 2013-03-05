using System;
using JetBrains.Annotations;
using NHibernate;

namespace DevLib.Infrastructure.NHibernate
{
    /// <summary>
    /// Провайдер для сессии на запрос.
    /// </summary>
    [UsedImplicitly]
    public class PerRequestSessionProvider : ISessionProvider, IDisposable
    {
        private readonly ISessionFactory _sessionFactory;
        private bool _disposed;
        private bool _preventCommit;
        private ISession _session;
        private ITransaction _transaction;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sessionFactory"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public PerRequestSessionProvider(ISessionFactory sessionFactory)
        {
            if (sessionFactory == null)
                throw new ArgumentNullException("sessionFactory");

            _sessionFactory = sessionFactory;
        }

        public ISession CurrentSession
        {
            get
            {
                if (_disposed)
                    throw new InvalidOperationException("Object already disposed. Probably container has wrong lifestyle type");

                if (_session != null)
                    return _session;

                _session = _sessionFactory.OpenSession();
                _transaction = _session.BeginTransaction();

                return _session;
            }
        }

        public void PreventCommit()
        {
            _preventCommit = true;
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            if (_session == null)
                return;

            try
            {
                if (_transaction != null)
                {
                    if (_preventCommit)
                        _transaction.Rollback();
                    else
                        _transaction.Commit();
                }
            }
            catch
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                    throw;
                }
            }
            finally
            {
                if (_transaction != null)
                {
                    _transaction.Dispose();
                }
            }

            _session.Dispose();
            _session = null;
            _transaction = null;
            _disposed = true;
        }
    }
}
