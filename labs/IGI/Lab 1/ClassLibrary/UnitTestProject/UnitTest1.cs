using ClassLibrary.Entities;
using ClassLibrary.Interfaces;
using ClassLibrary.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Store store = new Store();
            store.NameTovar = "Added";
            store.Cost = 120;
            store.Count = 23;
            store.ClientId = 1;

            IRepository<Store> storeRep = new RepositoryStore();
            storeRep.Insert(store);
            List<Store> searchedStores = storeRep.Search(store.NameTovar);
            Store searchedStore = searchedStores.Find((cur) => cur.NameTovar == store.NameTovar);
            Assert.IsNotNull(searchedStore);
            storeRep.Delete(searchedStore.Id);
        }
    }
}
