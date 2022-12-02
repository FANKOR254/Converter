using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicValuesLib.Values
{
    public class Frequency : IValue
    {
        private double Value { get; set; }
        private string? From { get; set; }
        private string? To { get; set; }

        private string _valueName = "Частота";

        /// <summary>
        /// Метод возвращает конвертированное значение
        /// </summary>
        /// <returns></returns>
        public double GetConvertedValue(double value, string from, string to)
        {
            Value = value;
            From = from;
            To = to;
            ToSi();
            ToRequired();
            return Value;
        }

        /// <summary>
        /// Метод возвращает список единиц измерения
        /// </summary>
        /// <returns></returns>
        public List<string> GetMeasureList()
        {
            List<string> list = new List<string>();
            foreach (var str in _coeff)
            {
                list.Add(str.Key);
            }
            return list;
        }

        /// <summary>
        /// Метод конвертирует в нужные единицы измерения
        /// </summary>
        public void ToRequired()
        {
            Value /= _coeff[To];
        }

        /// <summary>
        /// Метод переводит в систему СИ
        /// </summary>
        public void ToSi()
        {
            Value *= _coeff[From];
        }

        public string GetValueName()
        {
            return _valueName;
        }

        private Dictionary<string, double> _coeff = new Dictionary<string, double>()
    {
        { "Миллигерцы",        0.01       },
        { "Герцы",    1   },
        { "Гектогерцы",         100      },
        { "Килогерцы",           1000 },
    };
    }
}
