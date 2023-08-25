using NHibernate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ToDo
{
    public class Repository
    {

        //Create a repository class for the TodoItem
        private readonly NHibernate.ISession _session;

        public Repository(NHibernate.ISession session)
        {
            _session = session;
        }

        public IEnumerable<TodoItem> GetTodoItems()
        {
            return _session.Query<TodoItem>().ToList();
        }

        public TodoItem AddTodoItem(TodoItem todoItem)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Save(todoItem);
                transaction.Commit();
            }

            return todoItem;
        }

        public TodoItem GetTodoItem(int id)
        {
            return _session.Get<TodoItem>(id);
        }

        public void UpdateTodoItem(TodoItem todoItem)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Update(todoItem);
                transaction.Commit();
            }
        }

        public void DeleteTodoItem(TodoItem todoItem)
        {
            using (var transaction = _session.BeginTransaction())
            {
                _session.Delete(todoItem);
                transaction.Commit();
            }
        }

        //internal IEnumerable<TodoItem> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //internal void Update(object todoitem)
        //{
        //    throw new NotImplementedException();
        //}

        //internal object GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //internal void DeleteById(int id)
        //{
        //    throw new NotImplementedException();
        //}

    }
}
