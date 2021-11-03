using BusinessLogics.BindingModels;
using BusinessLogics.Interfaces;
using BusinessLogics.ViewModels;
using System;
using System.Collections.Generic;

namespace BusinessLogics.BusinessLogic
{
    /// <summary>
    /// Логика типов
    /// </summary>
    public class TypeLogic
    {
        /// <summary>
        /// Хранилище типов
        /// </summary>
        private readonly ITypeStorage typeStorage;

        /// <summary>
        /// Конструктор логики типов заказа
        /// </summary>
        /// <param name="typeStorage"> Хранилище типов заказа </param>
        public TypeLogic(ITypeStorage typeStorage)
        {
            this.typeStorage = typeStorage;
        }

        /// <summary>
        /// Получить список типов
        /// </summary>
        /// <param name="model"> Модель типа </param>
        /// <returns> Список типов </returns>
        public List<TypeViewModel> Read(TypeBindingModel model)
        {
            if (model == null)
            {
                return typeStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<TypeViewModel>
            {
                typeStorage.GetElement(model)
            };
            }
            return typeStorage.GetFilteredList(model);
        }

        /// <summary>
        /// Добавить тип
        /// </summary>
        /// <param name="model"> Модель типа </param>
        public void CreateOrUpdate(TypeBindingModel model)
        {
            if (model.Id.HasValue)
            {
                typeStorage.Update(model);
            }
            else
            {
                typeStorage.Insert(model);
            }
        }

        /// <summary>
        /// Удалить тип
        /// </summary>
        /// <param name="model"> Модель типа </param>
        public void Delete(TypeBindingModel model)
        {
            var element = typeStorage.GetElement(new TypeBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Тип не найден");
            }
            typeStorage.Delete(model);
        }
    }
}

