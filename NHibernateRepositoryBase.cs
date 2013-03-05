using System;
using DevLib.Domain;
using NHibernate;

namespace DevLib.Infrastructure.NHibernate
{
    public abstract class NHibernateRepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        private readonly ISessionProvider _sessionProvider;

        ///<summary>
        ///</summary>
        ///<param name="sessionProvider"></param>
        /// <exception cref="ArgumentNullException"><c>sessionProvider</c> is null.</exception>
        protected NHibernateRepositoryBase(ISessionProvider sessionProvider)
        {
            if (sessionProvider == null)
                throw new ArgumentNullException("sessionProvider");

            this._sessionProvider = sessionProvider;
        }

        protected ISession Session
        {
            get { return _sessionProvider.CurrentSession; }
        }

        #region IRepository<TEntity> Members

        public virtual TEntity Get(int id)
        {
            return Session.Get<TEntity>(id);
        }

        public TEntity Load(int id)
        {
            return Session.Load<TEntity>(id);
        }

        public virtual void Save(TEntity entity)
        {
            Session.SaveOrUpdate(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            Session.Delete(entity);
        }

        #endregion
    }
}