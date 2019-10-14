using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SurveyAPI.Tests
{
    public class TestDbSet<T> : DbSet<T>
    where T : class
    {
        ObservableCollection<T> _data;
        IQueryable _query;

        public TestDbSet()
        {
            _data = new ObservableCollection<T>();
            _query = _data.AsQueryable();
        }

        public virtual T Find(params object[] keyValues)
        {
            //int Id = Convert.ToInt32(keyValues[0]);
            //List<T> data = _data.ToList();
            //return data.Find(d => d.Id == keyValues);
            throw new NotImplementedException("Derive from TestDbSet<T> and override Find");
        }

        public T Add(T item)
        {
            _data.Add(item);
            return item;
        }

        public T Remove(T item)
        {
            //List is created and assigned to avoid  the Collection from being modified multiple time in same context. its done just for the sake of unit test execution.
            //Direct removal of item from _data will lead to System.InvalidOperationException (Collection was modified; enumeration operation may not execute).
            List<T> data = _data.ToList();
            data.Remove(item);
            _data = new ObservableCollection<T>(data); ;
            return item;
        }

        public T Attach(T item)
        {
            _data.Add(item);
            return item;
        }

        public T Detach(T item)
        {
            _data.Remove(item);
            return item;
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public TDerivedEntity Create<TDerivedEntity>() where TDerivedEntity : class, T
        {
            return Activator.CreateInstance<TDerivedEntity>();
        }

        public ObservableCollection<T> Local
        {
            get { return _data; }
        }

        //Type IQueryable.ElementType
        //{
        //    get { return _query.ElementType; }
        //}

        //Expression IQueryable.Expression
        //{
        //    get { return _query.Expression; }
        //}

        //IQueryProvider IQueryable.Provider
        //{
        //    get { return _query.Provider; }
        //}

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return _data.GetEnumerator();
        //}

        //IEnumerator<T> IEnumerable<T>.GetEnumerator()
        //{
        //    return _data.GetEnumerator();
        //}
    }
}
