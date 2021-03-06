﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gomer.Generic;
using Gomer.Models;

namespace Gomer.Games
{
    public class GameIndexViewModel : IndexViewModelBase<GameModel, GameListViewModel, GameDetailViewModel>
    {
        public GameIndexViewModel(
            ObservableCollection<GameModel> models,
            ObservableCollection<ListModel> lists,
            ObservableCollection<PlatformModel> platforms,
            ObservableCollection<StatusModel> statuses)
            : base(models, 
            new GameListViewModel(models, lists), 
            new GameDetailViewModel(lists, platforms, statuses))
        {
        }
    }
}
