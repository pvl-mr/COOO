using BusinessLogics.BindingModels;
using BusinessLogics.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogics.Interfaces
{
    public interface ITypeStorage
    {
        /// <summary>
        /// Метод получения полного списка типов заказа
        /// </summary>
        /// <returns>Список типов заказа</returns>
        List<TypeViewModel> GetFullList();

        /// <summary>
        /// Метод получения отфильтрованного списка типов заказа
        /// </summary>
        /// <param name="model">Модель типа заказов</param>
        /// <returns>Список отфильтрованных типов заказа</returns>
        List<TypeViewModel> GetFilteredList(TypeBindingModel model);

        /// <summary>
        /// Метод получения типа закза
        /// </summary>
        /// <param name="model">Модель типа заказа </param>
        /// <returns> Столик </returns>
        TypeViewModel GetElement(TypeBindingModel model);

        /// <summary>
        /// Добавить новый тип заказа
        /// </summary>
        /// <param name="model">Модель типа заказа</param>
        void Insert(TypeBindingModel model);

        /// <summary>
        /// Обновить тип заказа
        /// </summary>
        /// <param name="model">Модель типа заказа</param>
        void Update(TypeBindingModel model);

        /// <summary>
        /// Удалить тип заказа
        /// </summary>
        /// <param name="model">Модель типа заказа</param>
        void Delete(TypeBindingModel model);
    }
}
