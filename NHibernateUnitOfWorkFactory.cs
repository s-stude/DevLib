using System.Data;
using DevLib.Domain;
using NHibernate;

namespace DevLib.Infrastructure.NHibernate
{
	public class NHibernateUnitOfWorkFactory : IUnitOfWorkFactory
	{
		private readonly ISessionFactory _sessionSessionFactory;

		///<summary>
		/// ctor
		///</summary>
		///<param name="sessionFactory"></param>
		public NHibernateUnitOfWorkFactory(ISessionFactory sessionFactory)
		{
			_sessionSessionFactory = sessionFactory;
		}

		public IUnitOfWork Create(IsolationLevel isolationLevel)
		{
			return new NHibernateUnitOfWork(_sessionSessionFactory.OpenSession(), isolationLevel);
		}

		public IUnitOfWork Create()
		{
			return Create(IsolationLevel.ReadCommitted);
		}
	}
}