using System;

namespace Команда
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
             * Command, Action - 
                Command, Action - это поведенческий паттерн проектирования, который превращает запросы в объекты,
                позволяя передавать их как аргументы при вызове методов, 
                ставить запросы в очередь, логировать их, а также поддерживать отмену операций.

                Альтернатива: Обьект который представляеи собой всю нужную информацию для совершения определенного действия

             */



            //BankAccount bankAccount = new BankAccount(1500, 500);
            //bankAccount.Deposit(356);
            //bankAccount.Deposit(247);
            //bankAccount.WithDraw(2315);
            //bankAccount.WithDraw(300);
            //Console.WriteLine(bankAccount);


            //BankAccountCommand accountCommand = new BankAccountCommand(bankAccount, TypeBankAction.Deposit, 15000);

            //accountCommand.Execute();

            //accountCommand.Rollback();

            //Console.WriteLine(bankAccount);


            //FacadeBankAccountCommand bankAccountCommands = new FacadeBankAccountCommand();
            //bankAccountCommands.Add(new BankAccountCommand(bankAccount, TypeBankAction.Deposit, 11500));
            //bankAccountCommands.Add(new BankAccountCommand(bankAccount, TypeBankAction.Deposit, 752));
            //bankAccountCommands.Add(new BankAccountCommand(bankAccount, TypeBankAction.Deposit, 3154));
            //bankAccountCommands.Add(new BankAccountCommand(bankAccount, TypeBankAction.Deposit, 456));
            //bankAccountCommands.Add(new BankAccountCommand(bankAccount, TypeBankAction.WithDraw, 7589));


            //bankAccountCommands.Execute();

            //bankAccountCommands.Rollback();

            //bankAccountCommands.ClearCommands();


            //BankAccount from =  new BankAccount(1500, 500);
            //BankAccount to =  new BankAccount(715, 200);
            //MoneyTransferCommand moneyTransferCommand = new MoneyTransferCommand(from, to, 1800);
            //moneyTransferCommand.Transfer();
            //Console.WriteLine(from);
            //Console.WriteLine(to);

            //MomentumBalance mementoBalance = new MomentumBalance(1520, TypeBankAction.Deposit);
            //Console.WriteLine(mementoBalance);


            TestMementum();
        }

        static void TestMementum() // static method TestMementum
        {
            MomentumBalanceRepository momentumBalanceRepository = new MomentumBalanceRepository();// создали пустое хранилище снимков
            BankAccount bankAccount1 = new BankAccount(10000, 500);  // создали банковский аккаунт1 10000 грн на счету, 500 - овердрафт
            BankAccount bankAccount2 = new BankAccount(15000, 500);  // создали банковский аккаунт2 15000 грн на счету, 500 - овердрафт

            MomentumBalance momentumBalance1 =  bankAccount1.MakeMomentumBalance(); // сделали снимок (когда на счету было 10000) для первого банковского аккаунта create snapshot (momentumBalance1)            
            momentumBalanceRepository.Add(bankAccount1, momentumBalance1); // добавили снимок в хранилище momentumBalanceRepository

            //MomentumBalance momentumBalance2 = bankAccount1.Deposit(400); // положили 400 грн на счет1
            bankAccount1.Deposit(400); // положили 400 грн на счет1
            bankAccount1.Deposit(300);  // положили 300 грн на счет1

            
            momentumBalanceRepository.Add(bankAccount1, bankAccount1.MakeMomentumBalance()); // сделали снимок2 и добавили в хранилище снимков

            bankAccount1.WithDraw(2315); //  сняли 2315 грн со счета1
            bankAccount1.WithDraw(300);//  сняли 300 грн со счета1


            //momentumBalanceRepository.Undo(bankAccount1); // откатиться к  последнему снимку
            //                                              // когда было 10000
            //momentumBalanceRepository.Undo(bankAccount1);

            momentumBalanceRepository.ControlZ(bankAccount1, 2);





            Console.WriteLine("Result after restore: " +  bankAccount1);
        }
    
    }
}
