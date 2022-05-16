using System;

class OOP_Aula06
{
    static void Main()
    {
        BankAccount c1 = new BankAccount("Felipe");
        BankAccount c2 = new BankAccount("Karoline");
        c1.openAccount("CC");
        c2.openAccount("CP");
        //Console.WriteLine("Nome do owner: " + c1.getowner()); 
        //Console.WriteLine("Número da conta: " + c1.getnumAccount()); 
        Console.WriteLine("Bank Account Balance: " + c1.getBalance());
    }
}

class BankAccount
{
    //Atributos
    public int numAccount;
    public string owner;
    public bool status;
    public string type;
    public float balance; 

    //Método Construtor
    public BankAccount(string d) {
        status = false;
        balance = 0;
        owner = d;
    }

    //Métodos Específicos
    public void openAccount(string t) {
        type = t;
        if (t == "CC") {
            balance = 100;
        } else if (t == "CP") {
            balance = 50;
        } else {
            Console.WriteLine("type de conta inválida!");
        }
        status = true;
    }

    public void fecharConta() {
        if (balance > 0) {
            Console.WriteLine("Ainda há Balance, não foi possível encerrar esta conta!");
        } else if (balance < 0) {
            Console.WriteLine("Existe débito, não foi possível encerrar esta conta!");
        } else {
            status = false;
            Console.WriteLine("Conta encerrada com sucesso!");
        }
    }

    public void depositar(float deposit) {
        balance += deposit;
    
    }

    //Métodos Getters e Setters
    public int getnumAccount()
    {
        return numAccount;
    }

    public void setnumAccount(int n)
    {
        numAccount = n;
    }

    public string getowner()
    {
        return owner;
    }

    public void setowner(string d)
    {
        owner = d;
    }

    public bool getstatus() {
        return status;
    }

    public void setstatus(bool s) {
        status = s;
    }

    public float getbalance() {
        return balance;
    }

    public void setbalance(float s) {
        balance = balance + s;
    }

    public string gettype() {
        return type;
    }

    public void settype(string t) {
        type = t;
    } 
}