using System;
using System.Collections.Generic;
using System.Text;

namespace Команда
{
    class FacadeBankAccountCommand:ICommand
    {
        private List<BankAccountCommand> _bankAccountCommands;
        public FacadeBankAccountCommand()
        {
            _bankAccountCommands = new List<BankAccountCommand>();
        }
        public FacadeBankAccountCommand(IEnumerable<BankAccountCommand> collection) 
        {
            _bankAccountCommands.AddRange(collection);
        }
        public void ClearCommands() {

            _bankAccountCommands.Clear();
        }
        public void Execute()
        {
            Console.WriteLine("Facade Execute: ");
            foreach (var item in _bankAccountCommands)
            {
                item.Execute();
            }
        }
        public void Rollback()
        {
            Console.WriteLine("Facade Rollback: ");
            _bankAccountCommands.Reverse();
            foreach (var item in _bankAccountCommands)
            {
                item.Rollback();
            }
        }
        internal void Add(BankAccountCommand bankAccountCommand)
        {
            _bankAccountCommands.Add(bankAccountCommand);
        }
    }
}
