using System;

class Jogo_de_Luta {
    static void Main() {
        Fighter f1 = new Fighter("Felipe", 20, 15, 15);
        Fighter f2 = new Fighter("Marcos", 15, 30, 5);
        Fight UFC1 = new Fight();
        f1.presentation();
        UFC1.ft_fight(f1,f2);
    }
}

class Fighter {
    public string name;
    public string type;
    public int life;
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

    public string getName() {
        return this.name;
    }

    public void presentation() {
        Console.WriteLine("Nome do Lutador: " + this.getName());
    }
}

class Fight {

    public void ft_fight(Fighter f1, Fighter f2) {
         Console.WriteLine("Luta iniciada!");
         Console.WriteLine("Turno 1: " + ft_damage());
    }

    public double ft_damage(Fighter f1, Fighter f2) {
        double dmg;
        if (f1.ft_agility() >= f2.ft_agility()) {
            dmg = f1.ft_attack() - f2.ft_defend();
        } else {
            dmg = f2.ft_attack() - f1.ft_defend();
        }
        return dmg;
    }
}