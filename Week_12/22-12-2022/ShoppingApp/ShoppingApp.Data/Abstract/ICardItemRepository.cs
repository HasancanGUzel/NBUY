﻿using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Data.Abstract
{
    public interface ICardItemRepository:IRepository<CardItem>
    {
        Task ChangeQuantity(CardItem cardItem, int quantity); //burada bu metoda int cardItem yerine CardItem yani cardın kendisini yollucaz carItemMnagaer den buraya cardı yollucaz
    }
}
