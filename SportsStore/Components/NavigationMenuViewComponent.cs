﻿using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components {
    //[ViewComponent(Name = "NavigationMenuViewComponent")] //Solution
    public class NavigationMenuViewComponent : ViewComponent {
        private IStoreRepository repository;
        public NavigationMenuViewComponent(IStoreRepository repo) {
            repository = repo;
        }
        public IViewComponentResult Invoke() {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
    }
}