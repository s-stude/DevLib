using System;
using System.Data;
using DevLib.Domain;
using NHibernate;
using NHibernate.Context;

namespace DevLib.Infrastructure.NHibernate
{
    internal class NHibernateUnitOfWork : IUnitOfWork
    {
        private readonly ISession _session;
        private ITransaction _transaction;

        public NHibernateUnitOfWork(ISession session, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            CurrentSessionContext.Bind(session);

            _session = session;
            _transaction = session.BeginTransaction(isolationLevel);
        }

        #region IUnitOfWork Members

        public void Dispose()
        {
            if (!_transaction.WasCommitted && !_transaction.WasRolledBack)
            {
                _transaction.Rollback();
            }
            _transaction.Dispose();
            _transaction = null;

            CurrentSessionContext.Unbind(_session.SessionFactory);
            _session.Dispose();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        #endregion
    }
}