using BusinessLogics.BindingModels;
using BusinessLogics.Interfaces;
using BusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogics.BusinessLogic
{
    public class BillLogic
    {
        /// <summary>
        /// Хранилище сборок
        /// </summary>
        private readonly IBillStorage billStorage;

        /// <summary>
        /// Конструктор логики счетов
        /// </summary>
        /// <param name="billStorage"> Хранилище счетов </param>
        public BillLogic(IBillStorage billStorage)
        {
            this.billStorage = billStorage;
        }

        /// <summary>
        /// Получить список счетов
        /// </summary>
        /// <param name="model"> Модель счета </param>
        /// <returns> Список счетов </returns>
        public List<BillViewModel> Read(BillBindingModel model)
        {
            if (model == null)
            {
                return billStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<BillViewModel>
                {
                    billStorage.GetElement(model)
                };
            }
            return billStorage.GetFilteredList(model);
        }

        /// <summary>
        /// Создать или обновить счет
        /// </summary>
        /// <param name="model"> Модель счета </param>
        public void CreateOrUpdate(BillBindingModel model)
        {
            if (model.Id.HasValue)
            {
                billStorage.Update(model);
            }
            else
            {
                billStorage.Insert(model);
            }
        }

        /// <summary>
        /// Удалить счет
        /// </summary>
        /// <param name="model"> Модель счета </param>
        public void Delete(BillBindingModel model)
        {
            var element = billStorage.GetElement(new BillBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Счет не найден");
            }
            billStorage.Delete(model);
        }
    }
}
