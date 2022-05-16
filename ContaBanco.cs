using System;

class POO_Aula06
{
    static void Main()
    {
        ContaBanco c1 = new ContaBanco("Felipe");
        ContaBanco c2 = new ContaBanco("Karoline");
        c1.abrirConta("CC");
        c2.abrirConta("CP");
        //Console.WriteLine("Nome do Dono: " + c1.getDono()); 
        //Console.WriteLine("Número da conta: " + c1.getNumConta()); 
        Console.WriteLine("Saldo da conta: " + c1.getSaldo());
    }
}

class ContaBanco
{
    //Atributos
    public int numConta;
    public string dono;
    public bool status;
    public string tipo;
    public float saldo; 

    //Método Construtor
    public ContaBanco(string d) {
        status = false;
        saldo = 0;
        dono = d;
    }

    //Métodos Específicos
    public void abrirConta(string t) {
        tipo = t;
        if (t == "CC") {
            saldo = 100;
        } else if (t == "CP") {
            saldo = 50;
        } else {
            Console.WriteLine("Tipo de conta inválida!");
        }
        status = true;
    }

    public void fecharConta() {
        if (saldo > 0) {
            Console.WriteLine("Ainda há saldo, não foi possível encerrar esta conta!");
        } else if (saldo < 0) {
            Console.WriteLine("Existe débito, não foi possível encerrar esta conta!");
        } else {
            status = false;
            Console.WriteLine("Conta encerrada com sucesso!");
        }
    }

    public void depositar(float deposito) {
        saldo += deposito;
    
    }

    //Métodos Getters e Setters
    public int getNumConta()
    {
        return numConta;
    }

    public void setNumConta(int n)
    {
        numConta = n;
    }

    public string getDono()
    {
        return dono;
    }

    public void setDono(string d)
    {
        dono = d;
    }

    public bool getStatus() {
        return status;
    }

    public void setStatus(bool s) {
        status = s;
    }

    public float getSaldo() {
        return saldo;
    }

    public void setSaldo(float s) {
        saldo = saldo + s;
    }

    public string getTipo() {
        return tipo;
    }

    public void setTipo(string t) {
        tipo = t;
    } 
}