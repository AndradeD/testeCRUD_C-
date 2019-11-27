using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;

namespace TesteCRUD
{
	
	public class GenericRepository<TEntity> : IRepository<TEntity>, IDisposable
	{
		protected ISession _session = null;
		protected ITransaction _transaction = null;

		public GenericRepository()
		{
			_session = Database<TEntity>.OpenSession();
		}

		public GenericRepository(ISession session)
		{
			_session = session;
		}
		#region Transaction and Session Management Methods
		public void BeginTransaction()
		{
			_transaction = _session.BeginTransaction();
		}
		public void CommitTransaction()
		{
			// _transaction will be replaced with a new transaction            // by NHibernate, but we will close to keep a consistent state.
			_transaction.Commit();
			CloseTransaction();
		}
		public void RollbackTransaction()
		{
			// _session must be closed and disposed after a transaction            // rollback to keep a consistent state.
			_transaction.Rollback();
			CloseTransaction();
			CloseSession();
		}
		private void CloseTransaction()
		{
			_transaction.Dispose();
			_transaction = null;
		}
		private void CloseSession()
		{
			_session.Close();
			_session.Dispose();
			_session = null;
		}
		#endregion
		#region IRepository Members
		public virtual void Save(TEntity obj)
		{						
			_session.SaveOrUpdate(obj);			
			_session.Flush();
		}
		public virtual void Delete(TEntity obj)
		{
			_session.Delete(obj);
			Dispose();
		}
		public virtual object GetById(long id)
		{
			return _session.Load(typeof (TEntity), id);
		}
		public virtual List<TEntity> GetAll()
		{
			return _session.Query<TEntity>().ToList();
		}
		#endregion
		#region IDisposable Members
		public void Dispose()
		{
			if (_transaction != null)
			{
				// Commit transaction by default, unless user explicitly rolls it back.
				// To rollback transaction by default, unless user explicitly commits,                // comment out the line below.
				CommitTransaction();
			}
			if (_session != null)
			{
				_session.Flush(); // commit session transactions
				CloseSession();
			}
		}
		#endregion
	}
}