using System;
using System.Collections.Generic;
using System.Text;

namespace Команда
{
    class MomentumBalanceRepository
    {
        //history - это словарь, который хранит историю для всех аккаунтов  
        private Dictionary<BankAccount, Stack<MomentumBalance>> history; // ключ - это аккаунт,
                                                                         // значение - это стек снимков


        public MomentumBalanceRepository() // конструктор
        {
            history = new Dictionary<BankAccount, Stack<MomentumBalance>>(); // создаём пустой словарь
        }


        public void Add(BankAccount bankAccount, MomentumBalance momentumBalance) // добавить снимок в историю
        {
            if (!history.ContainsKey(bankAccount)) // если в истории еще не было этого аккаунта, то 
            {
                history[bankAccount] = new Stack<MomentumBalance>(); // создаём пустой стек для этого аккаунта
            }           
            history[bankAccount].Push(momentumBalance); //  history[bankAccount] - это стек снимков для bankAccount
            // Push(momentumBalance) -- добавляет снимок в стек 
        }



        public void ControlZ(BankAccount bankAccount) //Undo
        {
            if (history.ContainsKey(bankAccount) && history[bankAccount].Count != 0)  // если в словаре history есть аккаунт
                                                                                      // И у этого аккаунта количество снимков
                                                                                      // не равно нулю 
            {
                MomentumBalance lastMomentumBalance = history[bankAccount].Pop(); // удаляет из стека последний снимок
                                                                                  // (верхний снимок )
                bankAccount.Restore(lastMomentumBalance); // восстанавливаем аккаунт по данному снимку lastMomentumBalance
            }
        }

        public void ControlZ(BankAccount bankAccount, int numberStep) // numberStep - сколько раз нужно откатиться
        {
            for (int i = 0; i < numberStep; i++) // этот цикл выполняется numberStep раз 
            {
                ControlZ(bankAccount);
            }
        }

        //public void PrintHistory() // List вместо Stack
        //{
            
        //}


    }
}
