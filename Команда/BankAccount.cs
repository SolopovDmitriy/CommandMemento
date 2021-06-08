using System;
using System.Collections.Generic;
using System.Text;

namespace Команда
{
    class BankAccount
    {
        private int _balance;
        private int _overdraftLimit;
        public int Balance
        {
            get { return _balance; }
        }
        public BankAccount(int balance, int overdraftLimit)
        {
            _balance = balance;
            _overdraftLimit = overdraftLimit;           
        }



        /*public void Deposit(int amount)
        {
            if(amount >= 0)
            {
                _balance += amount;
                Console.WriteLine($"Положили на счет: ${amount}, текущий баланс: {_balance}");
            }
            else
            {
                throw new ArgumentException("Пополнение не может быть отрицательным");
            }
        }*/
        public MomentumBalance Deposit(int amount)
        {
            if (amount >= 0)
            {
                _balance += amount;
                Console.WriteLine($"Положили на счет: ${amount}, текущий баланс: {_balance}");
                return new MomentumBalance(_balance);
            }
            else
            {
                throw new ArgumentException("Пополнение не может быть отрицательным");
            }
        }


        public void Restore(MomentumBalance momentumBalance)  //сделал востановление данных из снимка
        {
            this._balance = momentumBalance.Balance; // this._balance - это баланс Этого аккаунта
                                                     // momentumBalance.Balance - это значение баланса, которое в снимке
        }


        // my code
        public MomentumBalance MakeMomentumBalance() // make snapshot
        {
            return new MomentumBalance(_balance); // создаём снимок. В конструктор снимка передаём баланс
        }
        // end my code 


        public bool WithDraw(int amount)
        {
            if (_balance + _overdraftLimit >= amount)
            {
                _balance -= amount;
                Console.WriteLine($"Снятие со счета: {amount}, текущий баланс: {_balance}");
                return true;
            }
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Снятие со счета невозможно, текущий баланс: {_balance} ");
            Console.ResetColor();
            return false;
        }
        public override string ToString()
        {
            return $"Банковский Аккаунт: Балланс: {_balance}";
        }

       


    }
}
