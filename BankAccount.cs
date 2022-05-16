using System;

class OOP_Lesson06
{
    static void Main()
    {
        //Creating a instance
        BankAccount c1 = new BankAccount(1,"Xarope O P");

        //Opening a bank account and depositing some money in it
        c1.openAccount("CC");
        c1.deposit(1000);

        //Displaying the balance
        Console.WriteLine("Bank Account Balance: " + c1.getBalance());

        //Withdraw the money
        c1.withdraw(c1.getBalance());

        //Trying to close the account
        c1.closeAccount();
        
    }
}

class BankAccount
{
    //Attributes
    public int numAccount;
    public string owner;
    public bool status;
    public string type;
    public float balance; 

    //Constructor Method
    public BankAccount(int n, string o) {
        numAccount = n;
        owner = o;
        status = false;
        balance = 0;
    }

    //Specific Methods
    public void openAccount(string t) {
        type = t;
        if (t == "CC") {
            balance = 100;
        } else if (t == "CP") {
            balance = 50;
        } else {
            Console.WriteLine("Invalid type account!");
        }
        status = true;
    }

    public void closeAccount() {
        if (balance > 0) {
            Console.WriteLine("This account could not be closed, there is still amount in!");
        } else if (balance < 0) {
            Console.WriteLine("This account could not be closed, there is a debt in it");
        } else {
            status = false;
            Console.WriteLine("This account was closed successfully!");
        }
    }

    public void deposit(float d) {
        balance += d;
    }

    public void withdraw(float w) {
        if (w >=0) {
            balance -= w;
            Console.WriteLine("Cash withdrawn successfully!");
        }
        
    }

    //Getters and Setters Methods
    public int getnumAccount()
    {
        return numAccount;
    }

    public void setnumAccount(int n)
    {
        numAccount = n;
    }

    public string getOwner()
    {
        return owner;
    }

    public void setOwner(string o)
    {
        owner = o;
    }

    public bool getStatus() {
        return status;
    }

    public void setStatus(bool s) {
        status = s;
    }

    public float getBalance() {
        return balance;
    }

    public void setBalance(float s) {
        balance += s;
    }

    public string getType() {
        return type;
    }

    public void setType(string t) {
        type = t;
    } 
}
