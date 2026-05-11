using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameClub.Domain.DTO
{
    /// <summary>
    /// Вспомогательный класс для элементов выпадающего списка
    /// </summary>
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
