﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Gomer.DataAccess;
using Gomer.DataAccess.Implementation;
using Gomer.Models;
using NUnit.Framework;

namespace Gomer.Tests.RepositoryTests
{
    [TestFixture]
    public class ListRepositoryTestsBase : RepositoryTestsBase<IListRepository, ListModel>
    {
        protected override IDataContext GetContext(bool includeDataUnderTest)
        {
            var context = new DataContext();

            if (includeDataUnderTest)
            {
                context.Lists.Add(new ListModel
                {
                    Id = 1,
                    Name = "Foo"
                });
                context.Lists.Add(new ListModel
                {
                    Id = 2,
                    Name = "Bar"
                });
            }

            return context;
        }

        protected override IListRepository GetRepository(IDataContext context)
        {
            return new ListRepository(context);
        }

        protected override ISet<ListModel> Set(IDataContext context)
        {
            return context.Lists;
        }

        protected override ListModel GetNewModel()
        {
            return new ListModel { Name = "Test" };
        }

        protected override Expression<Func<ListModel, bool>> GetKnownItemPredicate()
        {
            return x => x.Name == "Foo";
        }
    }
}