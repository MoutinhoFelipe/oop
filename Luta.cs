using System;

class Jogo_de_Luta {
    static void Main() {
        Fighter f1 = new Fighter("Felipe", 20, 15, 15);
        Fighter f2 = new Fighter("Marcos", 15, 30, 5);
        Fight UFC1 = new Fight();
        UFC1.ft_fight(f1,f2);
    }
}

class Fighter {
    public string name {get;set;}
    public string type;
    public double life;
    public int strength;
    public int defense;
    public int quickness;
    public double random_interval = 0.3;

    public Fighter (string n, int str, int def, int qck) {
        this.name = n;
        this.life = 100;
        this.strength = str;
        this.defense = def;
        this.quickness = qck;
    }

    public double ft_attack() {
        double atk;
        atk = this.strength;
        return atk;
    }

    public double ft_defend() {
        double def;
        def = this.defense;
        return def;
    }

    public double ft_agility() {
        double agi;
        agi = this.quickness;
        return agi;
    }

    public void presentation() {
        int i = 0;

        Console.WriteLine("Nome do Lutador: " + this.name);
        Console.WriteLine("Atributos do Lutador: ");

        Console.Write("Força:     ");
        while (i < (this.strength)){
            Console.Write("|");
            i++;
        };
        Console.WriteLine(" " + this.strength);
        i = 0;

        Console.Write("Defesa:    ");
        while (i < (this.defense)){
            Console.Write("|");
            i++;
        };
        Console.WriteLine(" " + this.defense);
        i = 0;

        Console.Write("Agilidade: ");
        while (i < (this.quickness)){
            Console.Write("|");
            i++;
        };
        Console.WriteLine(" " + this.quickness);
        i = 0;
        Console.WriteLine(" _______________________________ ");
    }
}

class Fight {

    public void ft_fight(Fighter f1, Fighter f2) {
        double dmg;
        int j = 0;
        f1.presentation();
        f2.presentation();
        Console.WriteLine("Luta iniciada!");

        while ((f1.life > 0) && (f2.life > 0)) {
            dmg = ft_damage(f1,f2);
            Console.WriteLine("Turno 1: " + f1.name + " perdeu de life " + dmg);
            f1.life -= dmg;
            Console.WriteLine("Life atual: " + f1.life);
            //j++;
        }
    }

    public double ft_damage(Fighter f1, Fighter f2) {
        double dmg;
        if (f1.ft_agility() >= f2.ft_agility()) {
            dmg = f1.ft_attack() - f2.ft_defend();
        } else {
            dmg = f2.ft_attack() - f1.ft_defend();
        }
        if (dmg < 0) {
            dmg = 0;
        }
        dmg = 10;
        return dmg;
    }
}