using System;
using System.Collections.Generic;
using System.Text;

namespace Команда
{
    class MomentumBalance
    {

        /*Снимок — это поведенческий паттерн проектирования, который позволяет сохранять и 
        * восстанавливать прошлые состояния объектов, не раскрывая подробностей их реализации.*/

        public int Balance { get; }

        public DateTime Date { get; }

        // public TypeBankAction TypeBankAction { get; }
        public MomentumBalance(int balance/*, TypeBankAction typeAction*/)
        {
            Balance = balance;
            Date = DateTime.Now;
            //TypeBankAction = typeAction;
        }
        public override string ToString()
        {
            return $"Balance :{Balance}; Date: {Date}";
            //return $"TypeBankAction: {TypeBankAction}; Balance :{Balance}; Date: {Date}";
        }
    }
}
