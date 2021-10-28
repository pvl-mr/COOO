using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogics.Interfaces
{
    public interface IBillStorage
    {
        /// <summary>
        /// Метод получения полного списка счетов
        /// </summary>
        /// <returns> Список счетов </returns>
        List<BillViewModel> GetFullList();

        /// <summary>
        /// Метод получения отфильтрованного списка счетов
        /// </summary>
        /// <param name="model"></param>
        /// <returns> Список отфильтрованных счетов </returns>
        List<BillViewModel> GetFilteredList(BillBindingModel model);

        /// <summary>
        /// Метод получения счета
        /// </summary>
        /// <param name="model"> Модель счета </param>
        /// <returns> Счет </returns>
        BillViewModel GetElement(BillBindingModel model);

        /// <summary>
        /// Добавить новый счет
        /// </summary>
        /// <param name="model"> Модель счета </param>
        void Insert(BillBindingModel model);

        /// <summary>
        /// Обновить счет
        /// </summary>
        /// <param name="model"> Модель счета </param>
        void Update(BillBindingModel model);

        /// <summary>
        /// Удалить счет
        /// </summary>
        /// <param name="model"> Модель счета </param>
        void Delete(BillBindingModel model);
    }
}
