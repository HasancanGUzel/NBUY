﻿using ShoppingApp.Business.Abstract;
using ShoppingApp.Data.Abstract;
using ShoppingApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp.Business.Concrete
{
    public class CardManager : ICardService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CardManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddToCard (string userId, int productId, int quantity)
        {
            await _unitOfWork.Cards.AddToCard(userId, productId, quantity); // sepete ürün eklemek için dışarıdan gelen bilgilei kullanıyoruz
            await _unitOfWork.SaveAsync();
        }

        public async Task<Card> GetByIdAsync(int id)
        {
            return await _unitOfWork.Cards.GetByIdAsync(id);
        }

        public async Task<Card> GetCardByUserId(string userId)
        {
            return await _unitOfWork.Cards.GetCardByUserId(userId); // userId yi efCoreCadRepositorye gönderiyor card bilgilerini almak için
        }

        public async Task InitializeCard(string userId)
        {
            await _unitOfWork.Cards.CreateAsync(new Card { UserId = userId });// yeni bir car oluştur ve UserId ye dışarıdan gelen userId yi yerleştir.
            await _unitOfWork.SaveAsync();
        }
    }
}
