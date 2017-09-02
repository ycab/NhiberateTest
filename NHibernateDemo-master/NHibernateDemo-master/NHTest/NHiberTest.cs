using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Bytecode;
using NUnit;
using NUnit.Framework;
using log4net;
using Domain;

namespace NHTest
{
    [TestFixture]
    public class NHiberTest
    {
        [Test]
        public void InitTest()
        {
            var cfg = new NHibernate.Cfg.Configuration().Configure(System.AppDomain.CurrentDomain.BaseDirectory + "hibernate.cfg.xml");
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory()) { }
        }
    }
}
