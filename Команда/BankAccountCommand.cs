using System;
using System.Collections.Generic;
using System.Text;

namespace Команда
{
    class BankAccountCommand : ICommand
    {
        private BankAccount _bankAccount;               // с каким счетом работаем

        private TypeBankAction _action;                 //тип текущей операции
        private int _amount;                            //обьем средств положить/снять
        private bool _succeeded;                        //успешность выполнения операции
        public TypeBankAction TypeBankAction
        {
            get { return _action; }
        }
        public bool Succeeded
        {
            get { return _succeeded; }
        }
        public BankAccountCommand(BankAccount bankAccount, TypeBankAction action, int amount)
        {
            _bankAccount = bankAccount;
            _action = action;
            _amount = amount;
        }
        public void Execute()                           //выполнение команды
        {
            switch (_action)
            {
                case TypeBankAction.Deposit:
                    _bankAccount.Deposit(_amount);
                    _succeeded = true;
                    break;
                case TypeBankAction.WithDraw:
                    _succeeded = _bankAccount.WithDraw(_amount);
                    break;
            }
        }
        public void Rollback()                          //откат применения команды
        {
            if (!_succeeded) return;
            switch (_action)
            {
                case TypeBankAction.Deposit:
                    _bankAccount.WithDraw(_amount);
                    break;
                case TypeBankAction.WithDraw:
                    _bankAccount.Deposit(_amount);
                    break;
            }
        }
    }
}
