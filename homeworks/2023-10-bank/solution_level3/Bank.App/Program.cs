﻿using Bank.Logic;

Account account;

Console.Write("Type of account ([c]hecking, [b]usiness, [s]avings, [f]ixed deposite): ");
switch (Console.ReadLine()!)
{
    case "c": account = new CheckingAccount(); break;
    case "b": account = new BusinessAccount(); break;
    case "s": account = new Savings(); break;
    case "f": account = new FixedDeposite(); break;
    default: Console.WriteLine("Invalid input"); return;
}

Console.Write("Account number: ");
account.AccountNumber = Console.ReadLine()!;

Console.Write("Account holder: ");
account.AccountHolder = Console.ReadLine()!;

Console.Write("Current balance: ");
account.Balance = decimal.Parse(Console.ReadLine()!);

// Note special syntax with "is", see also description on our Discord server
if (account is FixedDeposite fd)
{
    Console.Write("Opening date: ");
    fd.OpeningDate = DateOnly.Parse(Console.ReadLine()!);

    Console.Write("Fixed until: ");
    fd.FixedUntil = DateOnly.Parse(Console.ReadLine()!);
}

var t = new Transaction();

Console.Write("Transaction acount number: ");
t.AccountNumber = Console.ReadLine()!;

Console.Write("Transaction description: ");
t.Description = Console.ReadLine()!;

Console.Write("Transaction amount: ");
t.Amount = decimal.Parse(Console.ReadLine()!);

Console.Write("Transaction timestamp: ");
t.Timestamp = DateTime.Parse(Console.ReadLine()!);

if (account.TryExecute(t))
{
    Console.WriteLine($"Transaction executed successfully. The new current balance is {account.Balance}.");
}
else
{
    Console.WriteLine("Transaction not allowed.");
}
