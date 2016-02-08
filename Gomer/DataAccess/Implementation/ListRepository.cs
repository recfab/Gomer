﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Gomer.Models;

namespace Gomer.DataAccess.Implementation
{
    public class ListRepository : RepositoryBase<ListModel>, IListRepository
    {
        public ListRepository(IDataContext context) : base(context) { }

        protected override ISet<ListModel> Set
        {
            get { return Context.Lists; }
        }

        protected override IEnumerable<ListModel> DefaultSort(IEnumerable<ListModel> models)
        {
            return models.OrderByDescending(x => x.IncludeInStats)
                .ThenByDescending(x => x.GameCount)
                .ThenBy(x => x.Name);
        }

        protected override ListModel PopulateSecondaryData(ListModel model)
        {
            model.GameCount = Context.Games.Count(x => x.List.Id == model.Id);

            return model;
        }

        public IEnumerable<ListModel> FindByName(string name, params string[] names)
        {
            var searchNames = names.Concat(new[] { name });

            return Find(x => searchNames.Any(n => string.Equals(n, x.Name, StringComparison.CurrentCultureIgnoreCase)));
        }
    }
}