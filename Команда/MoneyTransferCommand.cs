using System;
using System.Collections.Generic;
using System.Text;

namespace Команда
{
    class MoneyTransferCommand
    {
        FacadeBankAccountCommand _facadeBankAccountCommand;
        public MoneyTransferCommand(BankAccount from, BankAccount to, int amount)
        {
            _facadeBankAccountCommand = new FacadeBankAccountCommand();
            _facadeBankAccountCommand.Add(new BankAccountCommand(from, TypeBankAction.WithDraw, amount));
            _facadeBankAccountCommand.Add(new BankAccountCommand(to, TypeBankAction.Deposit, amount));
        }
        public void Transfer()
        {
            _facadeBankAccountCommand.Execute();
        }
    }
}
